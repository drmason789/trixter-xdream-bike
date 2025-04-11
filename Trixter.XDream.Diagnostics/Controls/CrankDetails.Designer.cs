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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbCrankDetails = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbCrankDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCrankDetails
            // 
            this.gbCrankDetails.Controls.Add(this.chart1);
            this.gbCrankDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCrankDetails.Location = new System.Drawing.Point(0, 0);
            this.gbCrankDetails.Name = "gbCrankDetails";
            this.gbCrankDetails.Size = new System.Drawing.Size(677, 643);
            this.gbCrankDetails.TabIndex = 0;
            this.gbCrankDetails.TabStop = false;
            this.gbCrankDetails.Text = "Crank Diagnostics";
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 59D;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisX2.Maximum = 60D;
            chartArea1.AxisX2.Minimum = 1D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 22);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(671, 618);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chCrankPositions";
            // 
            // CrankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCrankDetails);
            this.Name = "CrankDetails";
            this.Size = new System.Drawing.Size(677, 643);
            this.gbCrankDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCrankDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
