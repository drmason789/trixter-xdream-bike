namespace Trixter.XDream.Diagnostics.Controls
{
    partial class CrankDetails
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
            this.gbCrankDetails = new System.Windows.Forms.GroupBox();
            this.pnlLabels = new System.Windows.Forms.Panel();
            this.gbLegend = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbCurrent = new System.Windows.Forms.Label();
            this.lbCurrentColor = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.lbUnreported = new System.Windows.Forms.Label();
            this.lbVisited = new System.Windows.Forms.Label();
            this.lbReportedColor = new System.Windows.Forms.Label();
            this.lbUnreportedColor = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.gbCrankDetails.SuspendLayout();
            this.gbLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCrankDetails
            // 
            this.gbCrankDetails.Controls.Add(this.pnlLabels);
            this.gbCrankDetails.Controls.Add(this.gbLegend);
            this.gbCrankDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCrankDetails.Location = new System.Drawing.Point(0, 0);
            this.gbCrankDetails.Name = "gbCrankDetails";
            this.gbCrankDetails.Size = new System.Drawing.Size(676, 643);
            this.gbCrankDetails.TabIndex = 0;
            this.gbCrankDetails.TabStop = false;
            this.gbCrankDetails.Text = "Crank Diagnostics";
            // 
            // pnlLabels
            // 
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabels.Location = new System.Drawing.Point(3, 22);
            this.pnlLabels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(670, 535);
            this.pnlLabels.TabIndex = 1;
            // 
            // gbLegend
            // 
            this.gbLegend.Controls.Add(this.btnReset);
            this.gbLegend.Controls.Add(this.lbCurrent);
            this.gbLegend.Controls.Add(this.lbCurrentColor);
            this.gbLegend.Controls.Add(this.btnPauseResume);
            this.gbLegend.Controls.Add(this.lbUnreported);
            this.gbLegend.Controls.Add(this.lbVisited);
            this.gbLegend.Controls.Add(this.lbReportedColor);
            this.gbLegend.Controls.Add(this.lbUnreportedColor);
            this.gbLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLegend.Location = new System.Drawing.Point(3, 557);
            this.gbLegend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLegend.Name = "gbLegend";
            this.gbLegend.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLegend.Size = new System.Drawing.Size(670, 83);
            this.gbLegend.TabIndex = 0;
            this.gbLegend.TabStop = false;
            this.gbLegend.Text = "Legend";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(566, 31);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 35);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(286, 40);
            this.lbCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(181, 20);
            this.lbCurrent.TabIndex = 3;
            this.lbCurrent.Text = "Reported within 1000ms";
            // 
            // lbCurrentColor
            // 
            this.lbCurrentColor.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCurrentColor.Location = new System.Drawing.Point(258, 38);
            this.lbCurrentColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentColor.Name = "lbCurrentColor";
            this.lbCurrentColor.Size = new System.Drawing.Size(22, 23);
            this.lbCurrentColor.TabIndex = 2;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPauseResume.Location = new System.Drawing.Point(468, 29);
            this.btnPauseResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(96, 35);
            this.btnPauseResume.TabIndex = 6;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // lbUnreported
            // 
            this.lbUnreported.AutoSize = true;
            this.lbUnreported.Location = new System.Drawing.Point(48, 40);
            this.lbUnreported.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnreported.Name = "lbUnreported";
            this.lbUnreported.Size = new System.Drawing.Size(90, 20);
            this.lbUnreported.TabIndex = 5;
            this.lbUnreported.Text = "Unreported";
            // 
            // lbVisited
            // 
            this.lbVisited.AutoSize = true;
            this.lbVisited.Location = new System.Drawing.Point(172, 40);
            this.lbVisited.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVisited.Name = "lbVisited";
            this.lbVisited.Size = new System.Drawing.Size(76, 20);
            this.lbVisited.TabIndex = 4;
            this.lbVisited.Text = "Reported";
            // 
            // lbReportedColor
            // 
            this.lbReportedColor.BackColor = System.Drawing.Color.Black;
            this.lbReportedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbReportedColor.Location = new System.Drawing.Point(146, 38);
            this.lbReportedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbReportedColor.Name = "lbReportedColor";
            this.lbReportedColor.Size = new System.Drawing.Size(22, 23);
            this.lbReportedColor.TabIndex = 1;
            // 
            // lbUnreportedColor
            // 
            this.lbUnreportedColor.BackColor = System.Drawing.Color.Red;
            this.lbUnreportedColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbUnreportedColor.Location = new System.Drawing.Point(20, 38);
            this.lbUnreportedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnreportedColor.Name = "lbUnreportedColor";
            this.lbUnreportedColor.Size = new System.Drawing.Size(22, 23);
            this.lbUnreportedColor.TabIndex = 0;
            // 
            // CrankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCrankDetails);
            this.Name = "CrankDetails";
            this.Size = new System.Drawing.Size(676, 643);
            this.gbCrankDetails.ResumeLayout(false);
            this.gbLegend.ResumeLayout(false);
            this.gbLegend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCrankDetails;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.GroupBox gbLegend;
        private System.Windows.Forms.Label lbUnreported;
        private System.Windows.Forms.Label lbVisited;
        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Label lbCurrentColor;
        private System.Windows.Forms.Label lbReportedColor;
        private System.Windows.Forms.Label lbUnreportedColor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Panel pnlLabels;
    }
}
