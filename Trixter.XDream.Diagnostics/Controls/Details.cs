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
using Trixter.XDream.API.Communications;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.Diagnostics.Controls
{
    public partial class Details : UserControl
    {
        private int updateInterval=100;
        private DateTimeOffset lastUpdate;

        public DataAccess DataAccess { get; set; }

        /// <summary>
        /// The minimum number of milliseconds between each update.
        /// </summary>
        [Browsable(true), Category(Constants.BehaviorCategory)]
        public int UpdateInterval
        {
            get => this.updateInterval;
            set { this.updateInterval = Math.Max(1000, Math.Min(0,value)); }
        }

        public Details()
        {
            InitializeComponent();
            
            this.vbActualResistance.Maximum = XDreamSerialPortClient.MaxResistance;
            this.tbResistance.Maximum = XDreamSerialPortClient.MaxResistance;
        }

        private void cbRawData_CheckedChanged(object sender, EventArgs e)
        {
            this.pnRawData.Visible = this.cbRawData.Checked;
        }

        private int GetResistance()
        {
            const double scale = 1d / (API.Constants.MaxBrake - API.Constants.MinBrake);
            int result = this.tbResistance.Value;
            int brake = 0;
            XDreamState lastMessage = this.DataAccess.LastMessage;

            if (lastMessage != null && this.cbApplyBrakes.Checked)
            {
                brake = (int)(0.5 + (2 * API.Constants.MaxBrake - lastMessage.LeftBrake - lastMessage.RightBrake) * scale * XDreamSerialPortClient.MaxResistance / 2);
            }

            return Math.Max(0, Math.Min(XDreamSerialPortClient.MaxResistance, result + brake));

        }

        private void UpdateResistance()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdateResistance));
                return;
            }

            int actualResistance = this.GetResistance();
            this.DataAccess.XDreamMachine.Resistance = actualResistance;
        }

        public void UpdateDetails()
        {
            if (DateTimeOffset.UtcNow.Subtract(this.lastUpdate).TotalMilliseconds < this.updateInterval)
                return;

            this.lastUpdate = DateTimeOffset.UtcNow;

            XDreamMachine xdm = this.DataAccess?.XDreamMachine;
            
            if (xdm == null)
                return;

            XDreamState message = this.DataAccess.LastMessage;

            this.Enabled = message != null;
            if (!this.Enabled) return;

            this.UpdateResistance();
            this.vbActualResistance.Value = xdm.Resistance;
            this.vbSteering.Value = message.Steering;
            this.lbSteeringValue.Text = message.Steering.ToString();
            this.vbLeftBrake.Value = message.LeftBrake;
            this.lbLeftBrakeValue.Text = message.LeftBrake.ToString();
            this.vbRightBrake.Value = message.RightBrake;
            this.lbRightBrakeValue.Text = message.RightBrake.ToString();
            this.lbCrankPositionValue.Text = message.CrankPosition.ToString();
            this.lbCrankTimeValue.Text = message.Crank.ToString();



            this.lbCrankSpeedValue.Text = xdm.CrankMeter.RPM.ToString() + " RPM";
            this.lbCrankDirectionValue.Text = $"{xdm.CrankMeter.Direction}";
            this.lbFlywheelTimeValue.Text = message?.Flywheel.ToString();
            this.lbFlywheelSpeedValue.Text = xdm.FlywheelMeter.RPM.ToString() + " RPM";
            this.lbHeartRateValue.Text = $"{message.HeartRate} BPM";

            this.lbFlywheelRevsValue.Text = xdm.TripMeter.FlywheelRevolutions.ToString("0.0");
            this.lbCrankRevsValue.Text = xdm.TripMeter.CrankRevolutions.ToString("0.0");

            this.lbPowerValue.Text = xdm.PowerMeter.Power + " W";

            var energy = (double)xdm.TripMeter.Energy * 0.001;
           

            this.lbTotalEnergyValue.Text = energy.ToString("0.00 kJ");

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

        private void tbResistance_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateResistance();

        }
    }
}
