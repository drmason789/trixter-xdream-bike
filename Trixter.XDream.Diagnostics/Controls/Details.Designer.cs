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
            this.components = new System.ComponentModel.Container();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lbAppliedResistance = new System.Windows.Forms.Label();
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
            this.vbActualResistance = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.vbRightBrake = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.vbLeftBrake = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.vbSteering = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
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
            this.gbOutput.Location = new System.Drawing.Point(353, 0);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(143, 432);
            this.gbOutput.TabIndex = 7;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "To Device";
            // 
            // lbAppliedResistance
            // 
            this.lbAppliedResistance.Location = new System.Drawing.Point(75, 56);
            this.lbAppliedResistance.Name = "lbAppliedResistance";
            this.lbAppliedResistance.Size = new System.Drawing.Size(61, 33);
            this.lbAppliedResistance.TabIndex = 4;
            this.lbAppliedResistance.Text = "Applied Resistance";
            this.lbAppliedResistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbApplyBrakes
            // 
            this.cbApplyBrakes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbApplyBrakes.Checked = true;
            this.cbApplyBrakes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbApplyBrakes.Location = new System.Drawing.Point(8, 21);
            this.cbApplyBrakes.Name = "cbApplyBrakes";
            this.cbApplyBrakes.Size = new System.Drawing.Size(122, 24);
            this.cbApplyBrakes.TabIndex = 0;
            this.cbApplyBrakes.Text = "Apply Brakes";
            this.cbApplyBrakes.UseVisualStyleBackColor = true;
            // 
            // lbResistance
            // 
            this.lbResistance.Location = new System.Drawing.Point(8, 56);
            this.lbResistance.Name = "lbResistance";
            this.lbResistance.Size = new System.Drawing.Size(61, 33);
            this.lbResistance.TabIndex = 1;
            this.lbResistance.Text = "Base Resistance";
            this.lbResistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(22, 86);
            this.tbResistance.Maximum = 250;
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbResistance.Size = new System.Drawing.Size(69, 340);
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
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(347, 432);
            this.gbInput.TabIndex = 6;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "From Device";
            // 
            // lbTotalEnergy
            // 
            this.lbTotalEnergy.AutoSize = true;
            this.lbTotalEnergy.Location = new System.Drawing.Point(273, 288);
            this.lbTotalEnergy.Name = "lbTotalEnergy";
            this.lbTotalEnergy.Size = new System.Drawing.Size(67, 13);
            this.lbTotalEnergy.TabIndex = 48;
            this.lbTotalEnergy.Text = "Total Energy";
            this.lbTotalEnergy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalEnergyValue
            // 
            this.lbTotalEnergyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalEnergyValue.Location = new System.Drawing.Point(263, 305);
            this.lbTotalEnergyValue.Name = "lbTotalEnergyValue";
            this.lbTotalEnergyValue.Size = new System.Drawing.Size(76, 24);
            this.lbTotalEnergyValue.TabIndex = 47;
            this.lbTotalEnergyValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTips.SetToolTip(this.lbTotalEnergyValue, "This value is calculated from the power estimate.");
            // 
            // pnRawData
            // 
            this.pnRawData.Controls.Add(this.lbCrankTimeValue);
            this.pnRawData.Controls.Add(this.lbFlywheelTime);
            this.pnRawData.Controls.Add(this.lbFlywheelTimeValue);
            this.pnRawData.Controls.Add(this.lbCrankTime);
            this.pnRawData.Location = new System.Drawing.Point(227, 353);
            this.pnRawData.Name = "pnRawData";
            this.pnRawData.Size = new System.Drawing.Size(114, 62);
            this.pnRawData.TabIndex = 46;
            this.pnRawData.Visible = false;
            // 
            // lbCrankTimeValue
            // 
            this.lbCrankTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankTimeValue.Location = new System.Drawing.Point(52, 4);
            this.lbCrankTimeValue.Name = "lbCrankTimeValue";
            this.lbCrankTimeValue.Size = new System.Drawing.Size(60, 24);
            this.lbCrankTimeValue.TabIndex = 42;
            this.lbCrankTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelTime
            // 
            this.lbFlywheelTime.AutoSize = true;
            this.lbFlywheelTime.Location = new System.Drawing.Point(1, 40);
            this.lbFlywheelTime.Name = "lbFlywheelTime";
            this.lbFlywheelTime.Size = new System.Drawing.Size(48, 13);
            this.lbFlywheelTime.TabIndex = 45;
            this.lbFlywheelTime.Text = "Flywheel";
            this.lbFlywheelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheelTimeValue
            // 
            this.lbFlywheelTimeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelTimeValue.Location = new System.Drawing.Point(52, 34);
            this.lbFlywheelTimeValue.Name = "lbFlywheelTimeValue";
            this.lbFlywheelTimeValue.Size = new System.Drawing.Size(60, 24);
            this.lbFlywheelTimeValue.TabIndex = 43;
            this.lbFlywheelTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankTime
            // 
            this.lbCrankTime.AutoSize = true;
            this.lbCrankTime.Location = new System.Drawing.Point(14, 9);
            this.lbCrankTime.Name = "lbCrankTime";
            this.lbCrankTime.Size = new System.Drawing.Size(35, 13);
            this.lbCrankTime.TabIndex = 44;
            this.lbCrankTime.Text = "Crank";
            this.lbCrankTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRawData
            // 
            this.cbRawData.AutoSize = true;
            this.cbRawData.Location = new System.Drawing.Point(235, 334);
            this.cbRawData.Name = "cbRawData";
            this.cbRawData.Size = new System.Drawing.Size(111, 21);
            this.cbRawData.TabIndex = 41;
            this.cbRawData.Text = "Show Raw Data";
            this.cbRawData.UseVisualStyleBackColor = true;
            this.cbRawData.CheckedChanged += new System.EventHandler(this.cbRawData_CheckedChanged);
            // 
            // lbPower
            // 
            this.lbPower.AutoSize = true;
            this.lbPower.Location = new System.Drawing.Point(260, 244);
            this.lbPower.Name = "lbPower";
            this.lbPower.Size = new System.Drawing.Size(80, 13);
            this.lbPower.TabIndex = 40;
            this.lbPower.Text = "Power Estimate";
            this.lbPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPowerValue
            // 
            this.lbPowerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPowerValue.Location = new System.Drawing.Point(263, 260);
            this.lbPowerValue.Name = "lbPowerValue";
            this.lbPowerValue.Size = new System.Drawing.Size(76, 24);
            this.lbPowerValue.TabIndex = 39;
            this.lbPowerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTips.SetToolTip(this.lbPowerValue, "This power value is an estimate from a table, which is configured for very specif" +
        "ic solenoid positioning and performance, almost certainly different from the dev" +
        "ice feeding this utility.");
            // 
            // lbCrankRevs
            // 
            this.lbCrankRevs.AutoSize = true;
            this.lbCrankRevs.Location = new System.Drawing.Point(246, 197);
            this.lbCrankRevs.Name = "lbCrankRevs";
            this.lbCrankRevs.Size = new System.Drawing.Size(94, 13);
            this.lbCrankRevs.TabIndex = 38;
            this.lbCrankRevs.Text = "Crank Revolutions";
            this.lbCrankRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankRevsValue
            // 
            this.lbCrankRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankRevsValue.Location = new System.Drawing.Point(263, 214);
            this.lbCrankRevsValue.Name = "lbCrankRevsValue";
            this.lbCrankRevsValue.Size = new System.Drawing.Size(76, 24);
            this.lbCrankRevsValue.TabIndex = 37;
            this.lbCrankRevsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelRevs
            // 
            this.lbFlywheelRevs.AutoSize = true;
            this.lbFlywheelRevs.Location = new System.Drawing.Point(233, 151);
            this.lbFlywheelRevs.Name = "lbFlywheelRevs";
            this.lbFlywheelRevs.Size = new System.Drawing.Size(107, 13);
            this.lbFlywheelRevs.TabIndex = 36;
            this.lbFlywheelRevs.Text = "Flywheel Revolutions";
            this.lbFlywheelRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheelRevsValue
            // 
            this.lbFlywheelRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelRevsValue.Location = new System.Drawing.Point(263, 169);
            this.lbFlywheelRevsValue.Name = "lbFlywheelRevsValue";
            this.lbFlywheelRevsValue.Size = new System.Drawing.Size(76, 24);
            this.lbFlywheelRevsValue.TabIndex = 34;
            this.lbFlywheelRevsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankDirection
            // 
            this.lbCrankDirection.AutoSize = true;
            this.lbCrankDirection.Location = new System.Drawing.Point(9, 177);
            this.lbCrankDirection.Name = "lbCrankDirection";
            this.lbCrankDirection.Size = new System.Drawing.Size(80, 13);
            this.lbCrankDirection.TabIndex = 30;
            this.lbCrankDirection.Text = "Crank Direction";
            this.lbCrankDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankDirectionValue
            // 
            this.lbCrankDirectionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankDirectionValue.Location = new System.Drawing.Point(92, 172);
            this.lbCrankDirectionValue.Name = "lbCrankDirectionValue";
            this.lbCrankDirectionValue.Size = new System.Drawing.Size(120, 24);
            this.lbCrankDirectionValue.TabIndex = 29;
            this.lbCrankDirectionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCrankSpeed
            // 
            this.lbCrankSpeed.AutoSize = true;
            this.lbCrankSpeed.Location = new System.Drawing.Point(20, 149);
            this.lbCrankSpeed.Name = "lbCrankSpeed";
            this.lbCrankSpeed.Size = new System.Drawing.Size(69, 13);
            this.lbCrankSpeed.TabIndex = 28;
            this.lbCrankSpeed.Text = "Crank Speed";
            this.lbCrankSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHeartRateValue
            // 
            this.lbHeartRateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHeartRateValue.Location = new System.Drawing.Point(280, 114);
            this.lbHeartRateValue.Name = "lbHeartRateValue";
            this.lbHeartRateValue.Size = new System.Drawing.Size(60, 24);
            this.lbHeartRateValue.TabIndex = 26;
            this.lbHeartRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHeartRate
            // 
            this.lbHeartRate.AutoSize = true;
            this.lbHeartRate.Location = new System.Drawing.Point(217, 120);
            this.lbHeartRate.Name = "lbHeartRate";
            this.lbHeartRate.Size = new System.Drawing.Size(59, 13);
            this.lbHeartRate.TabIndex = 25;
            this.lbHeartRate.Text = "Heart Rate";
            // 
            // lbCrankSpeedValue
            // 
            this.lbCrankSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankSpeedValue.Location = new System.Drawing.Point(92, 143);
            this.lbCrankSpeedValue.Name = "lbCrankSpeedValue";
            this.lbCrankSpeedValue.Size = new System.Drawing.Size(120, 24);
            this.lbCrankSpeedValue.TabIndex = 23;
            this.lbCrankSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRightBrakeValue
            // 
            this.lbRightBrakeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRightBrakeValue.Location = new System.Drawing.Point(296, 83);
            this.lbRightBrakeValue.Name = "lbRightBrakeValue";
            this.lbRightBrakeValue.Size = new System.Drawing.Size(44, 24);
            this.lbRightBrakeValue.TabIndex = 19;
            this.lbRightBrakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLeftBrakeValue
            // 
            this.lbLeftBrakeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLeftBrakeValue.Location = new System.Drawing.Point(296, 53);
            this.lbLeftBrakeValue.Name = "lbLeftBrakeValue";
            this.lbLeftBrakeValue.Size = new System.Drawing.Size(44, 24);
            this.lbLeftBrakeValue.TabIndex = 18;
            this.lbLeftBrakeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSteeringValue
            // 
            this.lbSteeringValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSteeringValue.Location = new System.Drawing.Point(296, 24);
            this.lbSteeringValue.Name = "lbSteeringValue";
            this.lbSteeringValue.Size = new System.Drawing.Size(44, 24);
            this.lbSteeringValue.TabIndex = 17;
            this.lbSteeringValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelSpeedValue
            // 
            this.lbFlywheelSpeedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelSpeedValue.Location = new System.Drawing.Point(92, 201);
            this.lbFlywheelSpeedValue.Name = "lbFlywheelSpeedValue";
            this.lbFlywheelSpeedValue.Size = new System.Drawing.Size(120, 24);
            this.lbFlywheelSpeedValue.TabIndex = 14;
            this.lbFlywheelSpeedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCrankPositionValue
            // 
            this.lbCrankPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankPositionValue.Location = new System.Drawing.Point(92, 114);
            this.lbCrankPositionValue.Name = "lbCrankPositionValue";
            this.lbCrankPositionValue.Size = new System.Drawing.Size(120, 24);
            this.lbCrankPositionValue.TabIndex = 13;
            this.lbCrankPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbButtons
            // 
            this.lbButtons.AutoSize = true;
            this.lbButtons.Location = new System.Drawing.Point(44, 233);
            this.lbButtons.Name = "lbButtons";
            this.lbButtons.Size = new System.Drawing.Size(43, 13);
            this.lbButtons.TabIndex = 12;
            this.lbButtons.Text = "Buttons";
            this.lbButtons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheel
            // 
            this.lbFlywheel.AutoSize = true;
            this.lbFlywheel.Location = new System.Drawing.Point(7, 206);
            this.lbFlywheel.Name = "lbFlywheel";
            this.lbFlywheel.Size = new System.Drawing.Size(82, 13);
            this.lbFlywheel.TabIndex = 11;
            this.lbFlywheel.Text = "Flywheel Speed";
            this.lbFlywheel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankPos
            // 
            this.lbCrankPos.AutoSize = true;
            this.lbCrankPos.Location = new System.Drawing.Point(14, 119);
            this.lbCrankPos.Name = "lbCrankPos";
            this.lbCrankPos.Size = new System.Drawing.Size(75, 13);
            this.lbCrankPos.TabIndex = 9;
            this.lbCrankPos.Text = "Crank Position";
            this.lbCrankPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRightBrake
            // 
            this.lbRightBrake.AutoSize = true;
            this.lbRightBrake.Location = new System.Drawing.Point(23, 87);
            this.lbRightBrake.Name = "lbRightBrake";
            this.lbRightBrake.Size = new System.Drawing.Size(63, 13);
            this.lbRightBrake.TabIndex = 7;
            this.lbRightBrake.Text = "Right Brake";
            this.lbRightBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftBrake
            // 
            this.lbLeftBrake.AutoSize = true;
            this.lbLeftBrake.Location = new System.Drawing.Point(30, 59);
            this.lbLeftBrake.Name = "lbLeftBrake";
            this.lbLeftBrake.Size = new System.Drawing.Size(56, 13);
            this.lbLeftBrake.TabIndex = 6;
            this.lbLeftBrake.Text = "Left Brake";
            this.lbLeftBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSteering
            // 
            this.lbSteering.AutoSize = true;
            this.lbSteering.Location = new System.Drawing.Point(40, 29);
            this.lbSteering.Name = "lbSteering";
            this.lbSteering.Size = new System.Drawing.Size(46, 13);
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
            this.clbButtons.Location = new System.Drawing.Point(92, 231);
            this.clbButtons.Name = "clbButtons";
            this.clbButtons.Size = new System.Drawing.Size(120, 174);
            this.clbButtons.TabIndex = 4;
            this.clbButtons.TabStop = false;
            // 
            // vbActualResistance
            // 
            this.vbActualResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbActualResistance.ClipOutOfRangeValues = true;
            this.vbActualResistance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbActualResistance.Location = new System.Drawing.Point(83, 97);
            this.vbActualResistance.Maximum = 250;
            this.vbActualResistance.Name = "vbActualResistance";
            this.vbActualResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.vbActualResistance.Size = new System.Drawing.Size(23, 318);
            this.vbActualResistance.TabIndex = 3;
            this.vbActualResistance.Text = "valueBar1";
            this.vbActualResistance.Value = 0;
            // 
            // vbRightBrake
            // 
            this.vbRightBrake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbRightBrake.ClipOutOfRangeValues = true;
            this.vbRightBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbRightBrake.Location = new System.Drawing.Point(92, 83);
            this.vbRightBrake.Maximum = 250;
            this.vbRightBrake.Name = "vbRightBrake";
            this.vbRightBrake.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbRightBrake.Size = new System.Drawing.Size(196, 24);
            this.vbRightBrake.TabIndex = 33;
            this.vbRightBrake.Text = "This value is expected to go no lower than around 135.";
            this.vbRightBrake.Value = 0;
            // 
            // vbLeftBrake
            // 
            this.vbLeftBrake.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbLeftBrake.ClipOutOfRangeValues = true;
            this.vbLeftBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbLeftBrake.Location = new System.Drawing.Point(92, 53);
            this.vbLeftBrake.Maximum = 250;
            this.vbLeftBrake.Name = "vbLeftBrake";
            this.vbLeftBrake.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbLeftBrake.Size = new System.Drawing.Size(196, 24);
            this.vbLeftBrake.TabIndex = 32;
            this.vbLeftBrake.Text = "This value is expected to go no lower than around 135.";
            this.vbLeftBrake.Value = 0;
            // 
            // vbSteering
            // 
            this.vbSteering.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbSteering.ClipOutOfRangeValues = true;
            this.vbSteering.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbSteering.Location = new System.Drawing.Point(92, 24);
            this.vbSteering.Maximum = 255;
            this.vbSteering.Name = "vbSteering";
            this.vbSteering.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.vbSteering.Size = new System.Drawing.Size(196, 24);
            this.vbSteering.TabIndex = 31;
            this.vbSteering.Value = 0;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(497, 432);
            this.MinimumSize = new System.Drawing.Size(497, 432);
            this.Name = "Details";
            this.Size = new System.Drawing.Size(497, 432);
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
        private System.Windows.Forms.ToolTip toolTips;
    }
}
