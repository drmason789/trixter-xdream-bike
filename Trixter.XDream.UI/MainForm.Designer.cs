
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pbSteering = new System.Windows.Forms.ProgressBar();
            this.pbLeftBrake = new System.Windows.Forms.ProgressBar();
            this.pbRightBrake = new System.Windows.Forms.ProgressBar();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbOther30 = new System.Windows.Forms.Label();
            this.lbHeartRate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCrankSpeed = new System.Windows.Forms.Label();
            this.lbOther7 = new System.Windows.Forms.Label();
            this.lbOther6 = new System.Windows.Forms.Label();
            this.lbOther2 = new System.Windows.Forms.Label();
            this.lbRightBrakeValue = new System.Windows.Forms.Label();
            this.lbLeftBrakeValue = new System.Windows.Forms.Label();
            this.lbSteeringValue = new System.Windows.Forms.Label();
            this.lbFlywheel = new System.Windows.Forms.Label();
            this.lbCrankPosition = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFlywheel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSteering = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnDisconnect = new System.Windows.Forms.Button();
            this.bnConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(72, 19);
            this.trackBar1.Maximum = 16;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 380);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // pbSteering
            // 
            this.pbSteering.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pbSteering.Location = new System.Drawing.Point(92, 25);
            this.pbSteering.MarqueeAnimationSpeed = 0;
            this.pbSteering.Maximum = 255;
            this.pbSteering.Name = "pbSteering";
            this.pbSteering.Size = new System.Drawing.Size(198, 23);
            this.pbSteering.Step = 1;
            this.pbSteering.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSteering.TabIndex = 1;
            // 
            // pbLeftBrake
            // 
            this.pbLeftBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pbLeftBrake.Location = new System.Drawing.Point(92, 54);
            this.pbLeftBrake.MarqueeAnimationSpeed = 0;
            this.pbLeftBrake.Maximum = 250;
            this.pbLeftBrake.Name = "pbLeftBrake";
            this.pbLeftBrake.Size = new System.Drawing.Size(198, 23);
            this.pbLeftBrake.Step = 1;
            this.pbLeftBrake.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLeftBrake.TabIndex = 2;
            // 
            // pbRightBrake
            // 
            this.pbRightBrake.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pbRightBrake.Location = new System.Drawing.Point(92, 83);
            this.pbRightBrake.MarqueeAnimationSpeed = 0;
            this.pbRightBrake.Maximum = 250;
            this.pbRightBrake.Name = "pbRightBrake";
            this.pbRightBrake.Size = new System.Drawing.Size(198, 23);
            this.pbRightBrake.Step = 1;
            this.pbRightBrake.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbRightBrake.TabIndex = 3;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.label7);
            this.gbInput.Controls.Add(this.lbOther30);
            this.gbInput.Controls.Add(this.lbHeartRate);
            this.gbInput.Controls.Add(this.label8);
            this.gbInput.Controls.Add(this.lbCrankSpeed);
            this.gbInput.Controls.Add(this.lbOther7);
            this.gbInput.Controls.Add(this.lbOther6);
            this.gbInput.Controls.Add(this.lbOther2);
            this.gbInput.Controls.Add(this.lbRightBrakeValue);
            this.gbInput.Controls.Add(this.lbLeftBrakeValue);
            this.gbInput.Controls.Add(this.lbSteeringValue);
            this.gbInput.Controls.Add(this.lbFlywheel);
            this.gbInput.Controls.Add(this.lbCrankPosition);
            this.gbInput.Controls.Add(this.label6);
            this.gbInput.Controls.Add(this.tbFlywheel);
            this.gbInput.Controls.Add(this.label4);
            this.gbInput.Controls.Add(this.label3);
            this.gbInput.Controls.Add(this.label2);
            this.gbInput.Controls.Add(this.lbSteering);
            this.gbInput.Controls.Add(this.checkedListBox1);
            this.gbInput.Controls.Add(this.pbLeftBrake);
            this.gbInput.Controls.Add(this.pbRightBrake);
            this.gbInput.Controls.Add(this.pbSteering);
            this.gbInput.Location = new System.Drawing.Point(9, 73);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(347, 408);
            this.gbInput.TabIndex = 4;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "From Device";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Crank Speed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbOther30
            // 
            this.lbOther30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOther30.Location = new System.Drawing.Point(296, 231);
            this.lbOther30.Name = "lbOther30";
            this.lbOther30.Size = new System.Drawing.Size(44, 24);
            this.lbOther30.TabIndex = 27;
            this.lbOther30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHeartRate
            // 
            this.lbHeartRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHeartRate.Location = new System.Drawing.Point(296, 114);
            this.lbHeartRate.Name = "lbHeartRate";
            this.lbHeartRate.Size = new System.Drawing.Size(44, 24);
            this.lbHeartRate.TabIndex = 26;
            this.lbHeartRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(229, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Heart Rate";
            // 
            // lbCrankSpeed
            // 
            this.lbCrankSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankSpeed.Location = new System.Drawing.Point(92, 143);
            this.lbCrankSpeed.Name = "lbCrankSpeed";
            this.lbCrankSpeed.Size = new System.Drawing.Size(120, 24);
            this.lbCrankSpeed.TabIndex = 23;
            this.lbCrankSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOther7
            // 
            this.lbOther7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOther7.Location = new System.Drawing.Point(296, 201);
            this.lbOther7.Name = "lbOther7";
            this.lbOther7.Size = new System.Drawing.Size(44, 24);
            this.lbOther7.TabIndex = 22;
            this.lbOther7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOther6
            // 
            this.lbOther6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOther6.Location = new System.Drawing.Point(296, 172);
            this.lbOther6.Name = "lbOther6";
            this.lbOther6.Size = new System.Drawing.Size(44, 24);
            this.lbOther6.TabIndex = 21;
            this.lbOther6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOther2
            // 
            this.lbOther2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOther2.Location = new System.Drawing.Point(296, 143);
            this.lbOther2.Name = "lbOther2";
            this.lbOther2.Size = new System.Drawing.Size(44, 24);
            this.lbOther2.TabIndex = 20;
            this.lbOther2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lbFlywheel
            // 
            this.lbFlywheel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFlywheel.Location = new System.Drawing.Point(92, 171);
            this.lbFlywheel.Name = "lbFlywheel";
            this.lbFlywheel.Size = new System.Drawing.Size(120, 24);
            this.lbFlywheel.TabIndex = 14;
            this.lbFlywheel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCrankPosition
            // 
            this.lbCrankPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCrankPosition.Location = new System.Drawing.Point(92, 114);
            this.lbCrankPosition.Name = "lbCrankPosition";
            this.lbCrankPosition.Size = new System.Drawing.Size(120, 24);
            this.lbCrankPosition.TabIndex = 13;
            this.lbCrankPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Buttons";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFlywheel
            // 
            this.tbFlywheel.AutoSize = true;
            this.tbFlywheel.Location = new System.Drawing.Point(8, 177);
            this.tbFlywheel.Name = "tbFlywheel";
            this.tbFlywheel.Size = new System.Drawing.Size(82, 13);
            this.tbFlywheel.TabIndex = 11;
            this.tbFlywheel.Text = "Flywheel Speed";
            this.tbFlywheel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Crank Position";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Right Brake";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Left Brake";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
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
            this.checkedListBox1.Location = new System.Drawing.Point(92, 203);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 184);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.TabStop = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.label1);
            this.gbOutput.Controls.Add(this.trackBar1);
            this.gbOutput.Location = new System.Drawing.Point(362, 73);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(125, 408);
            this.gbOutput.TabIndex = 5;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "To Device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resistance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnDisconnect);
            this.groupBox1.Controls.Add(this.bnConnect);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbPorts);
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // bnDisconnect
            // 
            this.bnDisconnect.Location = new System.Drawing.Point(287, 17);
            this.bnDisconnect.Name = "bnDisconnect";
            this.bnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.bnDisconnect.TabIndex = 3;
            this.bnDisconnect.Text = "Disconnect";
            this.bnDisconnect.UseVisualStyleBackColor = true;
            this.bnDisconnect.Click += new System.EventHandler(this.bnDisconnect_Click);
            // 
            // bnConnect
            // 
            this.bnConnect.Location = new System.Drawing.Point(206, 17);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "X-Dream Bike Diagnostic UI";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ProgressBar pbSteering;
        private System.Windows.Forms.ProgressBar pbLeftBrake;
        private System.Windows.Forms.ProgressBar pbRightBrake;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tbFlywheel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSteering;
        private System.Windows.Forms.Label lbFlywheel;
        private System.Windows.Forms.Label lbCrankPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button bnDisconnect;
        private System.Windows.Forms.Button bnConnect;
        private System.Windows.Forms.Label lbRightBrakeValue;
        private System.Windows.Forms.Label lbLeftBrakeValue;
        private System.Windows.Forms.Label lbSteeringValue;
        private System.Windows.Forms.Label lbCrankSpeed;
        private System.Windows.Forms.Label lbOther7;
        private System.Windows.Forms.Label lbOther6;
        private System.Windows.Forms.Label lbOther2;
        private System.Windows.Forms.Label lbOther30;
        private System.Windows.Forms.Label lbHeartRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

