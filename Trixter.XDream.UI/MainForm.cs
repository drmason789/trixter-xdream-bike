using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.UI
{
    public partial class MainForm : Form
    {
        private XDreamClient client;
        private DateTime lastMessageTime = DateTime.MinValue;
            

        public MainForm()
        {
            InitializeComponent();

            var comPorts = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(comPorts);
            this.cbPorts.Items.AddRange(comPorts);

            var bikePort = XDreamClient.FindPorts(comPorts).FirstOrDefault();
            if (bikePort != null)
                this.cbPorts.SelectedItem = bikePort;
            else if (comPorts.Length > 0)
                this.cbPorts.SelectedIndex = 0;

            this.bnConnect.Enabled = comPorts.Length > 0;
            this.cbPorts.Enabled = comPorts.Length > 0;
            this.bnDisconnect.Enabled = false;
            
            this.gbInput.Enabled = false;
            this.gbOutput.Enabled = false;


        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.client.Resistance = trackBar1.Value;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.client != null)
            {
                this.client.Disconnect();
                this.client.MessageReceived -= this.Update;
                this.client = null;
            }
        }

        public void Update(object sender, XDreamMessage message)
        {


            if (this.client==null || this.IsDisposed || !this.Visible)
                return;

            if (DateTime.Now.Subtract(this.lastMessageTime).TotalMilliseconds < 100)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.Update(sender, message)));
                return;
            }

            this.lastMessageTime = DateTime.Now;

            if (message == null)
                gbInput.Enabled = false;
            else
                gbInput.Enabled = true;

            this.pbSteering.Value = message.Steering;
            this.lbSteeringValue.Text = message.Steering.ToString();
            this.pbLeftBrake.Value = message.LeftBrake;
            this.lbLeftBrakeValue.Text = message.LeftBrake.ToString();
            this.pbRightBrake.Value = message.RightBrake;
            this.lbRightBrakeValue.Text = message.RightBrake.ToString();
            this.lbCrankPosition.Text = message.CrankPosition.ToString();


            // Interpreting these values is guesswork
            if (message.FlywheelRevolutionTime.HasValue)
                // 360000 is guesswork that seems about right at 1RPM
                this.lbFlywheel.Text = $"{message.FlywheelRevolutionTime.Value} = {(360000 / message.FlywheelRevolutionTime.Value):0} RPM";
            else
                this.lbFlywheel.Text = "0 RPM";
            this.lbHeartRate.Text = $"{message.HeartRate} BPM";
            if(message.CrankRevolutionTime!=0)
                this.lbCrankSpeed.Text = $"{message.CrankRevolutionTime} (units?)";
            else
                this.lbCrankSpeed.Text = "";


            this.lbOther2.Text = message.Other2.ToString();
            this.lbOther6.Text = message.Other6.ToString();
            this.lbOther7.Text = message.Other7.ToString();
           
            this.lbOther30.Text = message.Other15.ToString();

            this.checkedListBox1.SetItemChecked(0, message.FrontGearUp);
            this.checkedListBox1.SetItemChecked(1, message.FrontGearDown);
            this.checkedListBox1.SetItemChecked(2, message.BackGearUp);
            this.checkedListBox1.SetItemChecked(3, message.BackGearDown);
            this.checkedListBox1.SetItemChecked(4, message.UpArrow);
            this.checkedListBox1.SetItemChecked(5, message.DownArrow);
            this.checkedListBox1.SetItemChecked(6, message.LeftArrow);
            this.checkedListBox1.SetItemChecked(7, message.RightArrow);
            this.checkedListBox1.SetItemChecked(8, message.Red);
            this.checkedListBox1.SetItemChecked(9, message.Green);
            this.checkedListBox1.SetItemChecked(10, message.Blue);
            this.checkedListBox1.SetItemChecked(11, message.Seated);
        }

        private void bnConnect_Click(object sender, EventArgs e)
        {

            string port = this.cbPorts.SelectedItem as string;
            if(port!=null)
            {
                this.client = new XDreamClient();
                this.client.MessageReceived += this.Update;

                try
                {
                    this.client.Connect(port);
                    this.cbPorts.Enabled = false;
                    this.bnConnect.Enabled = false;
                    this.bnDisconnect.Enabled = true;
                    this.gbInput.Enabled = true;
                    this.gbOutput.Enabled = true;
                }
                catch 
                {
                    MessageBox.Show($"Failed to connect to X-Dream Bike on {port}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
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
            }
        }
    }
}
