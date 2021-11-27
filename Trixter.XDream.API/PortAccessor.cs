using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace Trixter.XDream.API
{

    internal delegate void PortDataReceivedEventHandler(PortAccessor sender, byte[] bytes);


    internal class PortAccessor : IDisposable
    {
        private const int MinimumRetryIntervalMilliseconds = 100;
        
        private static int retries = 3;             
        private static int retryIntervalMilliseconds = MinimumRetryIntervalMilliseconds;

        object sync = new object();
        SerialPort serialPort;
        byte[] inputBuffer;
        
        public bool IsOpen
        {
            get
            {
                lock (sync) return this.serialPort?.IsOpen ?? false;
            }
        }

        /// <summary>
        /// The number of retries attempts that will be made if an UnauthorisedAccessException is thrown
        /// when the <see cref="SerialPort"/> object tries to connect.
        /// </summary>
        internal static int Retries 
        {
            get => retries; 
            set { retries = Math.Max(0, value); }
        }

        /// <summary>
        /// The number of milliseconds between retry attempts.
        /// </summary>
        internal static int RetryIntervalMilliseconds 
        { 
            get => retryIntervalMilliseconds; 
            set { retryIntervalMilliseconds = Math.Max(MinimumRetryIntervalMilliseconds, value); }
        }

        public event PortDataReceivedEventHandler DataReceived;

        protected void OnDataReceived(byte [] bytes)
        {
            this.DataReceived?.Invoke(this, bytes);
        }

        public PortAccessor()
        {

        }

        public void Dispose()
        {
            lock (this.sync)
            {
                this.serialPort?.Dispose();
                this.serialPort = null;
            }
        }

        private void Configure(string port)
        {
            // Create a new SerialPort object with default settings.
            serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            serialPort.PortName = port;
            serialPort.BaudRate = 115200; // found to not work at slower speeds
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.WriteBufferSize = 12;
            serialPort.Encoding = System.Text.Encoding.ASCII;
            
            // Set the read/write timeouts
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            // create the buffer
            this.inputBuffer = new byte[serialPort.ReadBufferSize];
        }


        public void Connect(string port)
        {
            if (this.serialPort?.IsOpen == true)
                throw new InvalidOperationException("Already connected.");

            Configure(port);

            if (this.serialPort == null)
                throw new Exception("Failed to configure serial port.");

            for (int attempt = 0; attempt<Retries; attempt++)
            {
                try
                {
                    this.serialPort.Open();
                    attempt = Retries;
                }
                catch (UnauthorizedAccessException)
                {
                    // If the next attempt exceeds the number of retries, rethrow the exception
                    if (attempt+1 >= Retries)
                        throw;

                    Thread.Sleep(RetryIntervalMilliseconds);
                }
            }

            // flush the old data
            this.serialPort.BaseStream.Flush();

            // Start reading
            Task.Factory.StartNew(ReadFromPort);
        }


        public void Disconnect()
        {
            lock (sync)
            {
                this.serialPort?.Close();
                this.serialPort = null;
            }
        }

        public void Write(byte [] bytes)
        {
            lock (this.sync)
            {
                if (!this.IsOpen)
                    throw new InvalidOperationException();

                this.serialPort?.Write(bytes, 0, bytes.Length);
            }          

        }

        private void ReadFromPort()
        {
            byte[] eventBuffer = null;

            if (this.inputBuffer == null)
                throw new InvalidOperationException("Input buffer is unallocated.");

            try
            {

                lock (this.sync)
                {
                    if (!this.IsOpen)
                        return;

                    int actualLength = 0;

                    if (this.serialPort?.BytesToRead > 0)
                        actualLength = this.serialPort.BaseStream.Read(this.inputBuffer, 0, this.inputBuffer.Length);                

                    if (this.DataReceived != null)
                    {
                        eventBuffer = new byte[actualLength];
                        Array.Copy(this.inputBuffer, eventBuffer, actualLength);
                    }
                }

                if(eventBuffer!=null)
                    this.OnDataReceived(eventBuffer);

            }
            catch
            {
                // TODO: something more helpful to the client if an error occurs
            }

            finally
            {
                if (this.IsOpen)
                    Task.Factory.StartNew(ReadFromPort);
            }
        }
    }

}
