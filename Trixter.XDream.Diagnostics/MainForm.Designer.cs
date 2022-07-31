
namespace Trixter.XDream.Diagnostics
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbResistance = new System.Windows.Forms.TrackBar();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.lbTotalPower = new System.Windows.Forms.Label();
            this.lbTotalPowerValue = new System.Windows.Forms.Label();
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
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.lbAppliedResistance = new System.Windows.Forms.Label();
            this.cbApplyBrakes = new System.Windows.Forms.CheckBox();
            this.lbResistance = new System.Windows.Forms.Label();
            this.tsToolStrip = new System.Windows.Forms.ToolStrip();
            this.tslSerialPort = new System.Windows.Forms.ToolStripLabel();
            this.tscSerialPorts = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefreshPorts = new System.Windows.Forms.ToolStripButton();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tcTabs = new System.Windows.Forms.TabControl();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.tpDriver = new System.Windows.Forms.TabPage();
            this.gbGroupPolicy = new System.Windows.Forms.GroupBox();
            this.lblOpinion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnBlocking = new System.Windows.Forms.Panel();
            this.lbXDreamDevices = new System.Windows.Forms.Label();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.cbRetroactive = new System.Windows.Forms.CheckBox();
            this.cbBlocking = new System.Windows.Forms.CheckBox();
            this.lbSummary = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vbActualResistance = new Trixter.XDream.Diagnostics.ValueBar();
            this.vbRightBrake = new Trixter.XDream.Diagnostics.ValueBar();
            this.vbLeftBrake = new Trixter.XDream.Diagnostics.ValueBar();
            this.vbSteering = new Trixter.XDream.Diagnostics.ValueBar();
            this.lbExplanation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).BeginInit();
            this.gbInput.SuspendLayout();
            this.pnRawData.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.tsToolStrip.SuspendLayout();
            this.tcTabs.SuspendLayout();
            this.tpDetails.SuspendLayout();
            this.tpDriver.SuspendLayout();
            this.gbGroupPolicy.SuspendLayout();
            this.pnBlocking.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(22, 86);
            this.tbResistance.Maximum = 250;
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbResistance.Size = new System.Drawing.Size(45, 340);
            this.tbResistance.TabIndex = 1;
            this.tbResistance.TickFrequency = 5;
            this.tbResistance.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbResistance.ValueChanged += new System.EventHandler(this.tbResistance_ValueChanged);
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lbTotalPower);
            this.gbInput.Controls.Add(this.lbTotalPowerValue);
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
            this.gbInput.Location = new System.Drawing.Point(6, 6);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(347, 432);
            this.gbInput.TabIndex = 4;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "From Device";
            // 
            // lbTotalPower
            // 
            this.lbTotalPower.AutoSize = true;
            this.lbTotalPower.Location = new System.Drawing.Point(277, 289);
            this.lbTotalPower.Name = "lbTotalPower";
            this.lbTotalPower.Size = new System.Drawing.Size(64, 13);
            this.lbTotalPower.TabIndex = 48;
            this.lbTotalPower.Text = "Total Power";
            this.lbTotalPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalPowerValue
            // 
            this.lbTotalPowerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalPowerValue.Location = new System.Drawing.Point(279, 305);
            this.lbTotalPowerValue.Name = "lbTotalPowerValue";
            this.lbTotalPowerValue.Size = new System.Drawing.Size(60, 24);
            this.lbTotalPowerValue.TabIndex = 47;
            this.lbTotalPowerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbRawData.Size = new System.Drawing.Size(104, 17);
            this.cbRawData.TabIndex = 41;
            this.cbRawData.Text = "Show Raw Data";
            this.cbRawData.UseVisualStyleBackColor = true;
            this.cbRawData.CheckedChanged += new System.EventHandler(this.cbRawData_CheckedChanged);
            // 
            // lbPower
            // 
            this.lbPower.AutoSize = true;
            this.lbPower.Location = new System.Drawing.Point(304, 243);
            this.lbPower.Name = "lbPower";
            this.lbPower.Size = new System.Drawing.Size(37, 13);
            this.lbPower.TabIndex = 40;
            this.lbPower.Text = "Power";
            this.lbPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPowerValue
            // 
            this.lbPowerValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPowerValue.Location = new System.Drawing.Point(279, 260);
            this.lbPowerValue.Name = "lbPowerValue";
            this.lbPowerValue.Size = new System.Drawing.Size(60, 24);
            this.lbPowerValue.TabIndex = 39;
            this.lbPowerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCrankRevs
            // 
            this.lbCrankRevs.AutoSize = true;
            this.lbCrankRevs.Location = new System.Drawing.Point(247, 197);
            this.lbCrankRevs.Name = "lbCrankRevs";
            this.lbCrankRevs.Size = new System.Drawing.Size(94, 13);
            this.lbCrankRevs.TabIndex = 38;
            this.lbCrankRevs.Text = "Crank Revolutions";
            this.lbCrankRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankRevsValue
            // 
            this.lbCrankRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankRevsValue.Location = new System.Drawing.Point(279, 214);
            this.lbCrankRevsValue.Name = "lbCrankRevsValue";
            this.lbCrankRevsValue.Size = new System.Drawing.Size(60, 24);
            this.lbCrankRevsValue.TabIndex = 37;
            this.lbCrankRevsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFlywheelRevs
            // 
            this.lbFlywheelRevs.AutoSize = true;
            this.lbFlywheelRevs.Location = new System.Drawing.Point(234, 151);
            this.lbFlywheelRevs.Name = "lbFlywheelRevs";
            this.lbFlywheelRevs.Size = new System.Drawing.Size(107, 13);
            this.lbFlywheelRevs.TabIndex = 36;
            this.lbFlywheelRevs.Text = "Flywheel Revolutions";
            this.lbFlywheelRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFlywheelRevsValue
            // 
            this.lbFlywheelRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelRevsValue.Location = new System.Drawing.Point(279, 169);
            this.lbFlywheelRevsValue.Name = "lbFlywheelRevsValue";
            this.lbFlywheelRevsValue.Size = new System.Drawing.Size(60, 24);
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
            this.clbButtons.Size = new System.Drawing.Size(120, 184);
            this.clbButtons.TabIndex = 4;
            this.clbButtons.TabStop = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.lbAppliedResistance);
            this.gbOutput.Controls.Add(this.vbActualResistance);
            this.gbOutput.Controls.Add(this.cbApplyBrakes);
            this.gbOutput.Controls.Add(this.lbResistance);
            this.gbOutput.Controls.Add(this.tbResistance);
            this.gbOutput.Location = new System.Drawing.Point(359, 6);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(143, 432);
            this.gbOutput.TabIndex = 5;
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
            // tsToolStrip
            // 
            this.tsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSerialPort,
            this.tscSerialPorts,
            this.tsbRefreshPorts,
            this.tsbConnect,
            this.tsbDisconnect,
            this.toolStripSeparator1});
            this.tsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tsToolStrip.Name = "tsToolStrip";
            this.tsToolStrip.Size = new System.Drawing.Size(520, 25);
            this.tsToolStrip.TabIndex = 7;
            this.tsToolStrip.Text = "toolStrip1";
            // 
            // tslSerialPort
            // 
            this.tslSerialPort.Name = "tslSerialPort";
            this.tslSerialPort.Size = new System.Drawing.Size(60, 22);
            this.tslSerialPort.Text = "Serial Port";
            // 
            // tscSerialPorts
            // 
            this.tscSerialPorts.Name = "tscSerialPorts";
            this.tscSerialPorts.Size = new System.Drawing.Size(75, 25);
            // 
            // tsbRefreshPorts
            // 
            this.tsbRefreshPorts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshPorts.Image = global::Trixter.XDream.Diagnostics.Properties.Resources.Refresh;
            this.tsbRefreshPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshPorts.Name = "tsbRefreshPorts";
            this.tsbRefreshPorts.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshPorts.Text = "toolStripButton1";
            this.tsbRefreshPorts.Click += new System.EventHandler(this.tsbRefreshPorts_Click);
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(56, 22);
            this.tsbConnect.Text = "Connect";
            this.tsbConnect.Click += new System.EventHandler(this.tsbConnect_Click);
            // 
            // tsbDisconnect
            // 
            this.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisconnect.Image")));
            this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnect.Name = "tsbDisconnect";
            this.tsbDisconnect.Size = new System.Drawing.Size(70, 22);
            this.tsbDisconnect.Text = "Disconnect";
            this.tsbDisconnect.Click += new System.EventHandler(this.tsbDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tpDetails);
            this.tcTabs.Controls.Add(this.tpDriver);
            this.tcTabs.Location = new System.Drawing.Point(3, 28);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(518, 472);
            this.tcTabs.TabIndex = 8;
            this.tcTabs.SelectedIndexChanged += new System.EventHandler(this.tcTabs_SelectedIndexChanged);
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.gbOutput);
            this.tpDetails.Controls.Add(this.gbInput);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(510, 446);
            this.tpDetails.TabIndex = 0;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // tpDriver
            // 
            this.tpDriver.Controls.Add(this.gbGroupPolicy);
            this.tpDriver.Location = new System.Drawing.Point(4, 22);
            this.tpDriver.Name = "tpDriver";
            this.tpDriver.Padding = new System.Windows.Forms.Padding(3);
            this.tpDriver.Size = new System.Drawing.Size(510, 446);
            this.tpDriver.TabIndex = 2;
            this.tpDriver.Text = "Driver";
            this.tpDriver.UseVisualStyleBackColor = true;
            // 
            // gbGroupPolicy
            // 
            this.gbGroupPolicy.Controls.Add(this.lbExplanation);
            this.gbGroupPolicy.Controls.Add(this.lblOpinion);
            this.gbGroupPolicy.Controls.Add(this.label3);
            this.gbGroupPolicy.Controls.Add(this.pnBlocking);
            this.gbGroupPolicy.Controls.Add(this.cbRetroactive);
            this.gbGroupPolicy.Controls.Add(this.cbBlocking);
            this.gbGroupPolicy.Controls.Add(this.lbSummary);
            this.gbGroupPolicy.Controls.Add(this.label1);
            this.gbGroupPolicy.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGroupPolicy.Location = new System.Drawing.Point(3, 3);
            this.gbGroupPolicy.Name = "gbGroupPolicy";
            this.gbGroupPolicy.Size = new System.Drawing.Size(504, 436);
            this.gbGroupPolicy.TabIndex = 20;
            this.gbGroupPolicy.TabStop = false;
            this.gbGroupPolicy.Text = "Group Policy";
            // 
            // lblOpinion
            // 
            this.lblOpinion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOpinion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpinion.Location = new System.Drawing.Point(80, 216);
            this.lblOpinion.Name = "lblOpinion";
            this.lblOpinion.Size = new System.Drawing.Size(410, 40);
            this.lblOpinion.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Opinion";
            // 
            // pnBlocking
            // 
            this.pnBlocking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBlocking.Controls.Add(this.lbXDreamDevices);
            this.pnBlocking.Controls.Add(this.lbDevices);
            this.pnBlocking.Location = new System.Drawing.Point(14, 284);
            this.pnBlocking.Name = "pnBlocking";
            this.pnBlocking.Size = new System.Drawing.Size(476, 137);
            this.pnBlocking.TabIndex = 24;
            // 
            // lbXDreamDevices
            // 
            this.lbXDreamDevices.AutoSize = true;
            this.lbXDreamDevices.Location = new System.Drawing.Point(7, 4);
            this.lbXDreamDevices.Name = "lbXDreamDevices";
            this.lbXDreamDevices.Size = new System.Drawing.Size(180, 13);
            this.lbXDreamDevices.TabIndex = 8;
            this.lbXDreamDevices.Text = "Known X-Dream Devices Registered";
            // 
            // lbDevices
            // 
            this.lbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.IntegralHeight = false;
            this.lbDevices.Location = new System.Drawing.Point(10, 23);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(458, 111);
            this.lbDevices.TabIndex = 6;
            // 
            // cbRetroactive
            // 
            this.cbRetroactive.AutoCheck = false;
            this.cbRetroactive.AutoSize = true;
            this.cbRetroactive.Location = new System.Drawing.Point(139, 261);
            this.cbRetroactive.Name = "cbRetroactive";
            this.cbRetroactive.Size = new System.Drawing.Size(125, 17);
            this.cbRetroactive.TabIndex = 21;
            this.cbRetroactive.Text = "Retroactive Blocking";
            this.cbRetroactive.UseVisualStyleBackColor = true;
            // 
            // cbBlocking
            // 
            this.cbBlocking.AutoCheck = false;
            this.cbBlocking.AutoSize = true;
            this.cbBlocking.Location = new System.Drawing.Point(24, 261);
            this.cbBlocking.Name = "cbBlocking";
            this.cbBlocking.Size = new System.Drawing.Size(109, 17);
            this.cbBlocking.TabIndex = 23;
            this.cbBlocking.Text = "Blocking Enabled";
            this.cbBlocking.UseVisualStyleBackColor = true;
            // 
            // lbSummary
            // 
            this.lbSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSummary.Location = new System.Drawing.Point(80, 171);
            this.lbSummary.Name = "lbSummary";
            this.lbSummary.Size = new System.Drawing.Size(410, 40);
            this.lbSummary.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Summary";
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
            // lbExplanation
            // 
            this.lbExplanation.Location = new System.Drawing.Point(11, 24);
            this.lbExplanation.Name = "lbExplanation";
            this.lbExplanation.Size = new System.Drawing.Size(479, 137);
            this.lbExplanation.TabIndex = 27;
            this.lbExplanation.Text = resources.GetString("lbExplanation.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 501);
            this.Controls.Add(this.tcTabs);
            this.Controls.Add(this.tsToolStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "X-Dream Bike Diagnostic UI";
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.pnRawData.ResumeLayout(false);
            this.pnRawData.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.tsToolStrip.ResumeLayout(false);
            this.tsToolStrip.PerformLayout();
            this.tcTabs.ResumeLayout(false);
            this.tpDetails.ResumeLayout(false);
            this.tpDriver.ResumeLayout(false);
            this.gbGroupPolicy.ResumeLayout(false);
            this.gbGroupPolicy.PerformLayout();
            this.pnBlocking.ResumeLayout(false);
            this.pnBlocking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbResistance;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lbResistance;
        private System.Windows.Forms.CheckedListBox clbButtons;
        private System.Windows.Forms.Label lbButtons;
        private System.Windows.Forms.Label lbFlywheel;
        private System.Windows.Forms.Label lbCrankPos;
        private System.Windows.Forms.Label lbRightBrake;
        private System.Windows.Forms.Label lbLeftBrake;
        private System.Windows.Forms.Label lbSteering;
        private System.Windows.Forms.Label lbFlywheelSpeedValue;
        private System.Windows.Forms.Label lbCrankPositionValue;
        private System.Windows.Forms.Label lbRightBrakeValue;
        private System.Windows.Forms.Label lbLeftBrakeValue;
        private System.Windows.Forms.Label lbSteeringValue;
        private System.Windows.Forms.Label lbCrankSpeedValue;
        private System.Windows.Forms.Label lbHeartRateValue;
        private System.Windows.Forms.Label lbHeartRate;
        private System.Windows.Forms.Label lbCrankSpeed;
        private System.Windows.Forms.CheckBox cbApplyBrakes;
        private ValueBar vbActualResistance;
        private System.Windows.Forms.Label lbCrankDirection;
        private System.Windows.Forms.Label lbCrankDirectionValue;
        private ValueBar vbRightBrake;
        private ValueBar vbLeftBrake;
        private ValueBar vbSteering;
        private System.Windows.Forms.Label lbCrankRevs;
        private System.Windows.Forms.Label lbCrankRevsValue;
        private System.Windows.Forms.Label lbFlywheelRevs;
        private System.Windows.Forms.Label lbFlywheelRevsValue;
        private System.Windows.Forms.Label lbAppliedResistance;
        private System.Windows.Forms.Label lbPower;
        private System.Windows.Forms.Label lbPowerValue;
        private System.Windows.Forms.Panel pnRawData;
        private System.Windows.Forms.Label lbCrankTimeValue;
        private System.Windows.Forms.Label lbFlywheelTime;
        private System.Windows.Forms.Label lbFlywheelTimeValue;
        private System.Windows.Forms.Label lbCrankTime;
        private System.Windows.Forms.CheckBox cbRawData;
        private System.Windows.Forms.Label lbTotalPower;
        private System.Windows.Forms.Label lbTotalPowerValue;
        private System.Windows.Forms.ToolStrip tsToolStrip;
        private System.Windows.Forms.ToolStripLabel tslSerialPort;
        private System.Windows.Forms.ToolStripComboBox tscSerialPorts;
        private System.Windows.Forms.ToolStripButton tsbRefreshPorts;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton tsbDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.TabPage tpDriver;
        private System.Windows.Forms.GroupBox gbGroupPolicy;
        private System.Windows.Forms.Label lblOpinion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnBlocking;
        private System.Windows.Forms.Label lbXDreamDevices;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.CheckBox cbRetroactive;
        private System.Windows.Forms.CheckBox cbBlocking;
        private System.Windows.Forms.Label lbSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbExplanation;
    }
}

