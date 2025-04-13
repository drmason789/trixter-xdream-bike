using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.Diagnostics.Controls
{
    public partial class CrankDetails : UserControl
    {
        const int updateIntervalMilliseconds = 500;
        const int currentPositionIntervalMilliseconds = 1000;

        object sync = new object();

        long[] crankPositionVisits = new long[CrankPositions.MaxCrankPosition];
        Label[] labels;
        Color unvisited = Color.Red, visited = Color.Black, current = Color.DodgerBlue;
        bool paused = false;
        DateTimeOffset lastUpdate;

        public CrankDetails()
        {
            InitializeComponent();

            this.lbCurrentColor.BackColor = current;
            this.lbReportedColor.BackColor = visited;
            this.lbUnreportedColor.BackColor = unvisited;

            this.DoubleBuffered = true;

            this.lbCurrent.Text = $"Reported within {currentPositionIntervalMilliseconds}ms";

            this.labels = new Label[CrankPositions.MaxCrankPosition];

            for (int i = 0; i < CrankPositions.MaxCrankPosition; i++)
            {
                var position = (i + 1).ToString();

                labels[i] = new Label
                {
                    Name = "lblPosition" + position,
                    Location = new Point(0, 0),
                    Width = 10,
                    Height = 10,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = unvisited,
                };

                this.toolTips.SetToolTip(labels[i], position);

                this.crankPositionVisits[i] = 0;
            }

            this.pnlLabels.Controls.AddRange(labels);

            this.pnlLabels.Resize += (s, e) => { this.UpdatePositions(); };


        }

        private void UpdatePositions()
        {
            var clientSize = this.pnlLabels.ClientSize;
            int m = Math.Min(clientSize.Width, clientSize.Height);
            int C = (int)(0.4 * m);
            int labelSize = 12;

            Point origin = new Point((clientSize.Width - labelSize) >> 1, (clientSize.Height - labelSize) >> 1);

            for (int i = 0; i < CrankPositions.MaxCrankPosition; i++)
            {
                double angle = i * CrankPositions.RadiansPerPosition;

                int y = origin.Y + (int)(Math.Sin(angle) * C);
                int x = origin.X + (int)(Math.Cos(angle) * C);
                int position = i + 1;

                Label label = this.labels[i];

                label.Location = new Point(x, y);
                label.Width = labelSize;
                label.Height = labelSize;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lock (this.sync)
            {
                this.crankPositionVisits = new long[CrankPositions.MaxCrankPosition];
                this.UpdateSeries(true);
                this.Invalidate();
            }
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            lock (this.sync)
            {
                this.btnPauseResume.Text = !this.paused ? "Resume" : "Pause";
                this.paused = !this.paused;
            }
        }

        public void UpdateSeries(bool force =false)
        {
            lock (this.sync)
            {

                if (!force && paused)
                    return;

                if (DateTimeOffset.UtcNow - this.lastUpdate < TimeSpan.FromMilliseconds(updateIntervalMilliseconds))
                    return;

                long then = DateTimeOffset.UtcNow.Ticks - TimeSpan.FromMilliseconds(currentPositionIntervalMilliseconds).Ticks;
                Color defaultColor = gbCrankDetails.BackColor;

                for (int i = 0; i < labels.Length; i++)
                {
                    Color color = defaultColor;
                    if (this.crankPositionVisits[i] == 0)
                        color = unvisited; // never visited
                    else if (this.crankPositionVisits[i] < then)
                        color = visited; // visited
                    else
                        color = current;
                    this.labels[i].BackColor = color;
                }

                this.lastUpdate = DateTimeOffset.UtcNow;
            }
        }

        public void VisitCrankPosition(int crankPosition)
        {
            lock (this.sync)
            {
                this.crankPositionVisits[crankPosition - 1] = DateTimeOffset.UtcNow.Ticks;
            }
        }
    }
}
