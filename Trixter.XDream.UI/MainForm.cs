using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.UI
{
    public partial class MainForm : Form
    {
        private XDreamClient client;
        private DateTime lastMessageTime = DateTime.MinValue;
        private XDreamState lastMessage = null;
        private ICrankMeter crankMeter = new HybridCrankMeter();

        public MainForm()
        {
            InitializeComponent();

            this.RefreshPorts();
            

            this.bnDisconnect.Enabled = false;
            
            this.gbInput.Enabled = false;
            this.gbOutput.Enabled = false;            

        }

        private int GetResistance()
        {
            const double scale = 1d / (XDreamClient.MaxBrakePosition - XDreamClient.MinBrakePosition);
            int result = this.tbResistance.Value;
            int brake = 0;

            if(this.lastMessage!=null && this.cbApplyBrakes.Checked)
            {
                brake = (int)(0.5+( 2* XDreamClient.MaxBrakePosition - this.lastMessage.LeftBrake - this.lastMessage.RightBrake) * scale * XDreamClient.MaxResistance / 2);
            }

            return Math.Max(0,Math.Min(XDreamClient.MaxResistance, result + brake));

        }

        private void UpdateResistance()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdateResistance));
                return;
            }

            int actualResistance = this.GetResistance();
            this.client.Resistance = actualResistance;
        }

        private void tbResistance_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateResistance();
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.client != null)
            {
                this.client.Disconnect();
                this.client.StateUpdated -= this.Update;
                this.client = null;
            }
        }

        public void Update(object sender, XDreamState message)
        {
            if (this.client==null || this.IsDisposed || !this.Visible)
                return;

            this.crankMeter.AddData(message);

            if (DateTime.Now.Subtract(this.lastMessageTime).TotalMilliseconds < 100)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.Update(sender, message)));
                return;
            }

            this.lastMessageTime = DateTime.Now;
            this.lastMessage = message;

            if (message == null)
                gbInput.Enabled = false;
            else
                gbInput.Enabled = true;

            this.UpdateResistance();
            this.vbActualResistance.Value = this.client.Resistance;
            this.vbSteering.Value = message.Steering;
            this.lbSteeringValue.Text = message.Steering.ToString();
            this.vbLeftBrake.Value = message.LeftBrake;
            this.lbLeftBrakeValue.Text = message.LeftBrake.ToString();
            this.vbRightBrake.Value = message.RightBrake;
            this.lbRightBrakeValue.Text = message.RightBrake.ToString();
            this.lbCrankPositionValue.Text = message.CrankPosition.ToString();

            
            this.lbCrankSpeedValue.Text = $"{message.Crank} : {this.crankMeter.RPM} RPM";
            this.lbCrankDirectionValue.Text = $"{this.crankMeter.Direction}";

            this.lbFlywheelValue.Text = $"{message.Flywheel} : {message.FlywheelRPM} RPM";
            this.lbHeartRateValue.Text = $"{message.HeartRate} BPM";
            

            this.lbOther2.Text = message.Other2.ToString();
            this.lbOther6.Text = message.Other6.ToString();
            this.lbOther7.Text = message.Other7.ToString();
            this.lbOther15.Text = message.Other15.ToString();

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

        private void bnConnect_Click(object sender, EventArgs e)
        {

            string port = this.cbPorts.SelectedItem as string;
            if(port!=null)
            {
                this.client = new XDreamClient();
                this.client.StateUpdated += this.Update;

                try
                {
                    this.client.Connect(port);
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


            var bikePort = XDreamClient.FindPorts(comPorts).FirstOrDefault();
            if (bikePort != null)
                this.cbPorts.SelectedItem = bikePort;
            else if (comPorts.Length > 0)
                this.cbPorts.SelectedIndex = 0;

            this.bnConnect.Enabled = comPorts.Length > 0;
            this.cbPorts.Enabled = comPorts.Length > 0;
        }

        private void bnDisconnect_Click(object sender, EventArgs e)
        {
            if(this.client!=null)
            {
                this.client.Disconnect();
                this.client.Dispose();
                this.cbPorts.Enabled = true;
                this.bnConnect.Enabled = true;
                this.gbInput.Enabled = false;
                this.gbOutput.Enabled = false;
                this.bnRefreshPorts.Enabled = true;
            }
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            this.RefreshPorts();
        }
    }
}
