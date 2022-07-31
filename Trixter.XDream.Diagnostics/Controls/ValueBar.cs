using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Trixter.XDream.Diagnostics.Controls
{
    public class ValueBar : Label
    {
        private Brush barBrush;
        private int value;
        private double scale;
        private Rectangle? barRect;

        private int maximum = 100;
        private Orientation orientation = Orientation.Horizontal;


        private void Rescale()
        {
            Rectangle client = ClientRectangle;
            barRect = null;

            scale = (double)(Orientation == Orientation.Horizontal ? client.Width : client.Height) / maximum;
            Invalidate();
        }

        [Browsable(true), Category(Constants.AppearanceCategory)]
        public Orientation Orientation
        {
            get => orientation;
            set
            {
                if (orientation != value)
                {
                    orientation = value;
                    barRect = null;
                    Rescale();
                }
            }
        }

        /// <summary>
        /// If set to true, out of range values are clipped to the Minimum and Maximum. Otherwise an execption is thrown.
        /// </summary>
        [Browsable(true), Category(Constants.BehaviorCategory)]
        public bool ClipOutOfRangeValues { get; set; }


        [Browsable(true), Category(Constants.AppearanceCategory)]
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

        [Browsable(true), Category(Constants.ValueCategory)]
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    if (value < 0 || value > Maximum)
                    {
                        if (!ClipOutOfRangeValues)
                            throw new ArgumentOutOfRangeException(nameof(value));
                        value = Math.Max(0, Math.Min(Maximum, value));
                    }
                    this.value = value;
                    barRect = null;
                    Invalidate();
                }

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (barRect == null)
                CalculateBar();

            Rectangle b = barRect.Value;
            b.Intersect(e.ClipRectangle);
            e.Graphics.FillRectangle(barBrush, b);
        }

        public ValueBar()
        {
            DoubleBuffered = true;
            AutoSize = false;
            Text = "";
            barBrush = new SolidBrush(ForeColor);

            Resize += delegate { Rescale(); };
            ForeColorChanged += (s, e) =>
            {
                barBrush = new SolidBrush(ForeColor);
            };
            ForeColor = SystemColors.HotTrack;
        }

        private void CalculateBar()
        {
            Rectangle rect = ClientRectangle;
            Size size;
            Point location;

            if (Orientation == Orientation.Horizontal)
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
