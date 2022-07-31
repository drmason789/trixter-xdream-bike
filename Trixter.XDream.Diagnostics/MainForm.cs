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
        private XDreamMachine xdreamMachine;
                
        private DateTime lastMessageTime = DateTime.MinValue;
        private XDreamState lastMessage = null;
        
        public MainForm()
        {
            InitializeComponent();
            this.RefreshPorts();          

            this.tsbDisconnect.Enabled = false;
            
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

        private void Update(object sender, XDreamState message)
        {
            try
            {
                Monitor.Enter(this.sync);

                if (this.xdreamMachine == null || this.IsDisposed || this.Disposing || !this.Visible)
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
                
                if (DateTime.Now.Subtract(this.lastMessageTime).TotalMilliseconds < 100)
                    return;
                
                // determine the visible tab
                if (tcTabs.SelectedTab==tpDetails)
                    UpdateDetailsTab(message);
                    
            }
            finally
            {
                if (Monitor.IsEntered(this.sync))
                    Monitor.Exit(this.sync);
            }
        }
        private void UpdateDriverTab()
        {
            XDreamDeviceGroupPolicyUsbDeviceRestrictionReader xdr = new XDreamDeviceGroupPolicyUsbDeviceRestrictionReader();
            XDreamDeviceBlockingReport report = new XDreamDeviceBlockingReport(xdr);

            this.lbSummary.Text = report.GetSummary();
            this.lblOpinion.Text = report.GetOpinion();
            this.cbBlocking.Checked = xdr.DenyDeviceIDs;
            this.cbRetroactive.Checked = xdr.DenyDeviceIDsRetroactive;
            this.pnBlocking.Enabled = this.cbBlocking.Checked;
            this.cbRetroactive.Enabled = this.cbBlocking.Checked;

            foreach (var item in xdr.XDreamDevicesListed)
                this.lbDevices.Items.Add(item);
        }
        private void UpdateDetailsTab(XDreamState message)
        {
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
            this.lbCrankTimeValue.Text = message.Crank.ToString();
            this.lbCrankSpeedValue.Text = this.xdreamMachine.CrankMeter.RPM.ToString() + " RPM";
            this.lbCrankDirectionValue.Text = $"{this.xdreamMachine.CrankMeter.Direction}";
            this.lbFlywheelTimeValue.Text = message?.Flywheel.ToString();
            this.lbFlywheelSpeedValue.Text = this.xdreamMachine.FlywheelMeter.RPM.ToString() + " RPM";
            this.lbHeartRateValue.Text = $"{message.HeartRate} BPM";

            this.lbFlywheelRevsValue.Text = this.xdreamMachine.TripMeter.FlywheelRevolutions.ToString("0.0");
            this.lbCrankRevsValue.Text = this.xdreamMachine.TripMeter.CrankRevolutions.ToString("0.0");

            this.lbPowerValue.Text = this.xdreamMachine.PowerMeter.Power + " W";
            this.lbTotalPowerValue.Text = this.xdreamMachine.TripMeter.Power.ToString("0") + " W";

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

        private void tsbConnect_Click(object sender, EventArgs e)
        {

            string port = this.tscSerialPorts.SelectedItem as string;
            if(port!=null)
            {                
                this.xdreamMachine = XDreamBikeFactory.CreatePremium();
                this.xdreamMachine.StateUpdated += this.Update;

                try
                {
                    (this.xdreamMachine.DataSource as XDreamSerialPortClient).Connect(port);
                    this.tscSerialPorts.Enabled = false;
                    this.tsbConnect.Enabled = false;
                    this.tsbDisconnect.Enabled = true;
                    this.gbInput.Enabled = true;
                    this.gbOutput.Enabled = true;
                    this.tsbRefreshPorts.Enabled = false;
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
                if (this.xdreamMachine != null)
                {
                    using (XDreamSerialPortClient port = this.xdreamMachine.DataSource as XDreamSerialPortClient)
                        port.Disconnect();

                    this.xdreamMachine = null;

                    this.tscSerialPorts.Enabled = true;
                    this.tsbConnect.Enabled = true;
                    this.tsbDisconnect.Enabled = false;
                    this.gbInput.Enabled = false;
                    this.gbOutput.Enabled = false;
                    this.tsbRefreshPorts.Enabled = true;
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

        private void cbRawData_CheckedChanged(object sender, EventArgs e)
        {
            this.pnRawData.Visible = this.cbRawData.Checked;
        }

        
        private void tcTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tcTabs.SelectedTab == this.tpDriver)
                this.UpdateDriverTab();
        }

    }
}
