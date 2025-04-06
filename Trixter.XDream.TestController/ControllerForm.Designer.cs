
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
            this.lbHeartRate = new System.Windows.Forms.Label();
            this.nudHeartRate = new System.Windows.Forms.NumericUpDown();
            this.bnGamePad = new System.Windows.Forms.Button();
            this.lbBothBrakes = new System.Windows.Forms.Label();
            this.lbRightBrake = new System.Windows.Forms.Label();
            this.lbLeftBrake = new System.Windows.Forms.Label();
            this.lbRightGears = new System.Windows.Forms.Label();
            this.lbLeftGears = new System.Windows.Forms.Label();
            this.nudLeftBrake = new System.Windows.Forms.NumericUpDown();
            this.nudRightBrake = new System.Windows.Forms.NumericUpDown();
            this.tbBothBrakes = new System.Windows.Forms.TrackBar();
            this.tbRightBrake = new System.Windows.Forms.TrackBar();
            this.tbLeftBrake = new System.Windows.Forms.TrackBar();
            this.nudFlywheelRevTime = new System.Windows.Forms.NumericUpDown();
            this.gbResistance = new System.Windows.Forms.GroupBox();
            this.lb0 = new System.Windows.Forms.Label();
            this.lb250 = new System.Windows.Forms.Label();
            this.vblResistance = new Trixter.XDream.Diagnostics.Controls.ValueBar();
            this.lbRequestsPerSecond = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tsToolStrip = new System.Windows.Forms.ToolStrip();
            this.tslSerialPort = new System.Windows.Forms.ToolStripLabel();
            this.tscSerialPorts = new System.Windows.Forms.ToolStripComboBox();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.tbFlywheelSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSteering)).BeginInit();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBothBrakes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRightBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlywheelRevTime)).BeginInit();
            this.gbResistance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRPM)).BeginInit();
            this.gbFlywheel.SuspendLayout();
            this.gbCrank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCrankSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRevTime)).BeginInit();
            this.tsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnGreen
            // 
            this.bnGreen.BackColor = System.Drawing.Color.Green;
            this.bnGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.bnGreen.Location = new System.Drawing.Point(398, 332);
            this.bnGreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnGreen.Name = "bnGreen";
            this.bnGreen.Size = new System.Drawing.Size(96, 38);
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
            this.bnRed.Location = new System.Drawing.Point(296, 331);
            this.bnRed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRed.Name = "bnRed";
            this.bnRed.Size = new System.Drawing.Size(96, 38);
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
            this.bnBlue.Location = new System.Drawing.Point(350, 288);
            this.bnBlue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnBlue.Name = "bnBlue";
            this.bnBlue.Size = new System.Drawing.Size(96, 38);
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
            this.bnUp.Location = new System.Drawing.Point(126, 275);
            this.bnUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnUp.Name = "bnUp";
            this.bnUp.Size = new System.Drawing.Size(96, 31);
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
            this.bnRight.Location = new System.Drawing.Point(177, 312);
            this.bnRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRight.Name = "bnRight";
            this.bnRight.Size = new System.Drawing.Size(96, 31);
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
            this.bnLeft.Location = new System.Drawing.Point(75, 312);
            this.bnLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnLeft.Name = "bnLeft";
            this.bnLeft.Size = new System.Drawing.Size(96, 31);
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
            this.bnDown.Location = new System.Drawing.Point(126, 349);
            this.bnDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnDown.Name = "bnDown";
            this.bnDown.Size = new System.Drawing.Size(96, 31);
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
            this.tbFlywheelSpeed.Location = new System.Drawing.Point(9, 29);
            this.tbFlywheelSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFlywheelSpeed.Maximum = 1000;
            this.tbFlywheelSpeed.Name = "tbFlywheelSpeed";
            this.tbFlywheelSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbFlywheelSpeed.Size = new System.Drawing.Size(69, 380);
            this.tbFlywheelSpeed.TabIndex = 7;
            this.tbFlywheelSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbFlywheelSpeed.ValueChanged += new System.EventHandler(this.tbFlywheelSpeed_ValueChanged);
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Location = new System.Drawing.Point(448, 385);
            this.cbSeated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(87, 24);
            this.cbSeated.TabIndex = 8;
            this.cbSeated.Text = "Seated";
            this.cbSeated.UseVisualStyleBackColor = true;
            this.cbSeated.CheckedChanged += new System.EventHandler(this.cbSeated_CheckedChanged);
            // 
            // tbSteering
            // 
            this.tbSteering.AutoSize = false;
            this.tbSteering.Location = new System.Drawing.Point(24, 122);
            this.tbSteering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSteering.Maximum = 255;
            this.tbSteering.Name = "tbSteering";
            this.tbSteering.Size = new System.Drawing.Size(500, 46);
            this.tbSteering.TabIndex = 9;
            this.tbSteering.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSteering.Value = 128;
            this.tbSteering.ValueChanged += new System.EventHandler(this.tbSteering_ValueChanged);
            this.tbSteering.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbSteering_MouseUp);
            // 
            // bnLeftGearUp
            // 
            this.bnLeftGearUp.Location = new System.Drawing.Point(22, 185);
            this.bnLeftGearUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnLeftGearUp.Name = "bnLeftGearUp";
            this.bnLeftGearUp.Size = new System.Drawing.Size(96, 31);
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
            this.bnLeftGearDown.Location = new System.Drawing.Point(22, 223);
            this.bnLeftGearDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnLeftGearDown.Name = "bnLeftGearDown";
            this.bnLeftGearDown.Size = new System.Drawing.Size(96, 31);
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
            this.bnRightGearDown.Location = new System.Drawing.Point(428, 223);
            this.bnRightGearDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRightGearDown.Name = "bnRightGearDown";
            this.bnRightGearDown.Size = new System.Drawing.Size(96, 31);
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
            this.bnRightGearUp.Location = new System.Drawing.Point(428, 185);
            this.bnRightGearUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRightGearUp.Name = "bnRightGearUp";
            this.bnRightGearUp.Size = new System.Drawing.Size(96, 31);
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
            this.gbControls.Controls.Add(this.lbHeartRate);
            this.gbControls.Controls.Add(this.nudHeartRate);
            this.gbControls.Controls.Add(this.bnGamePad);
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
            this.gbControls.Location = new System.Drawing.Point(11, 40);
            this.gbControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControls.Name = "gbControls";
            this.gbControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbControls.Size = new System.Drawing.Size(548, 420);
            this.gbControls.TabIndex = 14;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // lbHeartRate
            // 
            this.lbHeartRate.AutoSize = true;
            this.lbHeartRate.Location = new System.Drawing.Point(177, 192);
            this.lbHeartRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHeartRate.Name = "lbHeartRate";
            this.lbHeartRate.Size = new System.Drawing.Size(126, 20);
            this.lbHeartRate.TabIndex = 26;
            this.lbHeartRate.Text = "Heart Rate BPM";
            // 
            // nudHeartRate
            // 
            this.nudHeartRate.Location = new System.Drawing.Point(234, 217);
            this.nudHeartRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudHeartRate.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudHeartRate.Name = "nudHeartRate";
            this.nudHeartRate.Size = new System.Drawing.Size(76, 26);
            this.nudHeartRate.TabIndex = 25;
            this.nudHeartRate.ValueChanged += new System.EventHandler(this.nudHeartRate_ValueChanged);
            // 
            // bnGamePad
            // 
            this.bnGamePad.Location = new System.Drawing.Point(9, 368);
            this.bnGamePad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnGamePad.Name = "bnGamePad";
            this.bnGamePad.Size = new System.Drawing.Size(100, 40);
            this.bnGamePad.TabIndex = 24;
            this.bnGamePad.Text = "Gamepad";
            this.bnGamePad.UseVisualStyleBackColor = true;
            this.bnGamePad.Click += new System.EventHandler(this.bnGamePad_Click);
            // 
            // lbBothBrakes
            // 
            this.lbBothBrakes.AutoSize = true;
            this.lbBothBrakes.Location = new System.Drawing.Point(238, 25);
            this.lbBothBrakes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBothBrakes.Name = "lbBothBrakes";
            this.lbBothBrakes.Size = new System.Drawing.Size(97, 20);
            this.lbBothBrakes.TabIndex = 23;
            this.lbBothBrakes.Text = "Both Brakes";
            this.lbBothBrakes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRightBrake
            // 
            this.lbRightBrake.AutoSize = true;
            this.lbRightBrake.Location = new System.Drawing.Point(423, 29);
            this.lbRightBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightBrake.Name = "lbRightBrake";
            this.lbRightBrake.Size = new System.Drawing.Size(93, 20);
            this.lbRightBrake.TabIndex = 22;
            this.lbRightBrake.Text = "Right Brake";
            this.lbRightBrake.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftBrake
            // 
            this.lbLeftBrake.AutoSize = true;
            this.lbLeftBrake.Location = new System.Drawing.Point(26, 28);
            this.lbLeftBrake.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftBrake.Name = "lbLeftBrake";
            this.lbLeftBrake.Size = new System.Drawing.Size(83, 20);
            this.lbLeftBrake.TabIndex = 21;
            this.lbLeftBrake.Text = "Left Brake";
            // 
            // lbRightGears
            // 
            this.lbRightGears.AutoSize = true;
            this.lbRightGears.Location = new System.Drawing.Point(378, 155);
            this.lbRightGears.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRightGears.Name = "lbRightGears";
            this.lbRightGears.Size = new System.Drawing.Size(145, 20);
            this.lbRightGears.TabIndex = 20;
            this.lbRightGears.Text = "Right (Back) Gears";
            this.lbRightGears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftGears
            // 
            this.lbLeftGears.AutoSize = true;
            this.lbLeftGears.Location = new System.Drawing.Point(24, 155);
            this.lbLeftGears.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLeftGears.Name = "lbLeftGears";
            this.lbLeftGears.Size = new System.Drawing.Size(137, 20);
            this.lbLeftGears.TabIndex = 19;
            this.lbLeftGears.Text = "Left (Front) Gears";
            // 
            // nudLeftBrake
            // 
            this.nudLeftBrake.Location = new System.Drawing.Point(70, 77);
            this.nudLeftBrake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudLeftBrake.Size = new System.Drawing.Size(75, 26);
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
            this.nudRightBrake.Location = new System.Drawing.Point(382, 77);
            this.nudRightBrake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudRightBrake.Size = new System.Drawing.Size(80, 26);
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
            this.tbBothBrakes.Location = new System.Drawing.Point(243, 43);
            this.tbBothBrakes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBothBrakes.Maximum = 250;
            this.tbBothBrakes.Minimum = 135;
            this.tbBothBrakes.Name = "tbBothBrakes";
            this.tbBothBrakes.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBothBrakes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbBothBrakes.Size = new System.Drawing.Size(69, 82);
            this.tbBothBrakes.TabIndex = 16;
            this.tbBothBrakes.TickFrequency = 10;
            this.tbBothBrakes.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbBothBrakes.Value = 135;
            this.tbBothBrakes.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbBothBrakes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // tbRightBrake
            // 
            this.tbRightBrake.Location = new System.Drawing.Point(471, 43);
            this.tbRightBrake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRightBrake.Maximum = 250;
            this.tbRightBrake.Minimum = 135;
            this.tbRightBrake.Name = "tbRightBrake";
            this.tbRightBrake.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbRightBrake.Size = new System.Drawing.Size(69, 82);
            this.tbRightBrake.TabIndex = 15;
            this.tbRightBrake.TickFrequency = 10;
            this.tbRightBrake.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbRightBrake.Value = 135;
            this.tbRightBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbRightBrake.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // tbLeftBrake
            // 
            this.tbLeftBrake.Location = new System.Drawing.Point(24, 43);
            this.tbLeftBrake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLeftBrake.Maximum = 250;
            this.tbLeftBrake.Minimum = 135;
            this.tbLeftBrake.Name = "tbLeftBrake";
            this.tbLeftBrake.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbLeftBrake.Size = new System.Drawing.Size(69, 82);
            this.tbLeftBrake.TabIndex = 14;
            this.tbLeftBrake.TickFrequency = 10;
            this.tbLeftBrake.Value = 135;
            this.tbLeftBrake.ValueChanged += new System.EventHandler(this.Brake_ValueChanged);
            this.tbLeftBrake.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Brake_MouseUp);
            // 
            // nudFlywheelRevTime
            // 
            this.nudFlywheelRevTime.Location = new System.Drawing.Point(99, 75);
            this.nudFlywheelRevTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudFlywheelRevTime.Size = new System.Drawing.Size(108, 26);
            this.nudFlywheelRevTime.TabIndex = 14;
            this.nudFlywheelRevTime.Value = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudFlywheelRevTime.ValueChanged += new System.EventHandler(this.nudFlywheelRevTime_ValueChanged);
            // 
            // gbResistance
            // 
            this.gbResistance.Controls.Add(this.lb0);
            this.gbResistance.Controls.Add(this.lb250);
            this.gbResistance.Controls.Add(this.vblResistance);
            this.gbResistance.Controls.Add(this.lbRequestsPerSecond);
            this.gbResistance.Controls.Add(this.label2);
            this.gbResistance.Controls.Add(this.lbResistanceValue);
            this.gbResistance.Controls.Add(this.lbResistance);
            this.gbResistance.Location = new System.Drawing.Point(1064, 42);
            this.gbResistance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResistance.Name = "gbResistance";
            this.gbResistance.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbResistance.Size = new System.Drawing.Size(185, 418);
            this.gbResistance.TabIndex = 15;
            this.gbResistance.TabStop = false;
            this.gbResistance.Text = "Resistance";
            // 
            // lb0
            // 
            this.lb0.AutoSize = true;
            this.lb0.Location = new System.Drawing.Point(69, 386);
            this.lb0.Name = "lb0";
            this.lb0.Size = new System.Drawing.Size(18, 20);
            this.lb0.TabIndex = 7;
            this.lb0.Text = "0";
            // 
            // lb250
            // 
            this.lb250.AutoSize = true;
            this.lb250.Location = new System.Drawing.Point(69, 28);
            this.lb250.Name = "lb250";
            this.lb250.Size = new System.Drawing.Size(36, 20);
            this.lb250.TabIndex = 6;
            this.lb250.Text = "250";
            // 
            // vblResistance
            // 
            this.vblResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.vblResistance.ClipOutOfRangeValues = true;
            this.vblResistance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vblResistance.Location = new System.Drawing.Point(27, 29);
            this.vblResistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vblResistance.Maximum = 250;
            this.vblResistance.Name = "vblResistance";
            this.vblResistance.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.vblResistance.Size = new System.Drawing.Size(34, 377);
            this.vblResistance.TabIndex = 5;
            this.vblResistance.Value = 0;
            // 
            // lbRequestsPerSecond
            // 
            this.lbRequestsPerSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRequestsPerSecond.Location = new System.Drawing.Point(76, 225);
            this.lbRequestsPerSecond.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRequestsPerSecond.Name = "lbRequestsPerSecond";
            this.lbRequestsPerSecond.Size = new System.Drawing.Size(77, 30);
            this.lbRequestsPerSecond.TabIndex = 3;
            this.lbRequestsPerSecond.Text = "0";
            this.lbRequestsPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Requests / s";
            // 
            // lbResistanceValue
            // 
            this.lbResistanceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResistanceValue.Location = new System.Drawing.Point(76, 151);
            this.lbResistanceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResistanceValue.Name = "lbResistanceValue";
            this.lbResistanceValue.Size = new System.Drawing.Size(77, 30);
            this.lbResistanceValue.TabIndex = 1;
            this.lbResistanceValue.Text = "0";
            this.lbResistanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbResistance
            // 
            this.lbResistance.AutoSize = true;
            this.lbResistance.Location = new System.Drawing.Point(76, 124);
            this.lbResistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResistance.Name = "lbResistance";
            this.lbResistance.Size = new System.Drawing.Size(46, 20);
            this.lbResistance.TabIndex = 0;
            this.lbResistance.Text = "Level";
            // 
            // nudRPM
            // 
            this.nudRPM.Location = new System.Drawing.Point(100, 151);
            this.nudRPM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudRPM.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudRPM.Name = "nudRPM";
            this.nudRPM.Size = new System.Drawing.Size(108, 26);
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
            this.gbFlywheel.Location = new System.Drawing.Point(815, 42);
            this.gbFlywheel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFlywheel.Name = "gbFlywheel";
            this.gbFlywheel.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbFlywheel.Size = new System.Drawing.Size(240, 418);
            this.gbFlywheel.TabIndex = 16;
            this.gbFlywheel.TabStop = false;
            this.gbFlywheel.Text = "Flywheel";
            // 
            // lbRPM
            // 
            this.lbRPM.AutoSize = true;
            this.lbRPM.Location = new System.Drawing.Point(96, 120);
            this.lbRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRPM.Name = "lbRPM";
            this.lbRPM.Size = new System.Drawing.Size(44, 20);
            this.lbRPM.TabIndex = 17;
            this.lbRPM.Text = "RPM";
            // 
            // lbFlywheelRevTime
            // 
            this.lbFlywheelRevTime.AutoSize = true;
            this.lbFlywheelRevTime.Location = new System.Drawing.Point(94, 45);
            this.lbFlywheelRevTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFlywheelRevTime.Name = "lbFlywheelRevTime";
            this.lbFlywheelRevTime.Size = new System.Drawing.Size(122, 20);
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
            this.gbCrank.Location = new System.Drawing.Point(567, 40);
            this.gbCrank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCrank.Name = "gbCrank";
            this.gbCrank.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCrank.Size = new System.Drawing.Size(237, 420);
            this.gbCrank.TabIndex = 17;
            this.gbCrank.TabStop = false;
            this.gbCrank.Text = "Crank";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(94, 192);
            this.lbPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(111, 20);
            this.lbPosition.TabIndex = 24;
            this.lbPosition.Text = "Crank Position";
            // 
            // nudCrankPosition
            // 
            this.nudCrankPosition.Location = new System.Drawing.Point(99, 223);
            this.nudCrankPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.nudCrankPosition.Size = new System.Drawing.Size(108, 26);
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
            this.lbCrankRPM.Location = new System.Drawing.Point(96, 120);
            this.lbCrankRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCrankRPM.Name = "lbCrankRPM";
            this.lbCrankRPM.Size = new System.Drawing.Size(44, 20);
            this.lbCrankRPM.TabIndex = 22;
            this.lbCrankRPM.Text = "RPM";
            // 
            // lbRevolutionTime
            // 
            this.lbRevolutionTime.AutoSize = true;
            this.lbRevolutionTime.Location = new System.Drawing.Point(94, 45);
            this.lbRevolutionTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRevolutionTime.Name = "lbRevolutionTime";
            this.lbRevolutionTime.Size = new System.Drawing.Size(122, 20);
            this.lbRevolutionTime.TabIndex = 21;
            this.lbRevolutionTime.Text = "Revolution Time";
            // 
            // nudCrankRPM
            // 
            this.nudCrankRPM.Location = new System.Drawing.Point(100, 151);
            this.nudCrankRPM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCrankRPM.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudCrankRPM.Name = "nudCrankRPM";
            this.nudCrankRPM.Size = new System.Drawing.Size(108, 26);
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
            this.tbCrankSpeed.Location = new System.Drawing.Point(9, 29);
            this.tbCrankSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCrankSpeed.Maximum = 300;
            this.tbCrankSpeed.Name = "tbCrankSpeed";
            this.tbCrankSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbCrankSpeed.Size = new System.Drawing.Size(69, 380);
            this.tbCrankSpeed.TabIndex = 18;
            this.tbCrankSpeed.TickFrequency = 5;
            this.tbCrankSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbCrankSpeed.ValueChanged += new System.EventHandler(this.tbCrankSpeed_ValueChanged);
            // 
            // nudCrankRevTime
            // 
            this.nudCrankRevTime.Location = new System.Drawing.Point(99, 75);
            this.nudCrankRevTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCrankRevTime.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.nudCrankRevTime.Name = "nudCrankRevTime";
            this.nudCrankRevTime.Size = new System.Drawing.Size(108, 26);
            this.nudCrankRevTime.TabIndex = 19;
            // 
            // tsToolStrip
            // 
            this.tsToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSerialPort,
            this.tscSerialPorts,
            this.tsbConnect,
            this.tsbDisconnect,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.tsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tsToolStrip.Name = "tsToolStrip";
            this.tsToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsToolStrip.Size = new System.Drawing.Size(1257, 34);
            this.tsToolStrip.TabIndex = 19;
            this.tsToolStrip.Text = "toolStrip1";
            // 
            // tslSerialPort
            // 
            this.tslSerialPort.Name = "tslSerialPort";
            this.tslSerialPort.Size = new System.Drawing.Size(91, 29);
            this.tslSerialPort.Text = "Serial Port";
            // 
            // tscSerialPorts
            // 
            this.tscSerialPorts.Name = "tscSerialPorts";
            this.tscSerialPorts.Size = new System.Drawing.Size(110, 34);
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(81, 29);
            this.tsbConnect.Text = "Connect";
            this.tsbConnect.Click += new System.EventHandler(this.bnConnect_Click);
            // 
            // tsbDisconnect
            // 
            this.tsbDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDisconnect.Enabled = false;
            this.tsbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisconnect.Image")));
            this.tsbDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnect.Name = "tsbDisconnect";
            this.tsbDisconnect.Size = new System.Drawing.Size(103, 29);
            this.tsbDisconnect.Text = "Disconnect";
            this.tsbDisconnect.Click += new System.EventHandler(this.bnDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 467);
            this.Controls.Add(this.tsToolStrip);
            this.Controls.Add(this.gbCrank);
            this.Controls.Add(this.gbFlywheel);
            this.Controls.Add(this.gbResistance);
            this.Controls.Add(this.gbControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControllerForm";
            this.Text = "X-Dream Bike Emulator";
            ((System.ComponentModel.ISupportInitialize)(this.tbFlywheelSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSteering)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBothBrakes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRightBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeftBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlywheelRevTime)).EndInit();
            this.gbResistance.ResumeLayout(false);
            this.gbResistance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRPM)).EndInit();
            this.gbFlywheel.ResumeLayout(false);
            this.gbFlywheel.PerformLayout();
            this.gbCrank.ResumeLayout(false);
            this.gbCrank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCrankSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrankRevTime)).EndInit();
            this.tsToolStrip.ResumeLayout(false);
            this.tsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox gbResistance;
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
        private System.Windows.Forms.Button bnGamePad;
        private System.Windows.Forms.Label lbHeartRate;
        private System.Windows.Forms.NumericUpDown nudHeartRate;
        private System.Windows.Forms.Label lbRequestsPerSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip tsToolStrip;
        private System.Windows.Forms.ToolStripLabel tslSerialPort;
        private System.Windows.Forms.ToolStripComboBox tscSerialPorts;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton tsbDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Diagnostics.Controls.ValueBar vblResistance;
        private System.Windows.Forms.Label lb0;
        private System.Windows.Forms.Label lb250;
    }
}

