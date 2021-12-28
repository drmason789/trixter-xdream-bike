
namespace Trixter.XDream.TestController
{
    partial class ControllerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
            this.bnGreen = new System.Windows.Forms.Button();
            this.bnRed = new System.Windows.Forms.Button();
            this.bnBlue = new System.Windows.Forms.Button();
            this.bnUp = new System.Windows.Forms.Button();
            this.bnRight = new System.Windows.Forms.Button();
            this.bnLeft = new System.Windows.Forms.Button();
            this.bnDown = new System.Windows.Forms.Button();
            this.tbFlywheelSpeed = new System.Windows.Forms.TrackBar();
            this.cbSeated = new System.Windows.Forms.CheckBox();
            this.tbSteering = new System.Windows.Forms.TrackBar();
            this.bnLeftGearUp = new System.Windows.Forms.Button();
            this.bnLeftGearDown = new System.Windows.Forms.Button();
            this.bnRightGearDown = new System.Windows.Forms.Button();
            this.bnRightGearUp = new System.Windows.Forms.Button();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.nudLeftBrake = new System.Windows.Forms.NumericUpDown();
            this.nudRightBrake = new System.Windows.Forms.NumericUpDown();
            this.tbBothBrakes = new System.Windows.Forms.TrackBar();
            this.tbRightBrake = new System.Windows.Forms.TrackBar();
            this.tbLeftBrake = new System.Windows.Forms.TrackBar();
            this.nudFlywheelRevTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbResistanceValue = new System.Windows.Forms.Label();
            this.lbResistance = new System.Windows.Forms.Label();
            this.nudRPM = new System.Windows.Forms.NumericUpDown();
            this.gbFlywheel = new System.Windows.Forms.GroupBox();
            this.lbRPM = new System.Windows.Forms.Label();
            this.lbFlywheelRevTime = new System.Windows.Forms.Label();
            this.gbCrank = new System.Windows.Forms.GroupBox();
            this.lbPosition = new System.Windows.Forms.Label();
            this.nudCrankPosition = new System.Windows.Forms.NumericUpDown();
            this.lbCrankRPM = new System.Windows.Forms.Label();
            this.lbRevolutionTime = new System.Windows.Forms.Label();
            this.nudCrankRPM = new System.Windows.Forms.NumericUpDown();
            this.tbCrankSpeed = new System.Windows.Forms.TrackBar();
            this.nudCrankRevTime = new System.Windows.Forms.NumericUpDown();
            this.lbLeftGears = new System.Windows.Forms.Label();
            this.lbRightGears = new System.Windows.Forms.Label();
            this.lbRightBrake = new System.Windows.Forms.Label();
            this.lbLeftBrake = new System.Windows.Forms.Label();
            this.lbBothBrakes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbFlywheelSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSteering)).BeginInit();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBothBrakes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRightBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlywheelRevTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRPM)).BeginInit();
            this.gbFlywheel.SuspendLayout();
            this.gbCrank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCrankSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRevTime)).BeginInit();
            this.SuspendLayout();
            // 
            // bnGreen
            // 
            this.bnGreen.BackColor = System.Drawing.Color.Green;
            this.bnGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.bnGreen.Location = new System.Drawing.Point(265, 216);
            this.bnGreen.Name = "bnGreen";
            this.bnGreen.Size = new System.Drawing.Size(64, 25);
            this.bnGreen.TabIndex = 0;
            this.bnGreen.Text = "Select";
            this.bnGreen.UseVisualStyleBackColor = false;
            this.bnGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnGreen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnGreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnGreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnRed
            // 
            this.bnRed.BackColor = System.Drawing.Color.Red;
            this.bnRed.ForeColor = System.Drawing.SystemColors.Window;
            this.bnRed.Location = new System.Drawing.Point(197, 215);
            this.bnRed.Name = "bnRed";
            this.bnRed.Size = new System.Drawing.Size(64, 25);
            this.bnRed.TabIndex = 1;
            this.bnRed.Text = "Cancel";
            this.bnRed.UseVisualStyleBackColor = false;
            this.bnRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnRed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnRed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnBlue
            // 
            this.bnBlue.BackColor = System.Drawing.Color.Blue;
            this.bnBlue.ForeColor = System.Drawing.SystemColors.Window;
            this.bnBlue.Location = new System.Drawing.Point(233, 187);
            this.bnBlue.Name = "bnBlue";
            this.bnBlue.Size = new System.Drawing.Size(64, 25);
            this.bnBlue.TabIndex = 2;
            this.bnBlue.Text = "View";
            this.bnBlue.UseVisualStyleBackColor = false;
            this.bnBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnBlue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnBlue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnUp
            // 
            this.bnUp.Location = new System.Drawing.Point(84, 179);
            this.bnUp.Name = "bnUp";
            this.bnUp.Size = new System.Drawing.Size(64, 20);
            this.bnUp.TabIndex = 3;
            this.bnUp.Text = "Up";
            this.bnUp.UseVisualStyleBackColor = true;
            this.bnUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnUp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnRight
            // 
            this.bnRight.Location = new System.Drawing.Point(118, 203);
            this.bnRight.Name = "bnRight";
            this.bnRight.Size = new System.Drawing.Size(64, 20);
            this.bnRight.TabIndex = 4;
            this.bnRight.Text = "Right";
            this.bnRight.UseVisualStyleBackColor = true;
            this.bnRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnLeft
            // 
            this.bnLeft.Location = new System.Drawing.Point(50, 203);
            this.bnLeft.Name = "bnLeft";
            this.bnLeft.Size = new System.Drawing.Size(64, 20);
            this.bnLeft.TabIndex = 5;
            this.bnLeft.Text = "Left";
            this.bnLeft.UseVisualStyleBackColor = true;
            this.bnLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnDown
            // 
            this.bnDown.Location = new System.Drawing.Point(84, 227);
            this.bnDown.Name = "bnDown";
            this.bnDown.Size = new System.Drawing.Size(64, 20);
            this.bnDown.TabIndex = 6;
            this.bnDown.Text = "Down";
            this.bnDown.UseVisualStyleBackColor = true;
            this.bnDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // tbFlywheelSpeed
            // 
            this.tbFlywheelSpeed.Location = new System.Drawing.Point(6, 19);
            this.tbFlywheelSpeed.Maximum = 1000;
            this.tbFlywheelSpeed.Name = "tbFlywheelSpeed";
            this.tbFlywheelSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbFlywheelSpeed.Size = new System.Drawing.Size(45, 247);
            this.tbFlywheelSpeed.TabIndex = 7;
            this.tbFlywheelSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbFlywheelSpeed.ValueChanged += new System.EventHandler(this.tbFlywheelSpeed_ValueChanged);
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Location = new System.Drawing.Point(299, 250);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(60, 17);
            this.cbSeated.TabIndex = 8;
            this.cbSeated.Text = "Seated";
            this.cbSeated.UseVisualStyleBackColor = true;
            this.cbSeated.CheckedChanged += new System.EventHandler(this.cbSeated_CheckedChanged);
            // 
            // tbSteering
            // 
            this.tbSteering.AutoSize = false;
            this.tbSteering.Location = new System.Drawing.Point(16, 79);
            this.tbSteering.Maximum = 255;
            this.tbSteering.Name = "tbSteering";
            this.tbSteering.Size = new System.Drawing.Size(333, 30);
            this.tbSteering.TabIndex = 9;
            this.tbSteering.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSteering.Value = 128;
            this.tbSteering.ValueChanged += new System.EventHandler(this.tbSteering_ValueChanged);
            this.tbSteering.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbSteering_MouseUp);
            // 
            // bnLeftGearUp
            // 
            this.bnLeftGearUp.Location = new System.Drawing.Point(15, 120);
            this.bnLeftGearUp.Name = "bnLeftGearUp";
            this.bnLeftGearUp.Size = new System.Drawing.Size(64, 20);
            this.bnLeftGearUp.TabIndex = 10;
            this.bnLeftGearUp.Text = "Up";
            this.bnLeftGearUp.UseVisualStyleBackColor = true;
            this.bnLeftGearUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnLeftGearUp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnLeftGearUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnLeftGearUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnLeftGearDown
            // 
            this.bnLeftGearDown.Location = new System.Drawing.Point(15, 145);
            this.bnLeftGearDown.Name = "bnLeftGearDown";
            this.bnLeftGearDown.Size = new System.Drawing.Size(64, 20);
            this.bnLeftGearDown.TabIndex = 11;
            this.bnLeftGearDown.Text = "Down";
            this.bnLeftGearDown.UseVisualStyleBackColor = true;
            this.bnLeftGearDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnLeftGearDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnLeftGearDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnLeftGearDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnRightGearDown
            // 
            this.bnRightGearDown.Location = new System.Drawing.Point(285, 145);
            this.bnRightGearDown.Name = "bnRightGearDown";
            this.bnRightGearDown.Size = new System.Drawing.Size(64, 20);
            this.bnRightGearDown.TabIndex = 13;
            this.bnRightGearDown.Text = "Down";
            this.bnRightGearDown.UseVisualStyleBackColor = true;
            this.bnRightGearDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnRightGearDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnRightGearDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnRightGearDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // bnRightGearUp
            // 
            this.bnRightGearUp.Location = new System.Drawing.Point(285, 120);
            this.bnRightGearUp.Name = "bnRightGearUp";
            this.bnRightGearUp.Size = new System.Drawing.Size(64, 20);
            this.bnRightGearUp.TabIndex = 12;
            this.bnRightGearUp.Text = "Up";
            this.bnRightGearUp.UseVisualStyleBackColor = true;
            this.bnRightGearUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyDown);
            this.bnRightGearUp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bnButton_KeyUp);
            this.bnRightGearUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnButton_Pressed);
            this.bnRightGearUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bnButton_Released);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.lbBothBrakes);
            this.gbControls.Controls.Add(this.lbRightBrake);
            this.gbControls.Controls.Add(this.lbLeftBrake);
            this.gbControls.Controls.Add(this.lbRightGears);
            this.gbControls.Controls.Add(this.lbLeftGears);
            this.gbControls.Controls.Add(this.nudLeftBrake);
            this.gbControls.Controls.Add(this.nudRightBrake);
            this.gbControls.Controls.Add(this.tbBothBrakes);
            this.gbControls.Controls.Add(this.tbRightBrake);
            this.gbControls.Controls.Add(this.tbLeftBrake);
            this.gbControls.Controls.Add(this.tbSteering);
            this.gbControls.Controls.Add(this.bnRightGearDown);
            this.gbControls.Controls.Add(this.bnGreen);
            this.gbControls.Controls.Add(this.bnRightGearUp);
            this.gbControls.Controls.Add(this.bnRed);
            this.gbControls.Controls.Add(this.cbSeated);
            this.gbControls.Controls.Add(this.bnLeftGearDown);
            this.gbControls.Controls.Add(this.bnBlue);
            this.gbControls.Controls.Add(this.bnLeftGearUp);
            this.gbControls.Controls.Add(this.bnUp);
            this.gbControls.Controls.Add(this.bnRight);
            this.gbControls.Controls.Add(this.bnLeft);
            this.gbControls.Controls.Add(this.bnDown);
            this.gbControls.Location = new System.Drawing.Point(12, 12);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(365, 273);
            this.gbControls.TabIndex = 14;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // nudLeftBrake
            // 
            this.nudLeftBrake.Location = new System.Drawing.Point(47, 50);
            this.nudLeftBrake.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudLeftBrake.Minimum = new decimal(new int[] {
            135,
            0,
            0,
            0});
            this.nudLeftBrake.Name = "nudLeftBrake";
            this.nudLeftBrake.Size = new System.Drawing.Size(50, 20);
            this.nudLeftBrake.TabIndex = 18;
            this.nudLeftBrake.Value = new decimal(new int[] {
            135,
            0,
            0,
            0});
            this.nudLeftBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            // 
            // nudRightBrake
            // 
            this.nudRightBrake.Location = new System.Drawing.Point(255, 50);
            this.nudRightBrake.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudRightBrake.Minimum = new decimal(new int[] {
            135,
            0,
            0,
            0});
            this.nudRightBrake.Name = "nudRightBrake";
            this.nudRightBrake.Size = new System.Drawing.Size(53, 20);
            this.nudRightBrake.TabIndex = 17;
            this.nudRightBrake.Value = new decimal(new int[] {
            135,
            0,
            0,
            0});
            this.nudRightBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            // 
            // tbBothBrakes
            // 
            this.tbBothBrakes.Location = new System.Drawing.Point(162, 28);
            this.tbBothBrakes.Maximum = 250;
            this.tbBothBrakes.Minimum = 135;
            this.tbBothBrakes.Name = "tbBothBrakes";
            this.tbBothBrakes.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBothBrakes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbBothBrakes.Size = new System.Drawing.Size(45, 53);
            this.tbBothBrakes.TabIndex = 16;
            this.tbBothBrakes.TickFrequency = 10;
            this.tbBothBrakes.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbBothBrakes.Value = 135;
            this.tbBothBrakes.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbBothBrakes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // tbRightBrake
            // 
            this.tbRightBrake.Location = new System.Drawing.Point(314, 28);
            this.tbRightBrake.Maximum = 250;
            this.tbRightBrake.Minimum = 135;
            this.tbRightBrake.Name = "tbRightBrake";
            this.tbRightBrake.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbRightBrake.Size = new System.Drawing.Size(45, 53);
            this.tbRightBrake.TabIndex = 15;
            this.tbRightBrake.TickFrequency = 10;
            this.tbRightBrake.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbRightBrake.Value = 135;
            this.tbRightBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbRightBrake.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // tbLeftBrake
            // 
            this.tbLeftBrake.Location = new System.Drawing.Point(16, 28);
            this.tbLeftBrake.Maximum = 250;
            this.tbLeftBrake.Minimum = 135;
            this.tbLeftBrake.Name = "tbLeftBrake";
            this.tbLeftBrake.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbLeftBrake.Size = new System.Drawing.Size(45, 53);
            this.tbLeftBrake.TabIndex = 14;
            this.tbLeftBrake.TickFrequency = 10;
            this.tbLeftBrake.Value = 135;
            this.tbLeftBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbLeftBrake.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // nudFlywheelRevTime
            // 
            this.nudFlywheelRevTime.Location = new System.Drawing.Point(66, 49);
            this.nudFlywheelRevTime.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudFlywheelRevTime.Minimum = new decimal(new int[] {
            288,
            0,
            0,
            0});
            this.nudFlywheelRevTime.Name = "nudFlywheelRevTime";
            this.nudFlywheelRevTime.Size = new System.Drawing.Size(72, 20);
            this.nudFlywheelRevTime.TabIndex = 14;
            this.nudFlywheelRevTime.Value = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudFlywheelRevTime.ValueChanged += new System.EventHandler(this.nudFlywheelRevTime_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbResistanceValue);
            this.groupBox1.Controls.Add(this.lbResistance);
            this.groupBox1.Location = new System.Drawing.Point(714, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 272);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Client";
            // 
            // lbResistanceValue
            // 
            this.lbResistanceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResistanceValue.Location = new System.Drawing.Point(20, 47);
            this.lbResistanceValue.Name = "lbResistanceValue";
            this.lbResistanceValue.Size = new System.Drawing.Size(52, 20);
            this.lbResistanceValue.TabIndex = 1;
            this.lbResistanceValue.Text = "0";
            this.lbResistanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbResistance
            // 
            this.lbResistance.AutoSize = true;
            this.lbResistance.Location = new System.Drawing.Point(17, 27);
            this.lbResistance.Name = "lbResistance";
            this.lbResistance.Size = new System.Drawing.Size(60, 13);
            this.lbResistance.TabIndex = 0;
            this.lbResistance.Text = "Resistance";
            // 
            // nudRPM
            // 
            this.nudRPM.Location = new System.Drawing.Point(67, 98);
            this.nudRPM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudRPM.Name = "nudRPM";
            this.nudRPM.Size = new System.Drawing.Size(72, 20);
            this.nudRPM.TabIndex = 15;
            this.nudRPM.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudRPM.ValueChanged += new System.EventHandler(this.tbFlywheelSpeed_ValueChanged);
            // 
            // gbFlywheel
            // 
            this.gbFlywheel.Controls.Add(this.lbRPM);
            this.gbFlywheel.Controls.Add(this.lbFlywheelRevTime);
            this.gbFlywheel.Controls.Add(this.nudRPM);
            this.gbFlywheel.Controls.Add(this.tbFlywheelSpeed);
            this.gbFlywheel.Controls.Add(this.nudFlywheelRevTime);
            this.gbFlywheel.Location = new System.Drawing.Point(548, 13);
            this.gbFlywheel.Name = "gbFlywheel";
            this.gbFlywheel.Size = new System.Drawing.Size(160, 272);
            this.gbFlywheel.TabIndex = 16;
            this.gbFlywheel.TabStop = false;
            this.gbFlywheel.Text = "Flywheel";
            // 
            // lbRPM
            // 
            this.lbRPM.AutoSize = true;
            this.lbRPM.Location = new System.Drawing.Point(64, 78);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(31, 13);
            this.lbRPM.TabIndex = 17;
            this.lbRPM.Text = "RPM";
            // 
            // lbFlywheelRevTime
            // 
            this.lbFlywheelRevTime.AutoSize = true;
            this.lbFlywheelRevTime.Location = new System.Drawing.Point(63, 29);
            this.lbFlywheelRevTime.Name = "lbFlywheelRevTime";
            this.lbFlywheelRevTime.Size = new System.Drawing.Size(84, 13);
            this.lbFlywheelRevTime.TabIndex = 16;
            this.lbFlywheelRevTime.Text = "Revolution Time";
            // 
            // gbCrank
            // 
            this.gbCrank.Controls.Add(this.lbPosition);
            this.gbCrank.Controls.Add(this.nudCrankPosition);
            this.gbCrank.Controls.Add(this.lbCrankRPM);
            this.gbCrank.Controls.Add(this.lbRevolutionTime);
            this.gbCrank.Controls.Add(this.nudCrankRPM);
            this.gbCrank.Controls.Add(this.tbCrankSpeed);
            this.gbCrank.Controls.Add(this.nudCrankRevTime);
            this.gbCrank.Location = new System.Drawing.Point(383, 12);
            this.gbCrank.Name = "gbCrank";
            this.gbCrank.Size = new System.Drawing.Size(158, 273);
            this.gbCrank.TabIndex = 17;
            this.gbCrank.TabStop = false;
            this.gbCrank.Text = "Crank";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(63, 125);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(75, 13);
            this.lbPosition.TabIndex = 24;
            this.lbPosition.Text = "Crank Position";
            // 
            // nudCrankPosition
            // 
            this.nudCrankPosition.Location = new System.Drawing.Point(66, 145);
            this.nudCrankPosition.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudCrankPosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCrankPosition.Name = "nudCrankPosition";
            this.nudCrankPosition.Size = new System.Drawing.Size(72, 20);
            this.nudCrankPosition.TabIndex = 23;
            this.nudCrankPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbCrankRPM
            // 
            this.lbCrankRPM.AutoSize = true;
            this.lbCrankRPM.Location = new System.Drawing.Point(64, 78);
            this.lbCrankRPM.Name = "lbCrankRPM";
            this.lbCrankRPM.Size = new System.Drawing.Size(31, 13);
            this.lbCrankRPM.TabIndex = 22;
            this.lbCrankRPM.Text = "RPM";
            // 
            // lbRevolutionTime
            // 
            this.lbRevolutionTime.AutoSize = true;
            this.lbRevolutionTime.Location = new System.Drawing.Point(63, 29);
            this.lbRevolutionTime.Name = "lbRevolutionTime";
            this.lbRevolutionTime.Size = new System.Drawing.Size(84, 13);
            this.lbRevolutionTime.TabIndex = 21;
            this.lbRevolutionTime.Text = "Revolution Time";
            // 
            // nudCrankRPM
            // 
            this.nudCrankRPM.Location = new System.Drawing.Point(67, 98);
            this.nudCrankRPM.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudCrankRPM.Name = "nudCrankRPM";
            this.nudCrankRPM.Size = new System.Drawing.Size(72, 20);
            this.nudCrankRPM.TabIndex = 20;
            this.nudCrankRPM.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudCrankRPM.ValueChanged += new System.EventHandler(this.tbCrankSpeed_ValueChanged);
            // 
            // tbCrankSpeed
            // 
            this.tbCrankSpeed.Location = new System.Drawing.Point(6, 19);
            this.tbCrankSpeed.Maximum = 300;
            this.tbCrankSpeed.Name = "tbCrankSpeed";
            this.tbCrankSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbCrankSpeed.Size = new System.Drawing.Size(45, 247);
            this.tbCrankSpeed.TabIndex = 18;
            this.tbCrankSpeed.TickFrequency = 5;
            this.tbCrankSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbCrankSpeed.ValueChanged += new System.EventHandler(this.tbCrankSpeed_ValueChanged);
            // 
            // nudCrankRevTime
            // 
            this.nudCrankRevTime.Location = new System.Drawing.Point(66, 49);
            this.nudCrankRevTime.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudCrankRevTime.Name = "nudCrankRevTime";
            this.nudCrankRevTime.Size = new System.Drawing.Size(72, 20);
            this.nudCrankRevTime.TabIndex = 19;
            // 
            // lbLeftGears
            // 
            this.lbLeftGears.AutoSize = true;
            this.lbLeftGears.Location = new System.Drawing.Point(16, 101);
            this.lbLeftGears.Name = "lbLeftGears";
            this.lbLeftGears.Size = new System.Drawing.Size(89, 13);
            this.lbLeftGears.TabIndex = 19;
            this.lbLeftGears.Text = "Left (Front) Gears";
            // 
            // lbRightGears
            // 
            this.lbRightGears.AutoSize = true;
            this.lbRightGears.Location = new System.Drawing.Point(252, 101);
            this.lbRightGears.Name = "lbRightGears";
            this.lbRightGears.Size = new System.Drawing.Size(97, 13);
            this.lbRightGears.TabIndex = 20;
            this.lbRightGears.Text = "Right (Back) Gears";
            this.lbRightGears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRightBrake
            // 
            this.lbRightBrake.AutoSize = true;
            this.lbRightBrake.Location = new System.Drawing.Point(282, 19);
            this.lbRightBrake.Name = "lbRightBrake";
            this.lbRightBrake.Size = new System.Drawing.Size(63, 13);
            this.lbRightBrake.TabIndex = 22;
            this.lbRightBrake.Text = "Right Brake";
            this.lbRightBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftBrake
            // 
            this.lbLeftBrake.AutoSize = true;
            this.lbLeftBrake.Location = new System.Drawing.Point(17, 18);
            this.lbLeftBrake.Name = "lbLeftBrake";
            this.lbLeftBrake.Size = new System.Drawing.Size(56, 13);
            this.lbLeftBrake.TabIndex = 21;
            this.lbLeftBrake.Text = "Left Brake";
            // 
            // lbBothBrakes
            // 
            this.lbBothBrakes.AutoSize = true;
            this.lbBothBrakes.Location = new System.Drawing.Point(159, 16);
            this.lbBothBrakes.Name = "lbBothBrakes";
            this.lbBothBrakes.Size = new System.Drawing.Size(65, 13);
            this.lbBothBrakes.TabIndex = 23;
            this.lbBothBrakes.Text = "Both Brakes";
            this.lbBothBrakes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 291);
            this.Controls.Add(this.gbCrank);
            this.Controls.Add(this.gbFlywheel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControllerForm";
            this.Text = "X-Dream Bike Emulator";
            ((System.ComponentModel.ISupportInitialize)(this.tbFlywheelSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSteering)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBothBrakes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRightBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlywheelRevTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRPM)).EndInit();
            this.gbFlywheel.ResumeLayout(false);
            this.gbFlywheel.PerformLayout();
            this.gbCrank.ResumeLayout(false);
            this.gbCrank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCrankSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRevTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnGreen;
        private System.Windows.Forms.Button bnRed;
        private System.Windows.Forms.Button bnBlue;
        private System.Windows.Forms.Button bnUp;
        private System.Windows.Forms.Button bnRight;
        private System.Windows.Forms.Button bnLeft;
        private System.Windows.Forms.Button bnDown;
        private System.Windows.Forms.TrackBar tbFlywheelSpeed;
        private System.Windows.Forms.CheckBox cbSeated;
        private System.Windows.Forms.TrackBar tbSteering;
        private System.Windows.Forms.Button bnLeftGearUp;
        private System.Windows.Forms.Button bnLeftGearDown;
        private System.Windows.Forms.Button bnRightGearDown;
        private System.Windows.Forms.Button bnRightGearUp;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbResistanceValue;
        private System.Windows.Forms.Label lbResistance;
        private System.Windows.Forms.NumericUpDown nudFlywheelRevTime;
        private System.Windows.Forms.NumericUpDown nudRPM;
        private System.Windows.Forms.GroupBox gbFlywheel;
        private System.Windows.Forms.Label lbRPM;
        private System.Windows.Forms.Label lbFlywheelRevTime;
        private System.Windows.Forms.TrackBar tbBothBrakes;
        private System.Windows.Forms.TrackBar tbRightBrake;
        private System.Windows.Forms.TrackBar tbLeftBrake;
        private System.Windows.Forms.NumericUpDown nudLeftBrake;
        private System.Windows.Forms.NumericUpDown nudRightBrake;
        private System.Windows.Forms.GroupBox gbCrank;
        private System.Windows.Forms.Label lbCrankRPM;
        private System.Windows.Forms.Label lbRevolutionTime;
        private System.Windows.Forms.NumericUpDown nudCrankRPM;
        private System.Windows.Forms.TrackBar tbCrankSpeed;
        private System.Windows.Forms.NumericUpDown nudCrankRevTime;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.NumericUpDown nudCrankPosition;
        private System.Windows.Forms.Label lbRightGears;
        private System.Windows.Forms.Label lbLeftGears;
        private System.Windows.Forms.Label lbBothBrakes;
        private System.Windows.Forms.Label lbRightBrake;
        private System.Windows.Forms.Label lbLeftBrake;
    }
}

