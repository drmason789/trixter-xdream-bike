namespace Trixter.XDream.Diagnostics
{
    partial class GroupPolicyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupPolicyForm));
            this.btnOkay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.lbSummary = new System.Windows.Forms.Label();
            this.cbBlocking = new System.Windows.Forms.CheckBox();
            this.pnBlocking = new System.Windows.Forms.Panel();
            this.cbRetroactive = new System.Windows.Forms.CheckBox();
            this.lbXDreamDevices = new System.Windows.Forms.Label();
            this.pnBlocking.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkay.Location = new System.Drawing.Point(389, 175);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Summary";
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
            this.lbDevices.Size = new System.Drawing.Size(458, 67);
            this.lbDevices.TabIndex = 6;
            // 
            // lbSummary
            // 
            this.lbSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSummary.Location = new System.Drawing.Point(71, 9);
            this.lbSummary.Name = "lbSummary";
            this.lbSummary.Size = new System.Drawing.Size(401, 40);
            this.lbSummary.TabIndex = 8;
            this.lbSummary.Text = "Summary Text";
            // 
            // cbBlocking
            // 
            this.cbBlocking.AutoCheck = false;
            this.cbBlocking.AutoSize = true;
            this.cbBlocking.Location = new System.Drawing.Point(15, 52);
            this.cbBlocking.Name = "cbBlocking";
            this.cbBlocking.Size = new System.Drawing.Size(109, 17);
            this.cbBlocking.TabIndex = 9;
            this.cbBlocking.Text = "Blocking Enabled";
            this.cbBlocking.UseVisualStyleBackColor = true;
            this.cbBlocking.CheckedChanged += new System.EventHandler(this.cbBlocking_CheckedChanged);
            // 
            // pnBlocking
            // 
            this.pnBlocking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBlocking.Controls.Add(this.lbXDreamDevices);
            this.pnBlocking.Controls.Add(this.lbDevices);
            this.pnBlocking.Location = new System.Drawing.Point(5, 75);
            this.pnBlocking.Name = "pnBlocking";
            this.pnBlocking.Size = new System.Drawing.Size(476, 96);
            this.pnBlocking.TabIndex = 10;
            // 
            // cbRetroactive
            // 
            this.cbRetroactive.AutoCheck = false;
            this.cbRetroactive.AutoSize = true;
            this.cbRetroactive.Location = new System.Drawing.Point(130, 52);
            this.cbRetroactive.Name = "cbRetroactive";
            this.cbRetroactive.Size = new System.Drawing.Size(125, 17);
            this.cbRetroactive.TabIndex = 7;
            this.cbRetroactive.Text = "Retroactive Blocking";
            this.cbRetroactive.UseVisualStyleBackColor = true;
            // 
            // lbXDreamDevices
            // 
            this.lbXDreamDevices.AutoSize = true;
            this.lbXDreamDevices.Location = new System.Drawing.Point(9, 4);
            this.lbXDreamDevices.Name = "lbXDreamDevices";
            this.lbXDreamDevices.Size = new System.Drawing.Size(180, 13);
            this.lbXDreamDevices.TabIndex = 8;
            this.lbXDreamDevices.Text = "Known X-Dream Devices Registered";
            // 
            // GroupPolicyForm
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 207);
            this.Controls.Add(this.pnBlocking);
            this.Controls.Add(this.cbRetroactive);
            this.Controls.Add(this.cbBlocking);
            this.Controls.Add(this.lbSummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 245);
            this.Name = "GroupPolicyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group Policy";
            this.pnBlocking.ResumeLayout(false);
            this.pnBlocking.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.Label lbSummary;
        private System.Windows.Forms.CheckBox cbBlocking;
        private System.Windows.Forms.Panel pnBlocking;
        private System.Windows.Forms.Label lbXDreamDevices;
        private System.Windows.Forms.CheckBox cbRetroactive;
    }
}