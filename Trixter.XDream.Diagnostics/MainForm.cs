using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Trixter.XDream.API;
using Trixter.XDream.API.Communications;

namespace Trixter.XDream.Diagnostics
{
    public partial class MainForm : Form
    {
        private object sync = new object();
        private DataAccess dataAccess;

        public DataAccess DataAccess
        {
            get => this.dataAccess;
            set
            {
                this.dataAccess = value;
                this.dDetailsControl.DataAccess = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            this.RefreshPorts();          

            this.tsbDisconnect.Enabled = false;
            this.dDetailsControl.Enabled = false;

            this.dDetailsControl.DataAccess = this.DataAccess;
        }

  
        protected override void OnClosing(CancelEventArgs e)
        {
            lock (this.sync)
            {
                if (this.DataAccess.XDreamMachine != null)
                {
                    this.DataAccess.XDreamMachine = null;
                }
            }
        }

        private void Update(DataAccess sender, XDreamState message)
        {


            try
            {
                Monitor.Enter(this.sync);

                if (this.DataAccess.XDreamMachine == null || this.IsDisposed || this.Disposing || !this.Visible)
                    return;

                if (this.InvokeRequired)
                {
                    Monitor.Exit(this.sync);

                    try
                    {
                        this.Invoke(new MethodInvoker(() => this.Update(sender, message)));

                    }
                    catch (ObjectDisposedException)
                    {
                        // TODO: refactor so this doesn't happen
                        // Checking for (!this.IsDisposed && !this.Disposing) is not enough.
                    }

                    return;
                }

                if (tcTabs.SelectedTab == this.tpDetails)
                    this.dDetailsControl.UpdateDetails();
            }
            finally
            {
                if (Monitor.IsEntered(this.sync))
                    Monitor.Exit(this.sync);
            }
        }


        private void tsbConnect_Click(object sender, EventArgs e)
        {
            string port = this.tscSerialPorts.SelectedItem as string;
            if(port!=null)
            {                
                this.DataAccess.XDreamMachine = XDreamBikeFactory.CreatePremium();
                this.DataAccess.StateUpdated += this.Update;

                try
                {
                    (this.DataAccess.XDreamMachine.DataSource as XDreamSerialPortClient).Connect(port);
                    this.tscSerialPorts.Enabled = false;
                    this.tsbConnect.Enabled = false;
                    this.tsbDisconnect.Enabled = true;
                    this.tsbRefreshPorts.Enabled = false;
                    this.dDetailsControl.Enabled = true;
                    this.tsbCapture.Enabled = true;
                }
                catch 
                {
                    MessageBox.Show($"Failed to connect to X-Dream Bike on {port}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshPorts()
        {
            var comPorts = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(comPorts);
            this.tscSerialPorts.Items.Clear();
            this.tscSerialPorts.Items.AddRange(comPorts);

            var bikePort = XDreamSerialPortClient.FindPorts(comPorts).FirstOrDefault();
            if (bikePort != null)
                this.tscSerialPorts.SelectedItem = bikePort;
            else if (comPorts.Length > 0)
                this.tscSerialPorts.SelectedIndex = 0;

            this.tsbConnect.Enabled = comPorts.Length > 0;
            this.tscSerialPorts.Enabled = comPorts.Length > 0;
        }

        private void Disconnect()
        {
            lock (this.sync)
            {
                if (this.DataAccess.XDreamMachine != null)
                {
                    using (XDreamSerialPortClient port = this.DataAccess.XDreamMachine.DataSource as XDreamSerialPortClient)
                        port.Disconnect();

                    this.DataAccess.XDreamMachine = null;
                    this.DataAccess.StateUpdated -= this.Update;

                    this.tscSerialPorts.Enabled = true;
                    this.tsbConnect.Enabled = true;
                    this.dDetailsControl.Enabled = false;

                    this.tsbDisconnect.Enabled = false;
                    this.tsbRefreshPorts.Enabled = true;
                    this.tsbCapture.Enabled = false;

                }
            }
        }

        private void tsbDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        private void tsbRefreshPorts_Click(object sender, EventArgs e)
        {
            this.RefreshPorts();
        }

       
        private void tcTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tcTabs.SelectedTab == this.tpDriver)
                this.gpGroupPolicyControl.Update();
        }

        private void tsbCapture_Click(object sender, EventArgs e)
        {
            this.DataAccess.Capturing = this.tsbCapture.Checked;
            this.tsbSave.Enabled = this.DataAccess.HasData;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            string suggestedFileName = $"XDream.{DateTimeOffset.Now:yyyyMMddHHmmss}.csv";

            this.dlgSaveFile.FileName = suggestedFileName;
            
            if (this.dlgSaveFile.ShowDialog(this) != DialogResult.OK)
                return;

            using(var stream = this.dlgSaveFile.OpenFile())
                this.DataAccess.Save(stream);

        }
    }
}
