using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Trixter.XDream.Diagnostics
{
    public class ValueBar : Label
    {
        const string appearanceCategory = "Appearance";
        const string valueCategory = "Value";
        const string behaviorCategory = "Behavior";

        private Brush barBrush;
        private int value;
        private double scale;
        private Rectangle? barRect;
            
        private int maximum = 100;
        private Orientation orientation = Orientation.Horizontal;
       
                
        private void Rescale()
        {
            Rectangle client = this.ClientRectangle;
            barRect = null;
                       
            scale = (double)(this.Orientation==Orientation.Horizontal ? client.Width:client.Height) / maximum;            
            Invalidate();
        }

        [Browsable(true), Category(appearanceCategory)]
        public Orientation Orientation
        {
            get => orientation;
            set
            {
                if (this.orientation!=value)
                {
                    this.orientation = value;
                    barRect = null;
                    Rescale();
                }
            }
        }

        /// <summary>
        /// If set to true, out of range values are clipped to the Minimum and Maximum. Otherwise an execption is thrown.
        /// </summary>
        [Browsable(true), Category(behaviorCategory)]
        public bool ClipOutOfRangeValues { get; set; }
        

        [Browsable(true), Category(appearanceCategory)]
        public int Maximum
        {
            get => maximum;
            set
            {
                if (value > 0)
                {
                    maximum = value;
                    barRect = null;
                    Rescale();
                }
                else throw new ArgumentException(nameof(value));
            }
        }

        [Browsable(true), Category(valueCategory)]
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    if (value < 0 || value > this.Maximum)
                    {
                        if(!this.ClipOutOfRangeValues)
                            throw new ArgumentOutOfRangeException(nameof(value));
                        value = Math.Max(0, Math.Min(this.Maximum, value));
                    }
                    this.value = value;
                    barRect = null;
                    this.Invalidate();
                }

            }
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            if (barRect == null)
                CalculateBar();

            Rectangle b = barRect.Value;
            b.Intersect(e.ClipRectangle);
            e.Graphics.FillRectangle(this.barBrush, b);
        }

        public ValueBar()
        {
            this.DoubleBuffered = true;
            this.AutoSize = false;
            this.Text = "";
            this.barBrush = new SolidBrush(this.ForeColor);

            this.Resize += delegate { Rescale(); };
            this.ForeColorChanged += (s, e) =>
            {
                this.barBrush = new SolidBrush(this.ForeColor);
            };
            this.ForeColor = SystemColors.HotTrack;
        }

        private void CalculateBar()
        {
            Rectangle rect = this.ClientRectangle;
            Size size;
            Point location;

            if (this.Orientation == Orientation.Horizontal)
            {
                location = rect.Location;
                size = new Size((int)(value * scale), rect.Height);
            }
            else
            {
                size = new Size(rect.Width, (int)(value * scale));
                location = new Point(rect.X, rect.Bottom - size.Height);                
            }

            barRect = new Rectangle(location, size);

        }
    }
}
