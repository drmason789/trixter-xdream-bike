
namespace Trixter.XDream.UI
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
            this.lbFlywheelValue = new System.Windows.Forms.Label();
            this.lbCrankPositionValue = new System.Windows.Forms.Label();
            this.lbButtons = new System.Windows.Forms.Label();
            this.lbFlywheel = new System.Windows.Forms.Label();
            this.lbCrankPos = new System.Windows.Forms.Label();
            this.lbRightBrake = new System.Windows.Forms.Label();
            this.lbLeftBrake = new System.Windows.Forms.Label();
            this.lbSteering = new System.Windows.Forms.Label();
            this.clbButtons = new System.Windows.Forms.CheckedListBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.cbApplyBrakes = new System.Windows.Forms.CheckBox();
            this.lbResistance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnRefreshPorts = new System.Windows.Forms.Button();
            this.bnDisconnect = new System.Windows.Forms.Button();
            this.bnConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.vbActualResistance = new Trixter.XDream.UI.ValueBar();
            this.vbRightBrake = new Trixter.XDream.UI.ValueBar();
            this.vbLeftBrake = new Trixter.XDream.UI.ValueBar();
            this.vbSteering = new Trixter.XDream.UI.ValueBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).BeginInit();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbResistance
            // 
            this.tbResistance.Location = new System.Drawing.Point(57, 53);
            this.tbResistance.Maximum = 250;
            this.tbResistance.Name = "tbResistance";
            this.tbResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbResistance.Size = new System.Drawing.Size(45, 370);
            this.tbResistance.TabIndex = 1;
            this.tbResistance.TickFrequency = 5;
            this.tbResistance.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbResistance.ValueChanged += new System.EventHandler(this.tbResistance_ValueChanged);
            // 
            // gbInput
            // 
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
            this.gbInput.Controls.Add(this.lbFlywheelValue);
            this.gbInput.Controls.Add(this.lbCrankPositionValue);
            this.gbInput.Controls.Add(this.lbButtons);
            this.gbInput.Controls.Add(this.lbFlywheel);
            this.gbInput.Controls.Add(this.lbCrankPos);
            this.gbInput.Controls.Add(this.lbRightBrake);
            this.gbInput.Controls.Add(this.lbLeftBrake);
            this.gbInput.Controls.Add(this.lbSteering);
            this.gbInput.Controls.Add(this.clbButtons);
            this.gbInput.Location = new System.Drawing.Point(9, 73);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(347, 432);
            this.gbInput.TabIndex = 4;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "From Device";
            // 
            // lbCrankRevs
            // 
            this.lbCrankRevs.AutoSize = true;
            this.lbCrankRevs.Location = new System.Drawing.Point(246, 205);
            this.lbCrankRevs.Name = "lbCrankRevs";
            this.lbCrankRevs.Size = new System.Drawing.Size(94, 13);
            this.lbCrankRevs.TabIndex = 38;
            this.lbCrankRevs.Text = "Crank Revolutions";
            this.lbCrankRevs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCrankRevsValue
            // 
            this.lbCrankRevsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankRevsValue.Location = new System.Drawing.Point(279, 222);
            this.lbCrankRevsValue.Name = "lbCrankRevsValue";
            this.lbCrankRevsValue.Size = new System.Drawing.Size(60, 24);
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
            this.lbHeartRateValue.Text = "300 BPM";
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
            // lbFlywheelValue
            // 
            this.lbFlywheelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheelValue.Location = new System.Drawing.Point(92, 201);
            this.lbFlywheelValue.Name = "lbFlywheelValue";
            this.lbFlywheelValue.Size = new System.Drawing.Size(120, 24);
            this.lbFlywheelValue.TabIndex = 14;
            this.lbFlywheelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.gbOutput.Controls.Add(this.vbActualResistance);
            this.gbOutput.Controls.Add(this.cbApplyBrakes);
            this.gbOutput.Controls.Add(this.lbResistance);
            this.gbOutput.Controls.Add(this.tbResistance);
            this.gbOutput.Location = new System.Drawing.Point(362, 73);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(143, 432);
            this.gbOutput.TabIndex = 5;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "To Device";
            // 
            // cbApplyBrakes
            // 
            this.cbApplyBrakes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbApplyBrakes.Checked = true;
            this.cbApplyBrakes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbApplyBrakes.Location = new System.Drawing.Point(9, 19);
            this.cbApplyBrakes.Name = "cbApplyBrakes";
            this.cbApplyBrakes.Size = new System.Drawing.Size(122, 24);
            this.cbApplyBrakes.TabIndex = 0;
            this.cbApplyBrakes.Text = "Apply Brakes";
            this.cbApplyBrakes.UseVisualStyleBackColor = true;
            // 
            // lbResistance
            // 
            this.lbResistance.AutoSize = true;
            this.lbResistance.Location = new System.Drawing.Point(9, 45);
            this.lbResistance.Name = "lbResistance";
            this.lbResistance.Size = new System.Drawing.Size(60, 13);
            this.lbResistance.TabIndex = 1;
            this.lbResistance.Text = "Resistance";
            this.lbResistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnRefreshPorts);
            this.groupBox1.Controls.Add(this.bnDisconnect);
            this.groupBox1.Controls.Add(this.bnConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbPorts);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // bnRefreshPorts
            // 
            this.bnRefreshPorts.Location = new System.Drawing.Point(192, 18);
            this.bnRefreshPorts.Name = "bnRefreshPorts";
            this.bnRefreshPorts.Size = new System.Drawing.Size(105, 23);
            this.bnRefreshPorts.TabIndex = 1;
            this.bnRefreshPorts.Text = "Refresh Port List";
            this.bnRefreshPorts.UseVisualStyleBackColor = true;
            this.bnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // bnDisconnect
            // 
            this.bnDisconnect.Location = new System.Drawing.Point(384, 18);
            this.bnDisconnect.Name = "bnDisconnect";
            this.bnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.bnDisconnect.TabIndex = 3;
            this.bnDisconnect.Text = "Disconnect";
            this.bnDisconnect.UseVisualStyleBackColor = true;
            this.bnDisconnect.Click += new System.EventHandler(this.bnDisconnect_Click);
            // 
            // bnConnect
            // 
            this.bnConnect.Location = new System.Drawing.Point(303, 18);
            this.bnConnect.Name = "bnConnect";
            this.bnConnect.Size = new System.Drawing.Size(75, 23);
            this.bnConnect.TabIndex = 2;
            this.bnConnect.Text = "Connect";
            this.bnConnect.UseVisualStyleBackColor = true;
            this.bnConnect.Click += new System.EventHandler(this.bnConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Serial Port";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(92, 19);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(94, 21);
            this.cbPorts.TabIndex = 0;
            // 
            // vbActualResistance
            // 
            this.vbActualResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vbActualResistance.ClipOutOfRangeValues = true;
            this.vbActualResistance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vbActualResistance.Location = new System.Drawing.Point(108, 60);
            this.vbActualResistance.Maximum = 250;
            this.vbActualResistance.Name = "vbActualResistance";
            this.vbActualResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.vbActualResistance.Size = new System.Drawing.Size(23, 351);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "X-Dream Bike Diagnostic UI";
            ((System.ComponentModel.ISupportInitialize)(this.tbResistance)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lbFlywheelValue;
        private System.Windows.Forms.Label lbCrankPositionValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button bnDisconnect;
        private System.Windows.Forms.Button bnConnect;
        private System.Windows.Forms.Label lbRightBrakeValue;
        private System.Windows.Forms.Label lbLeftBrakeValue;
        private System.Windows.Forms.Label lbSteeringValue;
        private System.Windows.Forms.Label lbCrankSpeedValue;
        private System.Windows.Forms.Label lbHeartRateValue;
        private System.Windows.Forms.Label lbHeartRate;
        private System.Windows.Forms.Label lbCrankSpeed;
        private System.Windows.Forms.CheckBox cbApplyBrakes;
        private ValueBar vbActualResistance;
        private System.Windows.Forms.Button bnRefreshPorts;
        private System.Windows.Forms.Label lbCrankDirection;
        private System.Windows.Forms.Label lbCrankDirectionValue;
        private ValueBar vbRightBrake;
        private ValueBar vbLeftBrake;
        private ValueBar vbSteering;
        private System.Windows.Forms.Label lbCrankRevs;
        private System.Windows.Forms.Label lbCrankRevsValue;
        private System.Windows.Forms.Label lbFlywheelRevs;
        private System.Windows.Forms.Label lbFlywheelRevsValue;
    }
}

