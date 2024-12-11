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
            this.gpGroupPolicyControl = new Trixter.XDream.Diagnostics.Controls.GroupPolicy();
            this.SuspendLayout();
            // 
            // gpGroupPolicyControl
            // 
            this.gpGroupPolicyControl.Location = new System.Drawing.Point(8, 8);
            this.gpGroupPolicyControl.Name = "gpGroupPolicyControl";
            this.gpGroupPolicyControl.Size = new System.Drawing.Size(500, 436);
            this.gpGroupPolicyControl.TabIndex = 3;
            // 
            // GroupPolicyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 449);
            this.Controls.Add(this.gpGroupPolicyControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 245);
            this.Name = "GroupPolicyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group Policy";
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.GroupPolicy gpGroupPolicyControl;
    }
}