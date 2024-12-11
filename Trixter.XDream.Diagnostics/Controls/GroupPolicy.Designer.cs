namespace Trixter.XDream.Diagnostics.Controls
{
    partial class GroupPolicy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupPolicy));
            this.gbGroupPolicy = new System.Windows.Forms.GroupBox();
            this.lbExplanation = new System.Windows.Forms.Label();
            this.lblOpinion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnBlocking = new System.Windows.Forms.Panel();
            this.lbXDreamDevices = new System.Windows.Forms.Label();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.cbRetroactive = new System.Windows.Forms.CheckBox();
            this.cbBlocking = new System.Windows.Forms.CheckBox();
            this.lbSummary = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbGroupPolicy.SuspendLayout();
            this.pnBlocking.SuspendLayout();
            this.SuspendLayout();
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
            this.gbGroupPolicy.Location = new System.Drawing.Point(0, 0);
            this.gbGroupPolicy.Name = "gbGroupPolicy";
            this.gbGroupPolicy.Size = new System.Drawing.Size(500, 436);
            this.gbGroupPolicy.TabIndex = 21;
            this.gbGroupPolicy.TabStop = false;
            this.gbGroupPolicy.Text = "Group Policy";
            // 
            // lbExplanation
            // 
            this.lbExplanation.Location = new System.Drawing.Point(11, 24);
            this.lbExplanation.Name = "lbExplanation";
            this.lbExplanation.Size = new System.Drawing.Size(467, 132);
            this.lbExplanation.TabIndex = 27;
            this.lbExplanation.Text = resources.GetString("lbExplanation.Text");
            // 
            // lblOpinion
            // 
            this.lblOpinion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOpinion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpinion.Location = new System.Drawing.Point(80, 208);
            this.lblOpinion.Name = "lblOpinion";
            this.lblOpinion.Size = new System.Drawing.Size(398, 40);
            this.lblOpinion.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 208);
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
            this.pnBlocking.Size = new System.Drawing.Size(472, 137);
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
            this.lbDevices.Size = new System.Drawing.Size(454, 111);
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
            this.lbSummary.Location = new System.Drawing.Point(80, 163);
            this.lbSummary.Name = "lbSummary";
            this.lbSummary.Size = new System.Drawing.Size(398, 40);
            this.lbSummary.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Summary";
            // 
            // GroupPolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbGroupPolicy);
            this.Name = "GroupPolicy";
            this.Size = new System.Drawing.Size(500, 436);
            this.gbGroupPolicy.ResumeLayout(false);
            this.gbGroupPolicy.PerformLayout();
            this.pnBlocking.ResumeLayout(false);
            this.pnBlocking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGroupPolicy;
        private System.Windows.Forms.Label lbExplanation;
        private System.Windows.Forms.Label lblOpinion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnBlocking;
        private System.Windows.Forms.Label lbXDreamDevices;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.CheckBox cbRetroactive;
        private System.Windows.Forms.CheckBox cbBlocking;
        private System.Windows.Forms.Label lbSummary;
        private System.Windows.Forms.Label label1;
    }
}
