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
            this.label3 = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.lbUnreported = new System.Windows.Forms.Label();
            this.lbVisited = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.gbCrankDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbCrankDetails.Name = "gbCrankDetails";
            this.gbCrankDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbCrankDetails.Size = new System.Drawing.Size(451, 418);
            this.gbCrankDetails.TabIndex = 0;
            this.gbCrankDetails.TabStop = false;
            this.gbCrankDetails.Text = "Crank Diagnostics";
            // 
            // pnlLabels
            // 
            this.pnlLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabels.Location = new System.Drawing.Point(2, 15);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(447, 347);
            this.pnlLabels.TabIndex = 1;
            // 
            // gbLegend
            // 
            this.gbLegend.Controls.Add(this.btnReset);
            this.gbLegend.Controls.Add(this.lbCurrent);
            this.gbLegend.Controls.Add(this.label3);
            this.gbLegend.Controls.Add(this.btnPauseResume);
            this.gbLegend.Controls.Add(this.lbUnreported);
            this.gbLegend.Controls.Add(this.lbVisited);
            this.gbLegend.Controls.Add(this.label2);
            this.gbLegend.Controls.Add(this.label1);
            this.gbLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLegend.Location = new System.Drawing.Point(2, 362);
            this.gbLegend.Name = "gbLegend";
            this.gbLegend.Size = new System.Drawing.Size(447, 54);
            this.gbLegend.TabIndex = 0;
            this.gbLegend.TabStop = false;
            this.gbLegend.Text = "Legend";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(377, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(191, 26);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(121, 13);
            this.lbCurrent.TabIndex = 3;
            this.lbCurrent.Text = "Reported within 1000ms";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(172, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 2;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPauseResume.Location = new System.Drawing.Point(310, 19);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(64, 23);
            this.btnPauseResume.TabIndex = 6;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // lbUnreported
            // 
            this.lbUnreported.AutoSize = true;
            this.lbUnreported.Location = new System.Drawing.Point(32, 26);
            this.lbUnreported.Name = "lbUnreported";
            this.lbUnreported.Size = new System.Drawing.Size(60, 13);
            this.lbUnreported.TabIndex = 5;
            this.lbUnreported.Text = "Unreported";
            // 
            // lbVisited
            // 
            this.lbVisited.AutoSize = true;
            this.lbVisited.Location = new System.Drawing.Point(115, 26);
            this.lbVisited.Name = "lbVisited";
            this.lbVisited.Size = new System.Drawing.Size(51, 13);
            this.lbVisited.TabIndex = 4;
            this.lbVisited.Text = "Reported";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(97, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 0;
            // 
            // CrankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCrankDetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CrankDetails";
            this.Size = new System.Drawing.Size(451, 418);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Panel pnlLabels;
    }
}
