
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
            this.tsbDriver = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdates = new System.Windows.Forms.ToolStripButton();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dDetailsControl = new Trixter.XDream.Diagnostics.Controls.Details();
            this.tsToolStrip.SuspendLayout();
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
            this.tsbDriver,
            this.tsbUpdates});
            this.tsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tsToolStrip.Name = "tsToolStrip";
            this.tsToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tsToolStrip.Size = new System.Drawing.Size(756, 38);
            this.tsToolStrip.TabIndex = 7;
            this.tsToolStrip.Text = "toolStrip1";
            // 
            // tslSerialPort
            // 
            this.tslSerialPort.Name = "tslSerialPort";
            this.tslSerialPort.Size = new System.Drawing.Size(91, 33);
            this.tslSerialPort.Text = "Serial Port";
            // 
            // tscSerialPorts
            // 
            this.tscSerialPorts.Name = "tscSerialPorts";
            this.tscSerialPorts.Size = new System.Drawing.Size(110, 38);
            // 
            // tsbRefreshPorts
            // 
            this.tsbRefreshPorts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshPorts.Image = global::Trixter.XDream.Diagnostics.Properties.Resources.Refresh;
            this.tsbRefreshPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshPorts.Name = "tsbRefreshPorts";
            this.tsbRefreshPorts.Size = new System.Drawing.Size(34, 33);
            this.tsbRefreshPorts.Text = "&Refresh Ports";
            this.tsbRefreshPorts.Click += new System.EventHandler(this.tsbRefreshPorts_Click);
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(81, 33);
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
            this.tsbDisconnect.Size = new System.Drawing.Size(103, 33);
            this.tsbDisconnect.Text = "Disconnect";
            this.tsbDisconnect.Click += new System.EventHandler(this.tsbDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbDriver
            // 
            this.tsbDriver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDriver.Image = ((System.Drawing.Image)(resources.GetObject("tsbDriver.Image")));
            this.tsbDriver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDriver.Name = "tsbDriver";
            this.tsbDriver.Size = new System.Drawing.Size(63, 33);
            this.tsbDriver.Text = "Driver";
            this.tsbDriver.Click += new System.EventHandler(this.tsbDriver_Click);
            // 
            // tsbUpdates
            // 
            this.tsbUpdates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsbUpdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdates.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdates.Image")));
            this.tsbUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdates.Name = "tsbUpdates";
            this.tsbUpdates.Size = new System.Drawing.Size(74, 33);
            this.tsbUpdates.Text = "&Update";
            this.tsbUpdates.ToolTipText = "Check for Updates";
            this.tsbUpdates.Click += new System.EventHandler(this.tsbUpdates_Click);
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
            this.dDetailsControl.Location = new System.Drawing.Point(8, 43);
            this.dDetailsControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dDetailsControl.MaximumSize = new System.Drawing.Size(746, 665);
            this.dDetailsControl.MinimumSize = new System.Drawing.Size(746, 665);
            this.dDetailsControl.Name = "dDetailsControl";
            this.dDetailsControl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dDetailsControl.Size = new System.Drawing.Size(746, 665);
            this.dDetailsControl.TabIndex = 0;
            this.dDetailsControl.UpdateInterval = 1000;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 712);
            this.Controls.Add(this.dDetailsControl);
            this.Controls.Add(this.tsToolStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "X-Dream Bike Diagnostic UI";
            this.tsToolStrip.ResumeLayout(false);
            this.tsToolStrip.PerformLayout();
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
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ToolStripButton tsbDriver;
        private Details dDetailsControl;
        private System.Windows.Forms.ToolStripButton tsbUpdates;
    }
}

