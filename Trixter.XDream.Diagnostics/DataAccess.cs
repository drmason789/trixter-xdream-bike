using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Trixter.XDream.API;
using Trixter.XDream.API.Communications;

namespace Trixter.XDream.Diagnostics
{
    public class DataAccess
    {
        private object sync = new object();
        private XDreamMachine xDreamMachine;
        private List<XDreamState> states;
        private DateTimeOffset t0;
        private bool capturing;

        public event XDreamStateUpdatedDelegate<DataAccess> StateUpdated;
        
        /// <summary>
        /// Indicates if there is data stored and the object is NOT capturing. I.e. can save.
        /// </summary>
        public bool HasData
        {
            get
            {
                lock (this.sync)
                {
                    return !this.Capturing && this.states.Count > 0;
                }
            }
        }

        public bool Capturing
        {
            get
            {
                lock (this.sync)
                    return this.capturing;
            }
            set
            {
                lock (this.sync)
                {
                    if (this.capturing == value)
                        return;

                    this.capturing = value;

                    if (this.Capturing)
                    {
                        this.t0 = default;
                        this.states = new List<XDreamState>(1048576);
                    }
                }
            }
        }


        public XDreamMachine XDreamMachine
        {
            get { lock(this.sync) return xDreamMachine; }
            set
            {
                lock (this.sync)
                {
                    if (object.ReferenceEquals(this.xDreamMachine, value))
                        return;

                    // unhook the old event handler
                    if (this.xDreamMachine != null)
                        this.xDreamMachine.StateUpdated -= this.Update;

                    this.xDreamMachine = value;

                    if(value!=null)
                        this.xDreamMachine.StateUpdated += this.Update;
                }
            }
        }

        public XDreamState LastMessage { get; private set; }



        public void Save(StreamWriter streamWriter)
        {
            if (!this.HasData)
                throw new InvalidOperationException("Object is capturing or has no data.");

            // Generate the strings
            var lines =
                this.states.Cast<XDreamMessage>()
                    .Select(l => new
                    {
                        dT = l.TimeStamp.Subtract(t0).TotalMilliseconds,
                        Text = string.Join("", l.RawInput.Select(b => b.ToString("x2")))
                    })
                    .Select(l => $"{l.dT:0000000},{l.Text}");

            
                foreach (var line in lines)
                    streamWriter.WriteLine(line);
        }

        public void Save(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew)) 
                this.Save(fileStream);
        }

        public void Save(Stream stream)
        {
            using(StreamWriter tw = new StreamWriter(stream, Encoding.ASCII))
                this.Save(tw);
        }


        private void Update(object sender, XDreamState message)
        {
            lock (this.sync)
            {
                this.LastMessage = message;

                if (this.Capturing)
                {
                    this.states.Add(message);
                    if (states.Count == 1)
                        this.t0 = message.TimeStamp;                    
                }
            }

            this.StateUpdated?.Invoke(this, message);
        }
    }
}