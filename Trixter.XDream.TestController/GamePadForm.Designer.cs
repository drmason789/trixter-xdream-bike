namespace Trixter.XDream.TestController
{
    partial class GamePadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePadForm));
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lbRightGears = new System.Windows.Forms.Label();
            this.lbLeftGears = new System.Windows.Forms.Label();
            this.bnRightGearDown = new System.Windows.Forms.Button();
            this.bnGreen = new System.Windows.Forms.Button();
            this.bnRightGearUp = new System.Windows.Forms.Button();
            this.bnRed = new System.Windows.Forms.Button();
            this.cbSeated = new System.Windows.Forms.CheckBox();
            this.bnLeftGearDown = new System.Windows.Forms.Button();
            this.bnBlue = new System.Windows.Forms.Button();
            this.bnLeftGearUp = new System.Windows.Forms.Button();
            this.bnUp = new System.Windows.Forms.Button();
            this.bnRight = new System.Windows.Forms.Button();
            this.bnLeft = new System.Windows.Forms.Button();
            this.bnDown = new System.Windows.Forms.Button();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.pnlControl);
            this.gbControls.Controls.Add(this.lbRightGears);
            this.gbControls.Controls.Add(this.lbLeftGears);
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
            this.gbControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbControls.Location = new System.Drawing.Point(0, 0);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(334, 348);
            this.gbControls.TabIndex = 15;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Location = new System.Drawing.Point(18, 19);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(300, 153);
            this.pnlControl.TabIndex = 21;
            this.pnlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControl_Paint);
            this.pnlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseDown);
            this.pnlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseMove);
            this.pnlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlControl_MouseUp);
            // 
            // lbRightGears
            // 
            this.lbRightGears.AutoSize = true;
            this.lbRightGears.Location = new System.Drawing.Point(223, 188);
            this.lbRightGears.Name = "lbRightGears";
            this.lbRightGears.Size = new System.Drawing.Size(97, 13);
            this.lbRightGears.TabIndex = 20;
            this.lbRightGears.Text = "Right (Back) Gears";
            this.lbRightGears.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLeftGears
            // 
            this.lbLeftGears.AutoSize = true;
            this.lbLeftGears.Location = new System.Drawing.Point(15, 188);
            this.lbLeftGears.Name = "lbLeftGears";
            this.lbLeftGears.Size = new System.Drawing.Size(89, 13);
            this.lbLeftGears.TabIndex = 19;
            this.lbLeftGears.Text = "Left (Front) Gears";
            // 
            // bnRightGearDown
            // 
            this.bnRightGearDown.Location = new System.Drawing.Point(256, 232);
            this.bnRightGearDown.Name = "bnRightGearDown";
            this.bnRightGearDown.Size = new System.Drawing.Size(64, 20);
            this.bnRightGearDown.TabIndex = 13;
            this.bnRightGearDown.TabStop = false;
            this.bnRightGearDown.Text = "PgDn";
            this.bnRightGearDown.UseVisualStyleBackColor = true;
            this.bnRightGearDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnRightGearDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnGreen
            // 
            this.bnGreen.BackColor = System.Drawing.Color.Green;
            this.bnGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.bnGreen.Location = new System.Drawing.Point(236, 303);
            this.bnGreen.Name = "bnGreen";
            this.bnGreen.Size = new System.Drawing.Size(64, 25);
            this.bnGreen.TabIndex = 0;
            this.bnGreen.TabStop = false;
            this.bnGreen.Text = "Enter";
            this.bnGreen.UseVisualStyleBackColor = false;
            this.bnGreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnGreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnRightGearUp
            // 
            this.bnRightGearUp.Location = new System.Drawing.Point(256, 207);
            this.bnRightGearUp.Name = "bnRightGearUp";
            this.bnRightGearUp.Size = new System.Drawing.Size(64, 20);
            this.bnRightGearUp.TabIndex = 12;
            this.bnRightGearUp.TabStop = false;
            this.bnRightGearUp.Text = "PgUp";
            this.bnRightGearUp.UseVisualStyleBackColor = true;
            this.bnRightGearUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnRightGearUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnRed
            // 
            this.bnRed.BackColor = System.Drawing.Color.Red;
            this.bnRed.ForeColor = System.Drawing.SystemColors.Window;
            this.bnRed.Location = new System.Drawing.Point(168, 302);
            this.bnRed.Name = "bnRed";
            this.bnRed.Size = new System.Drawing.Size(64, 25);
            this.bnRed.TabIndex = 1;
            this.bnRed.TabStop = false;
            this.bnRed.Text = "Esc";
            this.bnRed.UseVisualStyleBackColor = false;
            this.bnRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnRed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // cbSeated
            // 
            this.cbSeated.AutoSize = true;
            this.cbSeated.Location = new System.Drawing.Point(118, 232);
            this.cbSeated.Name = "cbSeated";
            this.cbSeated.Size = new System.Drawing.Size(100, 17);
            this.cbSeated.TabIndex = 8;
            this.cbSeated.TabStop = false;
            this.cbSeated.Text = "Space (Seated)";
            this.cbSeated.UseVisualStyleBackColor = true;
            this.cbSeated.CheckedChanged += new System.EventHandler(this.cbSeated_CheckedChanged);
            // 
            // bnLeftGearDown
            // 
            this.bnLeftGearDown.Location = new System.Drawing.Point(14, 232);
            this.bnLeftGearDown.Name = "bnLeftGearDown";
            this.bnLeftGearDown.Size = new System.Drawing.Size(64, 20);
            this.bnLeftGearDown.TabIndex = 11;
            this.bnLeftGearDown.TabStop = false;
            this.bnLeftGearDown.Text = "Del";
            this.bnLeftGearDown.UseVisualStyleBackColor = true;
            this.bnLeftGearDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnLeftGearDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnBlue
            // 
            this.bnBlue.BackColor = System.Drawing.Color.Blue;
            this.bnBlue.ForeColor = System.Drawing.SystemColors.Window;
            this.bnBlue.Location = new System.Drawing.Point(204, 274);
            this.bnBlue.Name = "bnBlue";
            this.bnBlue.Size = new System.Drawing.Size(64, 25);
            this.bnBlue.TabIndex = 2;
            this.bnBlue.TabStop = false;
            this.bnBlue.Text = "V";
            this.bnBlue.UseVisualStyleBackColor = false;
            this.bnBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnBlue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnLeftGearUp
            // 
            this.bnLeftGearUp.Location = new System.Drawing.Point(14, 207);
            this.bnLeftGearUp.Name = "bnLeftGearUp";
            this.bnLeftGearUp.Size = new System.Drawing.Size(64, 20);
            this.bnLeftGearUp.TabIndex = 10;
            this.bnLeftGearUp.TabStop = false;
            this.bnLeftGearUp.Text = "Ins";
            this.bnLeftGearUp.UseVisualStyleBackColor = true;
            this.bnLeftGearUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnLeftGearUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnUp
            // 
            this.bnUp.Location = new System.Drawing.Point(54, 266);
            this.bnUp.Name = "bnUp";
            this.bnUp.Size = new System.Drawing.Size(64, 20);
            this.bnUp.TabIndex = 3;
            this.bnUp.TabStop = false;
            this.bnUp.Text = "Up";
            this.bnUp.UseVisualStyleBackColor = true;
            this.bnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnRight
            // 
            this.bnRight.Location = new System.Drawing.Point(88, 290);
            this.bnRight.Name = "bnRight";
            this.bnRight.Size = new System.Drawing.Size(64, 20);
            this.bnRight.TabIndex = 4;
            this.bnRight.TabStop = false;
            this.bnRight.Text = "Right";
            this.bnRight.UseVisualStyleBackColor = true;
            this.bnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnLeft
            // 
            this.bnLeft.Location = new System.Drawing.Point(20, 290);
            this.bnLeft.Name = "bnLeft";
            this.bnLeft.Size = new System.Drawing.Size(64, 20);
            this.bnLeft.TabIndex = 5;
            this.bnLeft.TabStop = false;
            this.bnLeft.Text = "Left";
            this.bnLeft.UseVisualStyleBackColor = true;
            this.bnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // bnDown
            // 
            this.bnDown.Location = new System.Drawing.Point(54, 314);
            this.bnDown.Name = "bnDown";
            this.bnDown.Size = new System.Drawing.Size(64, 20);
            this.bnDown.TabIndex = 6;
            this.bnDown.TabStop = false;
            this.bnDown.Text = "Down";
            this.bnDown.UseVisualStyleBackColor = true;
            this.bnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_Pressed);
            this.bnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_Released);
            // 
            // GamePadForm
            // 
            this.AcceptButton = this.bnGreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 348);
            this.Controls.Add(this.gbControls);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GamePadForm";
            this.Text = "X-Dream Gamepad Emulator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamePadForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GamePadForm_KeyUp);
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Label lbRightGears;
        private System.Windows.Forms.Label lbLeftGears;
        private System.Windows.Forms.Button bnRightGearDown;
        private System.Windows.Forms.Button bnGreen;
        private System.Windows.Forms.Button bnRightGearUp;
        private System.Windows.Forms.Button bnRed;
        private System.Windows.Forms.CheckBox cbSeated;
        private System.Windows.Forms.Button bnLeftGearDown;
        private System.Windows.Forms.Button bnBlue;
        private System.Windows.Forms.Button bnLeftGearUp;
        private System.Windows.Forms.Button bnUp;
        private System.Windows.Forms.Button bnRight;
        private System.Windows.Forms.Button bnLeft;
        private System.Windows.Forms.Button bnDown;
        private System.Windows.Forms.Panel pnlControl;
    }
}