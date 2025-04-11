using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.API;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trixter.XDream.Diagnostics.Controls
{
    public partial class CrankDetails : UserControl
    {
        int[] crankPositionVisits = new int[CrankPositions.MaxCrankPosition];
        bool seriesChanged = false;

        DateTimeOffset lastUpdate;
        public CrankDetails()
        {
            InitializeComponent();
                        
            Random random = new Random(242);
            var series = this.chart1.Series[0];
            for (int x = 1; x <= CrankPositions.MaxCrankPosition; x++)
            {
                DataPoint dataPoint = new DataPoint(x, 10 + random.Next(3));
                series.Points.Add(dataPoint);
            }
        }

        public void UpdateSeries()
        {

            if (!seriesChanged)
                return;

            if(DateTimeOffset.UtcNow - this.lastUpdate < TimeSpan.FromMilliseconds(500))
                return;

            this.lastUpdate = DateTimeOffset.UtcNow;

            var series = this.chart1.Series[0];
            int max = 0;

            for(int i=0; i < CrankPositions.MaxCrankPosition; i++)
            {
                series.Points[i].YValues[0] = this.crankPositionVisits[i];
                max = Math.Max(max, this.crankPositionVisits[i]);
            }
                       
            max = (max / 50) * 50 + 50;

            this.chart1.ChartAreas[0].AxisY.Maximum = max;
            this.chart1.Invalidate();

            this.seriesChanged = false;
        }

        public void VisitCrankPosition(int crankPosition)
        {
            this.crankPositionVisits[crankPosition - 1] += 1;
            this.seriesChanged = true;
        }
    }
}
