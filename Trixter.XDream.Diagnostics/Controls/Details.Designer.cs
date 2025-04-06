namespace Trixter.XDream.Diagnostics.Controls
{
    partial class Details
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lbAppliedResistance = new System.Windows.Forms.Label();
            this.vbActualResistance = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.cbApplyBrakes = new System.Windows.Forms.CheckBox();
            this.lbResistance = new System.Windows.Forms.Label();
            this.tbResistance = new System.Windows.Forms.TrackBar();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.lbTotalEnergy = new System.Windows.Forms.Label();
            this.lbTotalEnergyValue = new System.Windows.Forms.Label();
            this.pnRawData = new System.Windows.Forms.Panel();
            this.lbCrankTimeValue = new System.Windows.Forms.Label();
            this.lbFlywheelTime = new System.Windows.Forms.Label();
            this.lbFlywheelTimeValue = new System.Windows.Forms.Label();
            this.lbCrankTime = new System.Windows.Forms.Label();
            this.cbRawData = new System.Windows.Forms.CheckBox();
            this.lbPower = new System.Windows.Forms.Label();
            this.lbPowerValue = new System.Windows.Forms.Label();
            this.lbCrankRevs = new System.Windows.Forms.Label();
            this.lbCrankRevsValue = new System.Windows.Forms.Label();
            this.lbFlywheelRevs = new System.Windows.Forms.Label();
            this.lbFlywheelRevsValue = new System.Windows.Forms.Label();
            this.vbRightBrake = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.vbLeftBrake = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.vbSteering = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.lbCrankDirection = new System.Windows.Forms.Label();
            this.lbCrankDirectionValue = new System.Windows.Forms.Label();
            this.lbCrankSpeed = new System.Windows.Forms.Label();
            this.lbHeartRateValue = new System.Windows.Forms.Label();
            this.lbHeartRate = new System.Windows.Forms.Label();
            this.lbCrankSpeedValue = new System.Windows.Forms.Label();
            this.lbRightBrakeValue = new System.Windows.Forms.Label();
            this.lbLeftBrakeValue = new System.Windows.Forms.Label();
            this.lbSteeringValue = new System.Windows.Forms.Label();
            this.lbFlywheelSpeedValue = new System.Windows.Forms.Label();
            this.lbCrankPositionValue = new System.Windows.Forms.Label();
            this.lbButtons = new System.Windows.Forms.Label();
            this.lbFlywheel = new System.Windows.Forms.Label();
            this.lbCrankPos = new System.Windows.Forms.Label();
            this.lbRightBrake = new System.Windows.Forms.Label();
            this.lbLeftBrake = new System.Windows.Forms.Label();
            this.lbSteering = new System.Windows.Forms.Label();
            this.clbButtons = new System.Windows.Forms.CheckedListBox();
            this.gbOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).BeginInit();
            this.gbInput.SuspendLayout();
            this.pnRawData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lbAppliedResistance);
            this.gbOutput.Controls.Add(this.vbActualResistance);
            this.gbOutput.Controls.Add(this.cbApplyBrakes);
            this.gbOutput.Controls.Add(this.lbResistance);
            this.gbOutput.Controls.Add(this.tbResistance);
            this.gbOutput.Location = new System.Drawing.Point(530, 0);
            this.gbOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbOutput.Size = new System.Drawing.Size(214, 665);
            this.gbOutput.TabIndex = 7;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "To Device";
            // 
            // lbAppliedResistance
            // 
            this.lbAppliedResistance.Location = new System.Drawing.Point(112, 86);
            this.lbAppliedResistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAppliedResistance.Name = "lbAppliedResistance";
            this.lbAppliedResistance.Size = new System.Drawing.Size(92, 51);
            this.lbAppliedResistance.TabIndex = 4;
            this.lbAppliedResistance.Text = "Applied Resistance";
            this.lbAppliedResistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vbActualResistance
            // 
            this.vbActualResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbActualResistance.ClipOutOfRangeValues = true;
            this.vbActualResistance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbActualResistance.Location = new System.Drawing.Point(124, 149);
            this.vbActualResistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vbActualResistance.Maximum = 250;
            this.vbActualResistance.Name = "vbActualResistance";
            this.vbActualResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.vbActualResistance.Size = new System.Drawing.Size(34, 489);
            this.vbActualResistance.TabIndex = 3;
            this.vbActualResistance.Text = "valueBar1";
            this.vbActualResistance.Value = 0;
            // 
            // cbApplyBrakes
            // 
            this.cbApplyBrakes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbApplyBrakes.Checked = true;
            this.cbApplyBrakes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbApplyBrakes.Location = new System.Drawing.Point(12, 32);
            this.cbApplyBrakes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbApplyBrakes.Name = "cbApplyBrakes";
            this.cbApplyBrakes.Size = new System.Drawing.Size(183, 37);
            this.cbApplyBrakes.TabIndex = 0;
            this.cbApplyBrakes.Text = "Apply Brakes";
            this.cbApplyBrakes.UseVisualStyleBackColor = true;
            // 
            // lbResistance
            // 
            this.lbResistance.Location = new System.Drawing.Point(12, 86);
            this.lbResistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResistance.Name = "lbResistance";
            this.lbResistance.Size = new System.Drawing.Size(92, 51);
            this.lbResistance.TabIndex = 1;
            this.lbResistance.Text = "Base Resistance";
            this.lbResistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(33, 132);
            this.tbResistance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbResistance.Maximum = 250;
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbResistance.Size = new System.Drawing.Size(69, 523);
            this.tbResistance.TabIndex = 1;
            this.tbResistance.TickFrequency = 5;
            this.tbResistance.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbResistance.ValueChanged += new System.EventHandler(this.tbResistance_ValueChanged);
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lbTotalEnergy);
            this.gbInput.Controls.Add(this.lbTotalEnergyValue);
            this.gbInput.Controls.Add(this.pnRawData);
            this.gbInput.Controls.Add(this.cbRawData);
            this.gbInput.Controls.Add(this.lbPower);
            this.gbInput.Controls.Add(this.lbPowerValue);
            this.gbInput.Controls.Add(this.lbCrankRevs);
            this.gbInput.Controls.Add(this.lbCrankRevsValue);
            this.gbInput.Controls.Add(this.lbFlywheelRevs);
            this.gbInput.Controls.Add(this.lbFlywheelRevsValue);
            this.gbInput.Controls.Add(this.vbRightBrake);
            this.gbInput.Controls.Add(this.vbLeftBrake);
            this.gbInput.Controls.Add(this.vbSteering);
            this.gbInput.Controls.Add(this.lbCrankDirection);
            this.gbInput.Controls.Add(this.lbCrankDirectionValue);
            this.gbInput.Controls.Add(this.lbCrankSpeed);
            this.gbInput.Controls.Add(this.lbHeartRateValue);
            this.gbInput.Controls.Add(this.lbHeartRate);
            this.gbInput.Controls.Add(this.lbCrankSpeedValue);
            this.gbInput.Controls.Add(this.lbRightBrakeValue);
            this.gbInput.Controls.Add(this.lbLeftBrakeValue);
            this.gbInput.Controls.Add(this.lbSteeringValue);
            this.gbInput.Controls.Add(this.lbFlywheelSpeedValue);
            this.gbInput.Controls.Add(this.lbCrankPositionValue);
            this.gbInput.Controls.Add(this.lbButtons);
            this.gbInput.Controls.Add(this.lbFlywheel);
            this.gbInput.Controls.Add(this.lbCrankPos);
            this.gbInput.Controls.Add(this.lbRightBrake);
            this.gbInput.Controls.Add(this.lbLeftBrake);
            this.gbInput.Controls.Add(this.lbSteering);
            this.gbInput.Controls.Add(this.clbButtons);
            this.gbInput.Location = new System.Drawing.Point(0, 0);
            this.gbInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbInput.Name = "gbInput";
            this.gbInput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbInput.Size = new System.Drawing.Size(520, 665);
            this.gbInput.TabIndex = 6;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "From Device";
            // 
            // lbTotalEnergy
            // 
            this.lbTotalEnergy.AutoSize = true;
            this.lbTotalEnergy.Location = new System.Drawing.Point(409, 443);
            this.lbTotalEnergy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalEnergy.Name = "lbTotalEnergy";
            this.lbTotalEnergy.Size = new System.Drawing.Size(98, 20);
            this.lbTotalEnergy.TabIndex = 48;
            this.lbTotalEnergy.Text = "Total Energy";
            this.lbTotalEnergy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalEnergyValue
            // 
            this.lbTotalEnergyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalEnergyValue.Location = new System.Drawing.Point(394, 469);
            this.lbTotalEnergyValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalEnergyValue.Name = "lbTotalEnergyValue";
            this.lbTotalEnergyValue.Size = new System.Drawing.Size(113, 36);
            this.lbTotalEnergyValue.TabIndex = 47;
            this.lbTotalEnergyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnRawData
            // 
            this.pnRawData.Controls.Add(this.lbCrankTimeValue);
            this.pnRawData.Controls.Add(this.lbFlywheelTime);
            this.pnRawData.Controls.Add(this.lbFlywheelTimeValue);
            this.pnRawData.Controls.Add(this.lbCrankTime);
            this.pnRawData.Location = new System.Drawing.Point(340, 543);
            this.pnRawData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnRawData.Name = "pnRawData";
            this.pnRawData.Size = new System.Drawing.Size(171, 95);
            this.pnRawData.TabIndex = 46;
            this.pnRawData.Visible = false;
            // 
            // lbCrankTimeValue
            // 
            this.lbCrankTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankTimeValue.Location = new System.Drawing.Point(78, 6);
            this.lbCrankTimeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankTimeValue.Name = "lbCrankTimeValue";
            this.lbCrankTimeValue.Size = new System.Drawing.Size(89, 36);
            this.lbCrankTimeValue.TabIndex = 42;
            this.lbCrankTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelTime
            // 
            this.lbFlywheelTime.AutoSize = true;
            this.lbFlywheelTime.Location = new System.Drawing.Point(2, 62);
            this.lbFlywheelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelTime.Name = "lbFlywheelTime";
            this.lbFlywheelTime.Size = new System.Drawing.Size(70, 20);
            this.lbFlywheelTime.TabIndex = 45;
            this.lbFlywheelTime.Text = "Flywheel";
            this.lbFlywheelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheelTimeValue
            // 
            this.lbFlywheelTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelTimeValue.Location = new System.Drawing.Point(78, 52);
            this.lbFlywheelTimeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelTimeValue.Name = "lbFlywheelTimeValue";
            this.lbFlywheelTimeValue.Size = new System.Drawing.Size(89, 36);
            this.lbFlywheelTimeValue.TabIndex = 43;
            this.lbFlywheelTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankTime
            // 
            this.lbCrankTime.AutoSize = true;
            this.lbCrankTime.Location = new System.Drawing.Point(21, 14);
            this.lbCrankTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankTime.Name = "lbCrankTime";
            this.lbCrankTime.Size = new System.Drawing.Size(51, 20);
            this.lbCrankTime.TabIndex = 44;
            this.lbCrankTime.Text = "Crank";
            this.lbCrankTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRawData
            // 
            this.cbRawData.AutoSize = true;
            this.cbRawData.Location = new System.Drawing.Point(352, 514);
            this.cbRawData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRawData.Name = "cbRawData";
            this.cbRawData.Size = new System.Drawing.Size(150, 24);
            this.cbRawData.TabIndex = 41;
            this.cbRawData.Text = "Show Raw Data";
            this.cbRawData.UseVisualStyleBackColor = true;
            this.cbRawData.CheckedChanged += new System.EventHandler(this.cbRawData_CheckedChanged);
            // 
            // lbPower
            // 
            this.lbPower.AutoSize = true;
            this.lbPower.Location = new System.Drawing.Point(454, 374);
            this.lbPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPower.Name = "lbPower";
            this.lbPower.Size = new System.Drawing.Size(53, 20);
            this.lbPower.TabIndex = 40;
            this.lbPower.Text = "Power";
            this.lbPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPowerValue
            // 
            this.lbPowerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPowerValue.Location = new System.Drawing.Point(394, 400);
            this.lbPowerValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPowerValue.Name = "lbPowerValue";
            this.lbPowerValue.Size = new System.Drawing.Size(113, 36);
            this.lbPowerValue.TabIndex = 39;
            this.lbPowerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankRevs
            // 
            this.lbCrankRevs.AutoSize = true;
            this.lbCrankRevs.Location = new System.Drawing.Point(369, 303);
            this.lbCrankRevs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankRevs.Name = "lbCrankRevs";
            this.lbCrankRevs.Size = new System.Drawing.Size(138, 20);
            this.lbCrankRevs.TabIndex = 38;
            this.lbCrankRevs.Text = "Crank Revolutions";
            this.lbCrankRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankRevsValue
            // 
            this.lbCrankRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankRevsValue.Location = new System.Drawing.Point(394, 329);
            this.lbCrankRevsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankRevsValue.Name = "lbCrankRevsValue";
            this.lbCrankRevsValue.Size = new System.Drawing.Size(113, 36);
            this.lbCrankRevsValue.TabIndex = 37;
            this.lbCrankRevsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelRevs
            // 
            this.lbFlywheelRevs.AutoSize = true;
            this.lbFlywheelRevs.Location = new System.Drawing.Point(350, 232);
            this.lbFlywheelRevs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelRevs.Name = "lbFlywheelRevs";
            this.lbFlywheelRevs.Size = new System.Drawing.Size(157, 20);
            this.lbFlywheelRevs.TabIndex = 36;
            this.lbFlywheelRevs.Text = "Flywheel Revolutions";
            this.lbFlywheelRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheelRevsValue
            // 
            this.lbFlywheelRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelRevsValue.Location = new System.Drawing.Point(394, 260);
            this.lbFlywheelRevsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelRevsValue.Name = "lbFlywheelRevsValue";
            this.lbFlywheelRevsValue.Size = new System.Drawing.Size(113, 36);
            this.lbFlywheelRevsValue.TabIndex = 34;
            this.lbFlywheelRevsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vbRightBrake
            // 
            this.vbRightBrake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbRightBrake.ClipOutOfRangeValues = true;
            this.vbRightBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbRightBrake.Location = new System.Drawing.Point(138, 128);
            this.vbRightBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vbRightBrake.Maximum = 250;
            this.vbRightBrake.Name = "vbRightBrake";
            this.vbRightBrake.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbRightBrake.Size = new System.Drawing.Size(294, 37);
            this.vbRightBrake.TabIndex = 33;
            this.vbRightBrake.Value = 0;
            // 
            // vbLeftBrake
            // 
            this.vbLeftBrake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbLeftBrake.ClipOutOfRangeValues = true;
            this.vbLeftBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbLeftBrake.Location = new System.Drawing.Point(138, 82);
            this.vbLeftBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vbLeftBrake.Maximum = 250;
            this.vbLeftBrake.Name = "vbLeftBrake";
            this.vbLeftBrake.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbLeftBrake.Size = new System.Drawing.Size(294, 37);
            this.vbLeftBrake.TabIndex = 32;
            this.vbLeftBrake.Value = 0;
            // 
            // vbSteering
            // 
            this.vbSteering.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbSteering.ClipOutOfRangeValues = true;
            this.vbSteering.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbSteering.Location = new System.Drawing.Point(138, 37);
            this.vbSteering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vbSteering.Maximum = 255;
            this.vbSteering.Name = "vbSteering";
            this.vbSteering.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbSteering.Size = new System.Drawing.Size(294, 37);
            this.vbSteering.TabIndex = 31;
            this.vbSteering.Value = 0;
            // 
            // lbCrankDirection
            // 
            this.lbCrankDirection.AutoSize = true;
            this.lbCrankDirection.Location = new System.Drawing.Point(14, 272);
            this.lbCrankDirection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankDirection.Name = "lbCrankDirection";
            this.lbCrankDirection.Size = new System.Drawing.Size(118, 20);
            this.lbCrankDirection.TabIndex = 30;
            this.lbCrankDirection.Text = "Crank Direction";
            this.lbCrankDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankDirectionValue
            // 
            this.lbCrankDirectionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankDirectionValue.Location = new System.Drawing.Point(138, 265);
            this.lbCrankDirectionValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankDirectionValue.Name = "lbCrankDirectionValue";
            this.lbCrankDirectionValue.Size = new System.Drawing.Size(179, 36);
            this.lbCrankDirectionValue.TabIndex = 29;
            this.lbCrankDirectionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCrankSpeed
            // 
            this.lbCrankSpeed.AutoSize = true;
            this.lbCrankSpeed.Location = new System.Drawing.Point(30, 229);
            this.lbCrankSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankSpeed.Name = "lbCrankSpeed";
            this.lbCrankSpeed.Size = new System.Drawing.Size(102, 20);
            this.lbCrankSpeed.TabIndex = 28;
            this.lbCrankSpeed.Text = "Crank Speed";
            this.lbCrankSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHeartRateValue
            // 
            this.lbHeartRateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHeartRateValue.Location = new System.Drawing.Point(420, 175);
            this.lbHeartRateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHeartRateValue.Name = "lbHeartRateValue";
            this.lbHeartRateValue.Size = new System.Drawing.Size(89, 36);
            this.lbHeartRateValue.TabIndex = 26;
            this.lbHeartRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHeartRate
            // 
            this.lbHeartRate.AutoSize = true;
            this.lbHeartRate.Location = new System.Drawing.Point(326, 185);
            this.lbHeartRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHeartRate.Name = "lbHeartRate";
            this.lbHeartRate.Size = new System.Drawing.Size(88, 20);
            this.lbHeartRate.TabIndex = 25;
            this.lbHeartRate.Text = "Heart Rate";
            // 
            // lbCrankSpeedValue
            // 
            this.lbCrankSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankSpeedValue.Location = new System.Drawing.Point(138, 220);
            this.lbCrankSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankSpeedValue.Name = "lbCrankSpeedValue";
            this.lbCrankSpeedValue.Size = new System.Drawing.Size(179, 36);
            this.lbCrankSpeedValue.TabIndex = 23;
            this.lbCrankSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRightBrakeValue
            // 
            this.lbRightBrakeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRightBrakeValue.Location = new System.Drawing.Point(444, 128);
            this.lbRightBrakeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightBrakeValue.Name = "lbRightBrakeValue";
            this.lbRightBrakeValue.Size = new System.Drawing.Size(65, 36);
            this.lbRightBrakeValue.TabIndex = 19;
            this.lbRightBrakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftBrakeValue
            // 
            this.lbLeftBrakeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLeftBrakeValue.Location = new System.Drawing.Point(444, 82);
            this.lbLeftBrakeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftBrakeValue.Name = "lbLeftBrakeValue";
            this.lbLeftBrakeValue.Size = new System.Drawing.Size(65, 36);
            this.lbLeftBrakeValue.TabIndex = 18;
            this.lbLeftBrakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSteeringValue
            // 
            this.lbSteeringValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSteeringValue.Location = new System.Drawing.Point(444, 37);
            this.lbSteeringValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSteeringValue.Name = "lbSteeringValue";
            this.lbSteeringValue.Size = new System.Drawing.Size(65, 36);
            this.lbSteeringValue.TabIndex = 17;
            this.lbSteeringValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelSpeedValue
            // 
            this.lbFlywheelSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelSpeedValue.Location = new System.Drawing.Point(138, 309);
            this.lbFlywheelSpeedValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelSpeedValue.Name = "lbFlywheelSpeedValue";
            this.lbFlywheelSpeedValue.Size = new System.Drawing.Size(179, 36);
            this.lbFlywheelSpeedValue.TabIndex = 14;
            this.lbFlywheelSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCrankPositionValue
            // 
            this.lbCrankPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankPositionValue.Location = new System.Drawing.Point(138, 175);
            this.lbCrankPositionValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankPositionValue.Name = "lbCrankPositionValue";
            this.lbCrankPositionValue.Size = new System.Drawing.Size(179, 36);
            this.lbCrankPositionValue.TabIndex = 13;
            this.lbCrankPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbButtons
            // 
            this.lbButtons.AutoSize = true;
            this.lbButtons.Location = new System.Drawing.Point(66, 358);
            this.lbButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbButtons.Name = "lbButtons";
            this.lbButtons.Size = new System.Drawing.Size(65, 20);
            this.lbButtons.TabIndex = 12;
            this.lbButtons.Text = "Buttons";
            this.lbButtons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheel
            // 
            this.lbFlywheel.AutoSize = true;
            this.lbFlywheel.Location = new System.Drawing.Point(10, 317);
            this.lbFlywheel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheel.Name = "lbFlywheel";
            this.lbFlywheel.Size = new System.Drawing.Size(121, 20);
            this.lbFlywheel.TabIndex = 11;
            this.lbFlywheel.Text = "Flywheel Speed";
            this.lbFlywheel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankPos
            // 
            this.lbCrankPos.AutoSize = true;
            this.lbCrankPos.Location = new System.Drawing.Point(21, 183);
            this.lbCrankPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankPos.Name = "lbCrankPos";
            this.lbCrankPos.Size = new System.Drawing.Size(111, 20);
            this.lbCrankPos.TabIndex = 9;
            this.lbCrankPos.Text = "Crank Position";
            this.lbCrankPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRightBrake
            // 
            this.lbRightBrake.AutoSize = true;
            this.lbRightBrake.Location = new System.Drawing.Point(34, 134);
            this.lbRightBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightBrake.Name = "lbRightBrake";
            this.lbRightBrake.Size = new System.Drawing.Size(93, 20);
            this.lbRightBrake.TabIndex = 7;
            this.lbRightBrake.Text = "Right Brake";
            this.lbRightBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftBrake
            // 
            this.lbLeftBrake.AutoSize = true;
            this.lbLeftBrake.Location = new System.Drawing.Point(45, 91);
            this.lbLeftBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftBrake.Name = "lbLeftBrake";
            this.lbLeftBrake.Size = new System.Drawing.Size(83, 20);
            this.lbLeftBrake.TabIndex = 6;
            this.lbLeftBrake.Text = "Left Brake";
            this.lbLeftBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSteering
            // 
            this.lbSteering.AutoSize = true;
            this.lbSteering.Location = new System.Drawing.Point(60, 45);
            this.lbSteering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSteering.Name = "lbSteering";
            this.lbSteering.Size = new System.Drawing.Size(69, 20);
            this.lbSteering.TabIndex = 5;
            this.lbSteering.Text = "Steering";
            this.lbSteering.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbButtons
            // 
            this.clbButtons.FormattingEnabled = true;
            this.clbButtons.Items.AddRange(new object[] {
            "Front Gear Up",
            "Front Gear Down",
            "Rear Gear Up",
            "Rear Gear Down",
            "Up",
            "Down",
            "Left",
            "Right",
            "Red",
            "Green",
            "Blue",
            "Seat"});
            this.clbButtons.Location = new System.Drawing.Point(138, 355);
            this.clbButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clbButtons.Name = "clbButtons";
            this.clbButtons.Size = new System.Drawing.Size(178, 303);
            this.clbButtons.TabIndex = 4;
            this.clbButtons.TabStop = false;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(746, 665);
            this.MinimumSize = new System.Drawing.Size(746, 665);
            this.Name = "Details";
            this.Size = new System.Drawing.Size(746, 665);
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.pnRawData.ResumeLayout(false);
            this.pnRawData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lbAppliedResistance;
        private ValueBar vbActualResistance;
        private System.Windows.Forms.CheckBox cbApplyBrakes;
        private System.Windows.Forms.Label lbResistance;
        private System.Windows.Forms.TrackBar tbResistance;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Label lbTotalEnergy;
        private System.Windows.Forms.Label lbTotalEnergyValue;
        private System.Windows.Forms.Panel pnRawData;
        private System.Windows.Forms.Label lbCrankTimeValue;
        private System.Windows.Forms.Label lbFlywheelTime;
        private System.Windows.Forms.Label lbFlywheelTimeValue;
        private System.Windows.Forms.Label lbCrankTime;
        private System.Windows.Forms.CheckBox cbRawData;
        private System.Windows.Forms.Label lbPower;
        private System.Windows.Forms.Label lbPowerValue;
        private System.Windows.Forms.Label lbCrankRevs;
        private System.Windows.Forms.Label lbCrankRevsValue;
        private System.Windows.Forms.Label lbFlywheelRevs;
        private System.Windows.Forms.Label lbFlywheelRevsValue;
        private ValueBar vbRightBrake;
        private ValueBar vbLeftBrake;
        private ValueBar vbSteering;
        private System.Windows.Forms.Label lbCrankDirection;
        private System.Windows.Forms.Label lbCrankDirectionValue;
        private System.Windows.Forms.Label lbCrankSpeed;
        private System.Windows.Forms.Label lbHeartRateValue;
        private System.Windows.Forms.Label lbHeartRate;
        private System.Windows.Forms.Label lbCrankSpeedValue;
        private System.Windows.Forms.Label lbRightBrakeValue;
        private System.Windows.Forms.Label lbLeftBrakeValue;
        private System.Windows.Forms.Label lbSteeringValue;
        private System.Windows.Forms.Label lbFlywheelSpeedValue;
        private System.Windows.Forms.Label lbCrankPositionValue;
        private System.Windows.Forms.Label lbButtons;
        private System.Windows.Forms.Label lbFlywheel;
        private System.Windows.Forms.Label lbCrankPos;
        private System.Windows.Forms.Label lbRightBrake;
        private System.Windows.Forms.Label lbLeftBrake;
        private System.Windows.Forms.Label lbSteering;
        private System.Windows.Forms.CheckedListBox clbButtons;
    }
}
