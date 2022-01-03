using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.UI
{
    public partial class MainForm : Form
    {
        private object sync = new object();
        private XDreamMachine xdreamMachine;
                
        private DateTime lastMessageTime = DateTime.MinValue;
        private XDreamState lastMessage = null;

        public MainForm()
        {
            InitializeComponent();
            this.RefreshPorts();          

            this.bnDisconnect.Enabled = false;
            
            this.gbInput.Enabled = false;
            this.gbOutput.Enabled = false;

            this.vbActualResistance.Maximum = XDreamSerialPortClient.MaxResistance;
            this.tbResistance.Maximum = XDreamSerialPortClient.MaxResistance;

        }

        private int GetResistance()
        {
            const double scale = 1d / (Constants.MaxBrake - Constants.MinBrake);
            int result = this.tbResistance.Value;
            int brake = 0;

            if(this.lastMessage!=null && this.cbApplyBrakes.Checked)
            {
                brake = (int)(0.5+( 2* Constants.MaxBrake - this.lastMessage.LeftBrake - this.lastMessage.RightBrake) * scale * XDreamSerialPortClient.MaxResistance / 2);
            }

            return Math.Max(0,Math.Min(XDreamSerialPortClient.MaxResistance, result + brake));

        }

        private void UpdateResistance()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdateResistance));
                return;
            }

            int actualResistance = this.GetResistance();
            this.xdreamMachine.Resistance = actualResistance;
        }

        private void tbResistance_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateResistance();
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            lock (this.sync)
            {
                if (this.xdreamMachine != null)
                {
                    this.xdreamMachine.StateUpdated -= this.Update;
                    this.xdreamMachine = null;
                }
            }
        }

        public void Update(object sender, XDreamState message)
        {
            try
            {
                Monitor.Enter(this.sync);

                if (this.xdreamMachine == null || this.IsDisposed || this.Disposing || !this.Visible)
                    return;

                if (DateTime.Now.Subtract(this.lastMessageTime).TotalMilliseconds < 100)
                    return;

                if (this.InvokeRequired)
                {
                    Monitor.Exit(this.sync);
                    try
                    {
                        this.Invoke(new MethodInvoker(() => this.Update(sender, message)));
                    }
                    catch(ObjectDisposedException)
                    {
                        // TODO: refactor so this doesn't happen
                        // Checking for (!this.IsDisposed && !this.Disposing) is not enough.
                    }
                    return;
                }

                this.lastMessageTime = DateTime.Now;
                this.lastMessage = message;

                if (message == null)
                    gbInput.Enabled = false;
                else
                    gbInput.Enabled = true;

                this.UpdateResistance();
                this.vbActualResistance.Value = this.xdreamMachine.Resistance;
                this.vbSteering.Value = message.Steering;
                this.lbSteeringValue.Text = message.Steering.ToString();
                this.vbLeftBrake.Value = message.LeftBrake;
                this.lbLeftBrakeValue.Text = message.LeftBrake.ToString();
                this.vbRightBrake.Value = message.RightBrake;
                this.lbRightBrakeValue.Text = message.RightBrake.ToString();
                this.lbCrankPositionValue.Text = message.CrankPosition.ToString();

                this.lbCrankSpeedValue.Text = $"{message.Crank} : {this.xdreamMachine.CrankMeter.RPM} RPM";
                this.lbCrankDirectionValue.Text = $"{this.xdreamMachine.CrankMeter.Direction}";

                this.lbFlywheelValue.Text = $"{message.Flywheel} : {this.xdreamMachine.FlywheelMeter.RPM} RPM";
                this.lbHeartRateValue.Text = $"{message.HeartRate} BPM";

                this.lbFlywheelRevsValue.Text = this.xdreamMachine.TripMeter.FlywheelRevolutions.ToString("0.0");
                this.lbCrankRevsValue.Text = this.xdreamMachine.TripMeter.CrankRevolutions.ToString("0.0");

                this.lbPowerValue.Text = this.xdreamMachine.PowerMeter.Power + " W";

                this.clbButtons.SetItemChecked(0, message.FrontGearUp);
                this.clbButtons.SetItemChecked(1, message.FrontGearDown);
                this.clbButtons.SetItemChecked(2, message.BackGearUp);
                this.clbButtons.SetItemChecked(3, message.BackGearDown);
                this.clbButtons.SetItemChecked(4, message.UpArrow);
                this.clbButtons.SetItemChecked(5, message.DownArrow);
                this.clbButtons.SetItemChecked(6, message.LeftArrow);
                this.clbButtons.SetItemChecked(7, message.RightArrow);
                this.clbButtons.SetItemChecked(8, message.Red);
                this.clbButtons.SetItemChecked(9, message.Green);
                this.clbButtons.SetItemChecked(10, message.Blue);
                this.clbButtons.SetItemChecked(11, message.Seated);
            }
            finally
            {
                if(Monitor.IsEntered(this.sync))
                    Monitor.Exit(this.sync);                
            }

        }

        private void bnConnect_Click(object sender, EventArgs e)
        {

            string port = this.cbPorts.SelectedItem as string;
            if(port!=null)
            {                
                this.xdreamMachine = XDreamBikeFactory.CreatePremium();
                this.xdreamMachine.StateUpdated += this.Update;

                try
                {
                    (this.xdreamMachine.DataSource as XDreamSerialPortClient).Connect(port);
                    this.cbPorts.Enabled = false;
                    this.bnConnect.Enabled = false;
                    this.bnDisconnect.Enabled = true;
                    this.gbInput.Enabled = true;
                    this.gbOutput.Enabled = true;
                    this.bnRefreshPorts.Enabled = false;
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
            this.cbPorts.Items.Clear();
            this.cbPorts.Items.AddRange(comPorts);

            var bikePort = XDreamSerialPortClient.FindPorts(comPorts).FirstOrDefault();
            if (bikePort != null)
                this.cbPorts.SelectedItem = bikePort;
            else if (comPorts.Length > 0)
                this.cbPorts.SelectedIndex = 0;

            this.bnConnect.Enabled = comPorts.Length > 0;
            this.cbPorts.Enabled = comPorts.Length > 0;
        }

        private void Disconnect()
        {
            lock (this.sync)
            {
                if (this.xdreamMachine != null)
                {
                    using (XDreamSerialPortClient port = this.xdreamMachine.DataSource as XDreamSerialPortClient)
                        port.Disconnect();

                    this.xdreamMachine = null;

                    this.cbPorts.Enabled = true;
                    this.bnConnect.Enabled = true;
                    this.bnDisconnect.Enabled = false;
                    this.gbInput.Enabled = false;
                    this.gbOutput.Enabled = false;
                    this.bnRefreshPorts.Enabled = true;
                }
            }
        }

        private void bnDisconnect_Click(object sender, EventArgs e)
        {
            this.Disconnect();
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            this.RefreshPorts();
        }

       
    }
}
