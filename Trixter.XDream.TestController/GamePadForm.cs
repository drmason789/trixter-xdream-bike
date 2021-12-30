using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trixter.XDream.API;

namespace Trixter.XDream.TestController
{
    partial class GamePadForm : Form
    {
        const int controlRadius = 5;

        private Point controlPoint;
        private Point controlOrigin;
        bool controlling=false;
        private Controller controller;
        private Dictionary<Keys, Control> keyButton;

        private Rectangle ControlRect => new Rectangle(controlPoint.X - controlRadius, controlPoint.Y - controlRadius, 2 * controlRadius, 2 * controlRadius);

        public Controller Controller
        {
            get => this.controller;
            set
            {
                if (this.controller != null)
                    throw new InvalidOperationException();

                this.controller = value;
                this.cbSeated.Checked = this.controller.State.Seated;


            }
        }

        public GamePadForm()
        {
            InitializeComponent();
            

            this.CenterControlPoint();

            var rect = this.pnlControl.ClientRectangle;
            this.controlPoint  = this.controlOrigin = new Point((rect.Left + rect.Right) >> 1, (rect.Top + rect.Bottom) * 3 / 4);

            this.bnLeft.Tag = XDreamControllerButtons.LeftArrow;
            this.bnRight.Tag = XDreamControllerButtons.RightArrow;
            this.bnUp.Tag = XDreamControllerButtons.UpArrow;
            this.bnDown.Tag = XDreamControllerButtons.DownArrow;

            this.bnLeftGearDown.Tag = XDreamControllerButtons.FrontGearDown;
            this.bnLeftGearUp.Tag = XDreamControllerButtons.FrontGearUp;
            this.bnRightGearUp.Tag = XDreamControllerButtons.BackGearUp;
            this.bnRightGearDown.Tag = XDreamControllerButtons.BackGearDown;

            this.bnRed.Tag = XDreamControllerButtons.Red;
            this.bnBlue.Tag = XDreamControllerButtons.Blue;
            this.bnGreen.Tag = XDreamControllerButtons.Green;


            this.keyButton = new Dictionary<Keys, Control>();
            this.keyButton.Add(Keys.Space, cbSeated);
            this.keyButton.Add(Keys.Up, bnUp);
            this.keyButton.Add(Keys.Down, bnDown);
            this.keyButton.Add(Keys.Left, bnLeft);
            this.keyButton.Add(Keys.Right, bnRight);

            this.keyButton.Add(Keys.Enter, bnGreen);
            this.keyButton.Add(Keys.Escape, bnRed);
            this.keyButton.Add(Keys.V, bnBlue);

            this.keyButton.Add(Keys.Insert, bnLeftGearUp);
            this.keyButton.Add(Keys.Delete, bnLeftGearDown);

            this.keyButton.Add(Keys.PageUp, bnRightGearUp);
            this.keyButton.Add(Keys.PageDown, bnRightGearDown);
        }

        private void CenterControlPoint()
        {
            this.controlPoint = this.controlOrigin;
        }

        private bool InControlCircle(Point location)
        {
            int dx = location.X - this.controlPoint.X;
            int dy = location.Y - this.controlPoint.Y;

            return dx * dx + dy * dy <= controlRadius * controlRadius;
        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, ControlRect);
            e.Graphics.DrawLine(Pens.Black, controlOrigin, controlPoint);
        }

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.controlling = this.InControlCircle(e.Location);
            this.UpdateController(e.Location);
        }

        private void pnlControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.controlling)
            {
                this.CenterControlPoint();
                this.pnlControl.Invalidate();
                this.UpdateController(this.controlPoint);
            }

            this.controlling = false;
        }

        private void UpdateController(Point location)
        {
            Rectangle rect = pnlControl.ClientRectangle;


            if (!rect.Contains(location))
            {
                // crop to the client rectangle
                location = new Point(Math.Max(0, Math.Min(rect.Right, location.X)), Math.Max(0, Math.Min(rect.Bottom, location.Y)));
            }
            
            this.controlPoint = location;
            this.pnlControl.Invalidate();

            controller.State.Steering = (int)(255d * this.controlPoint.X / rect.Width);

            int dY = this.controlOrigin.Y - this.controlPoint.Y;

            if (dY == 0)
            {
                controller.CrankRPM = 0;
                controller.State.LeftBrake = controller.State.RightBrake = Constants.MaxBrake;
            }
            else if (dY > 0)
            {
                controller.CrankRPM = (int)(300d * dY / this.controlOrigin.Y);
                controller.State.LeftBrake = controller.State.RightBrake = Constants.MaxBrake;
            }
            else
            {
                controller.CrankRPM = 0;
                controller.State.LeftBrake = 
                    controller.State.RightBrake =
                    (int)(Constants.MaxBrake + (double)(Constants.MaxBrake - Constants.MinBrake) * dY / (rect.Height - this.controlOrigin.Y));
            }

            controller.Send();
        }

        private void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.controlling)
                return;

            this.UpdateController(e.Location);
        }

        private void Button_Released(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            XDreamControllerButtons xdb = (XDreamControllerButtons)button.Tag;

            controller.State.Buttons &= ~xdb;
            controller.Send();
        }

        private void Button_Pressed(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            XDreamControllerButtons xdb = (XDreamControllerButtons)button.Tag;

            controller.State.Buttons |= xdb;
            controller.Send();
        }

        private void cbSeated_CheckedChanged(object sender, EventArgs e)
        {
            controller.State.Seated = this.cbSeated.Checked;
            controller.Send();
        }

        private void GamePadForm_KeyDown(object sender, KeyEventArgs e)
        {
          if(!e.Control && !e.Alt && this.keyButton.TryGetValue(e.KeyCode, out var control))
          {
                if (control is CheckBox cb)
                    cb.Checked = !cb.Checked;
                else if (control is Button b)
                    this.Button_Pressed(b, null);

                e.Handled = true;
          }

        }

        private void GamePadForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && this.keyButton.TryGetValue(e.KeyCode, out var control))
            {
                if (control is CheckBox cb)
                    cb.Checked = !cb.Checked;
                else if (control is Button b)
                    this.Button_Released(b, null);
                e.Handled = true;
            }
        }
    }
}
