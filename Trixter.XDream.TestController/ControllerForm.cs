
using System;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.TestController
{
    public partial class ControllerForm : Form
    {

        Controller controller;

        bool suppressEvents = false;
        const int MaxBrake = Constants.MaxBrake, MinBrake = Constants.MinBrake;
        Func<int, int> invertBrakeValue = v => MaxBrake - v + MinBrake;
        const int MaxFlywheelRPM = 1000;
        DateTimeOffset lastCrankPositionInvalidated = DateTimeOffset.MinValue;

        public ControllerForm()
        {
            InitializeComponent();

            this.bnLeft.Tag = XDreamControllerButtons.LeftArrow;
            this.bnRight.Tag = XDreamControllerButtons.RightArrow;
            this.bnUp.Tag = XDreamControllerButtons.UpArrow;
            this.bnDown.Tag = XDreamControllerButtons.DownArrow;

            this.bnLeftGearDown.Tag = XDreamControllerButtons.FrontGearDown;
            this.bnLeftGearUp.Tag = XDreamControllerButtons.FrontGearUp;
            this.bnRightGearUp.Tag = XDreamControllerButtons.BackGearUp;
            this.bnRightGearDown.Tag = XDreamControllerButtons.BackGearDown;

            this.bnRed.Tag = XDreamControllerButtons.Red;
            this.bnBlue.Tag = XDreamControllerButtons.Blue;
            this.bnGreen.Tag = XDreamControllerButtons.Green;

            this.DoWithSuppressedEvents(() =>
            {

                this.tbLeftBrake.Minimum = MinBrake;
                this.tbLeftBrake.Maximum = MaxBrake;
                this.tbRightBrake.Minimum = MinBrake;
                this.tbRightBrake.Maximum = MaxBrake;
                this.tbBothBrakes.Minimum = MinBrake;
                this.tbBothBrakes.Maximum = MaxBrake;
                this.nudLeftBrake.Minimum = MinBrake;
                this.nudLeftBrake.Maximum = MaxBrake;
                this.nudRightBrake.Minimum = MinBrake;
                this.nudRightBrake.Maximum = MaxBrake;

                this.nudRightBrake.Value = MaxBrake;
                this.nudLeftBrake.Value = MaxBrake;

                this.tbSteering.Maximum = Constants.MaxSteering;
                this.tbSteering.Minimum = Constants.MinSteering;
                this.tbSteering.Value = Constants.MidSteering;

                this.nudFlywheelRevTime.Maximum = MappedFlywheelMeter.DefaultFlywheelRpmToRaw(0);
                this.nudFlywheelRevTime.Minimum = MappedFlywheelMeter.DefaultFlywheelRpmToRaw(MaxFlywheelRPM);
                this.nudRPM.Maximum = MaxFlywheelRPM;
                this.tbFlywheelSpeed.Maximum = MaxFlywheelRPM;
            });
            this.controller = new Controller();

            this.controller.ResistanceChanged += Controller_ResistanceChanged;
            this.controller.CrankPositionChanged += Controller_CrankPositionChanged;

            this.controller.Connect();
            this.controller.Send();

            this.nudCrankPosition.Paint += (s, e) =>
            {
                this.DoWithSuppressedEvents(() => this.nudCrankPosition.Value = this.controller.State.CrankPosition);
            };
        }

        private void DoWithSuppressedEvents(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (this.suppressEvents)
                return;

            try
            {
                this.suppressEvents = true;

                action();
            }
            finally
            {
                this.suppressEvents = false;
            }
        }

        private void UpdateResistance()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(UpdateResistance));
                }
                catch (ObjectDisposedException)
                {
                    // TODO: refactor so this doesn't happen
                    // Checking for (!this.IsDisposed && !this.Disposing) is not enough.
                }

                return;
            }
            this.lbResistanceValue.Text = this.controller.Resistance.ToString();
        }

        private void Controller_ResistanceChanged(Controller sender)
        {
            this.UpdateResistance();
        }

        private void cbSeated_CheckedChanged(object sender, System.EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                controller.State.Seated = this.cbSeated.Checked;
                controller.Send();
            });
        }

        private void tbSteering_ValueChanged(object sender, System.EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                controller.State.Steering = tbSteering.Value;
                controller.Send();
            });

        }

        private void bnButton_Released(object sender, MouseEventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {

                Button button = sender as Button;

                XDreamControllerButtons xdb = (XDreamControllerButtons)button.Tag;

                controller.State.Buttons &= ~xdb;
                controller.Send();
            });
        }

        private void bnButton_KeyUp(object sender, KeyEventArgs e)
        {
            bnButton_Released(sender, null);
        }

        private void bnButton_Pressed(object sender, MouseEventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                Button button = sender as Button;

                XDreamControllerButtons xdb = (XDreamControllerButtons)button.Tag;

                controller.State.Buttons |= xdb;
                controller.Send();
            });
        }

        private void bnButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                bnButton_Pressed(sender, null);
        }

        private void tbSteering_MouseUp(object sender, MouseEventArgs e)
        {
            this.tbSteering.Value = Constants.MidSteering;

        }

        private void tbCrankSpeed_ValueChanged(object sender, System.EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                int rpm;

                if (sender == this.tbCrankSpeed)
                {
                    rpm = this.tbCrankSpeed.Value;
                    this.nudCrankRPM.Value = rpm;

                }
                else if (sender == this.nudCrankRPM)
                {
                    rpm = (int)this.nudCrankRPM.Value;
                    this.tbCrankSpeed.Value = rpm;
                }
                else
                    throw new Exception("Unexpected sender.");

                int crankTime = MappedCrankMeter.DefaultMappingRpmToRaw(rpm);
                this.nudCrankRevTime.Value = crankTime;

                this.controller.CrankRPM = rpm;

            });
        }

        private void Controller_CrankPositionChanged(Controller sender, int delta)
        {
            if ((DateTimeOffset.Now - this.lastCrankPositionInvalidated).TotalMilliseconds > 10)
            {
                this.nudCrankPosition.Invalidate();
                this.lastCrankPositionInvalidated = DateTimeOffset.Now;
            }
        }

        private void tbFlywheelSpeed_ValueChanged(object sender, System.EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                int rpm;

                if (sender == this.tbFlywheelSpeed)
                {
                    rpm = this.tbFlywheelSpeed.Value;
                    this.nudRPM.Value = rpm;

                }
                else if (sender == this.nudRPM)
                {
                    rpm = (int)this.nudRPM.Value;
                    this.tbFlywheelSpeed.Value = rpm;
                }
                else
                    throw new Exception("Unexpected sender.");

                int flywheelTime = MappedFlywheelMeter.DefaultFlywheelRpmToRaw(rpm);
                this.nudFlywheelRevTime.Value = flywheelTime;

                this.controller.State.Flywheel = flywheelTime;
                this.controller.Send();

            });
        }

        private void nudFlywheelRevTime_ValueChanged(object sender, System.EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                this.suppressEvents = true;
                this.controller.State.Flywheel = (int)this.nudFlywheelRevTime.Value;
                int rpm = MappedFlywheelMeter.DefaultFlywheelRawToRpm(this.controller.State.Flywheel);
                this.tbFlywheelSpeed.Value = rpm;
                this.nudRPM.Value = rpm;
                this.controller.Send();
            });
        }

        private void Brake_MouseUp(object sender, MouseEventArgs e)
        {
            ((TrackBar)sender).Value = invertBrakeValue(MaxBrake);
        }

        private void Brake_ValueChanged(object sender, EventArgs e)
        {
            this.DoWithSuppressedEvents(() =>
            {
                int value = 0;
                bool isLeft = false, isRight = false;

                if (sender == tbLeftBrake)
                {
                    isLeft = true;
                    value = this.invertBrakeValue(tbLeftBrake.Value);
                    this.nudLeftBrake.Value = value;
                }
                else if (sender == nudLeftBrake)
                {
                    isLeft = true;
                    value = (int)nudLeftBrake.Value;
                    this.tbLeftBrake.Value = this.invertBrakeValue(value);
                }
                else if (sender == tbRightBrake)
                {
                    isRight = true;
                    value = this.invertBrakeValue(tbRightBrake.Value);
                    nudRightBrake.Value = (int)value;
                }
                else if (sender == nudRightBrake)
                {
                    isRight = true;
                    value = (int)nudRightBrake.Value;
                    this.tbRightBrake.Value = this.invertBrakeValue(value);
                }
                else if (sender == tbBothBrakes)
                {
                    isRight = isLeft = true;
                    value = tbBothBrakes.Value;
                    this.tbLeftBrake.Value = value;
                    this.tbRightBrake.Value = value;

                    value = this.invertBrakeValue(value);
                    this.nudLeftBrake.Value = value;
                    this.nudRightBrake.Value = value;
                }

                if (isRight)
                    this.controller.State.RightBrake = value;
                if (isLeft)
                    this.controller.State.LeftBrake = value;

                if (isLeft || isRight)
                    this.controller.Send();

            });
        }

    }
}
