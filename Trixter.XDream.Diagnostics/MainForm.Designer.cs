﻿
using Trixter.XDream.Diagnostics.Controls;

namespace Trixter.XDream.Diagnostics
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
            this.tsToolStrip = new System.Windows.Forms.ToolStrip();
            this.tslSerialPort = new System.Windows.Forms.ToolStripLabel();
            this.tscSerialPorts = new System.Windows.Forms.ToolStripComboBox();
            this.tsbRefreshPorts = new System.Windows.Forms.ToolStripButton();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCapture = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdates = new System.Windows.Forms.ToolStripButton();
            this.tcTabs = new System.Windows.Forms.TabControl();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.tpCrank = new System.Windows.Forms.TabPage();
            this.tpDriver = new System.Windows.Forms.TabPage();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dDetailsControl = new Trixter.XDream.Diagnostics.Controls.Details();
            this.tdCrankDetails = new Trixter.XDream.Diagnostics.Controls.CrankDetails();
            this.gpGroupPolicyControl = new Trixter.XDream.Diagnostics.Controls.GroupPolicy();
            this.tsToolStrip.SuspendLayout();
            this.tcTabs.SuspendLayout();
            this.tpDetails.SuspendLayout();
            this.tpCrank.SuspendLayout();
            this.tpDriver.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolStrip
            // 
            this.tsToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSerialPort,
            this.tscSerialPorts,
            this.tsbRefreshPorts,
            this.tsbConnect,
            this.tsbDisconnect,
            this.toolStripSeparator1,
            this.tsbCapture,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbUpdates});
            this.tsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tsToolStrip.Name = "tsToolStrip";
            this.tsToolStrip.Size = new System.Drawing.Size(520, 34);
            this.tsToolStrip.TabIndex = 7;
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
            this.tscSerialPorts.Size = new System.Drawing.Size(75, 34);
            // 
            // tsbRefreshPorts
            // 
            this.tsbRefreshPorts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshPorts.Image = global::Trixter.XDream.Diagnostics.Properties.Resources.Refresh;
            this.tsbRefreshPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshPorts.Name = "tsbRefreshPorts";
            this.tsbRefreshPorts.Size = new System.Drawing.Size(34, 29);
            this.tsbRefreshPorts.Text = "Refresh Port List";
            this.tsbRefreshPorts.Click += new System.EventHandler(this.tsbRefreshPorts_Click);
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(81, 29);
            this.tsbConnect.Text = "Connect";
            this.tsbConnect.Click += new System.EventHandler(this.tsbConnect_Click);
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
            this.tsbDisconnect.Click += new System.EventHandler(this.tsbDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbCapture
            // 
            this.tsbCapture.CheckOnClick = true;
            this.tsbCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCapture.Image = ((System.Drawing.Image)(resources.GetObject("tsbCapture.Image")));
            this.tsbCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCapture.Name = "tsbCapture";
            this.tsbCapture.Size = new System.Drawing.Size(78, 29);
            this.tsbCapture.Text = "Capture";
            this.tsbCapture.Click += new System.EventHandler(this.tsbCapture_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(53, 29);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbUpdates
            // 
            this.tsbUpdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdates.Name = "tsbUpdates";
            this.tsbUpdates.Size = new System.Drawing.Size(82, 29);
            this.tsbUpdates.Text = "Updates";
            this.tsbUpdates.ToolTipText = "Check for Updates";
            this.tsbUpdates.Click += new System.EventHandler(this.tsbUpdates_Click);
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tpDetails);
            this.tcTabs.Controls.Add(this.tpCrank);
            this.tcTabs.Controls.Add(this.tpDriver);
            this.tcTabs.Location = new System.Drawing.Point(3, 28);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(518, 472);
            this.tcTabs.TabIndex = 8;
            this.tcTabs.SelectedIndexChanged += new System.EventHandler(this.tcTabs_SelectedIndexChanged);
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.dDetailsControl);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpDetails.Size = new System.Drawing.Size(510, 446);
            this.tpDetails.TabIndex = 0;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // tpCrank
            // 
            this.tpCrank.Controls.Add(this.tdCrankDetails);
            this.tpCrank.Location = new System.Drawing.Point(4, 22);
            this.tpCrank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpCrank.Name = "tpCrank";
            this.tpCrank.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpCrank.Size = new System.Drawing.Size(510, 446);
            this.tpCrank.TabIndex = 3;
            this.tpCrank.Text = "Crank";
            this.tpCrank.UseVisualStyleBackColor = true;
            // 
            // tpDriver
            // 
            this.tpDriver.Controls.Add(this.gpGroupPolicyControl);
            this.tpDriver.Location = new System.Drawing.Point(4, 22);
            this.tpDriver.Name = "tpDriver";
            this.tpDriver.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpDriver.Size = new System.Drawing.Size(510, 446);
            this.tpDriver.TabIndex = 2;
            this.tpDriver.Text = "Driver";
            this.tpDriver.UseVisualStyleBackColor = true;
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "csv";
            this.dlgSaveFile.Filter = "CSV Files|*.csv";
            this.dlgSaveFile.SupportMultiDottedExtensions = true;
            // 
            // dDetailsControl
            // 
            this.dDetailsControl.DataAccess = null;
            this.dDetailsControl.Location = new System.Drawing.Point(6, 6);
            this.dDetailsControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dDetailsControl.MaximumSize = new System.Drawing.Size(497, 432);
            this.dDetailsControl.MinimumSize = new System.Drawing.Size(497, 432);
            this.dDetailsControl.Name = "dDetailsControl";
            this.dDetailsControl.Size = new System.Drawing.Size(497, 432);
            this.dDetailsControl.TabIndex = 0;
            this.dDetailsControl.UpdateInterval = 1000;
            // 
            // tdCrankDetails
            // 
            this.tdCrankDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tdCrankDetails.Location = new System.Drawing.Point(2, 2);
            this.tdCrankDetails.Margin = new System.Windows.Forms.Padding(1);
            this.tdCrankDetails.Name = "tdCrankDetails";
            this.tdCrankDetails.Size = new System.Drawing.Size(506, 442);
            this.tdCrankDetails.TabIndex = 0;
            // 
            // gpGroupPolicyControl
            // 
            this.gpGroupPolicyControl.Location = new System.Drawing.Point(7, 7);
            this.gpGroupPolicyControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gpGroupPolicyControl.Name = "gpGroupPolicyControl";
            this.gpGroupPolicyControl.Size = new System.Drawing.Size(500, 436);
            this.gpGroupPolicyControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 501);
            this.Controls.Add(this.tcTabs);
            this.Controls.Add(this.tsToolStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "X-Dream Bike Diagnostic UI";
            this.tsToolStrip.ResumeLayout(false);
            this.tsToolStrip.PerformLayout();
            this.tcTabs.ResumeLayout(false);
            this.tpDetails.ResumeLayout(false);
            this.tpCrank.ResumeLayout(false);
            this.tpDriver.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsToolStrip;
        private System.Windows.Forms.ToolStripLabel tslSerialPort;
        private System.Windows.Forms.ToolStripComboBox tscSerialPorts;
        private System.Windows.Forms.ToolStripButton tsbRefreshPorts;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton tsbDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.TabPage tpDriver;
        private Details dDetailsControl;
        private GroupPolicy gpGroupPolicyControl;
        private System.Windows.Forms.ToolStripButton tsbCapture;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ToolStripButton tsbUpdates;
        private System.Windows.Forms.TabPage tpCrank;
        private CrankDetails tdCrankDetails;
    }
}

