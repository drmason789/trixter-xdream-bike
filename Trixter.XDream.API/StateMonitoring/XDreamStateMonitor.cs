using System;
using System.Linq;
using System.Threading.Tasks;

namespace Trixter.XDream.API
{
    public delegate void XDreamStateChangeEventDelegate(XDreamStateMonitor sender, XDreamStateChangeEventArgs args);

    public class XDreamStateMonitor
    {
        private XDreamState previousState;

        /// <summary>
        /// Select the changes that are reported.
        /// </summary>
        public XDreamStateChanges Filter { get; set; } =
            Enum.GetValues(typeof(XDreamStateChanges)).Cast<XDreamStateChanges>().Aggregate((a, b) => a | b);           
           
        /// <summary>
        /// Change event.
        /// </summary>
        public event XDreamStateChangeEventDelegate Change;

        /// <summary>
        /// If the <see cref="Change"/> event is assigned, creates a new <see cref="XDreamStateChangeEventArgs"/> object and invokes it.
        /// </summary>
        /// <param name="changes"></param>
        /// <param name="message"></param>
        protected virtual void OnChange(XDreamStateChanges changes, XDreamState message)
        {
            if (this.Change != null)
                this.Change.Invoke(this, new XDreamStateChangeEventArgs(changes, message, this.previousState));
        }

        /// <summary>
        /// Reset the previous state to nothing.
        /// </summary>
        public void Reset()
        {
            this.previousState = null;
        }

        /// <summary>
        /// Update the monitor with a new state.
        /// </summary>
        /// <param name="state"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateMessage(XDreamState state)
        {
            XDreamStateChanges changes = XDreamStateChanges.None;

            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (previousState == null || this.Change==null || this.Filter==XDreamStateChanges.None)
            {
                this.previousState = state;
                return;
            }

            if (state.Buttons != previousState.Buttons)
            {
                if (state.LeftArrow != this.previousState.LeftArrow) changes |= XDreamStateChanges.LeftArrow;
                if (state.RightArrow != this.previousState.RightArrow) changes |= XDreamStateChanges.RightArrow;
                if (state.UpArrow != this.previousState.UpArrow) changes |= XDreamStateChanges.UpArrow;
                if (state.DownArrow != this.previousState.DownArrow) changes |= XDreamStateChanges.DownArrow;
                if (state.Blue != this.previousState.Blue) changes |= XDreamStateChanges.Blue;
                if (state.Red != this.previousState.Red) changes |= XDreamStateChanges.Red;
                if (state.Green != this.previousState.Green) changes |= XDreamStateChanges.Green;
                if (state.Seated != this.previousState.Seated) changes |= XDreamStateChanges.Seated;
                if (state.FrontGearUp != this.previousState.FrontGearUp) changes |= XDreamStateChanges.FrontGearUp;
                if (state.FrontGearDown != this.previousState.FrontGearDown) changes |= XDreamStateChanges.FrontGearDown;
                if (state.BackGearUp != this.previousState.BackGearUp) changes |= XDreamStateChanges.BackGearUp;
                if (state.BackGearDown != this.previousState.BackGearDown) changes |= XDreamStateChanges.BackGearDown;
            }

            if (state.Steering!=this.previousState.Steering) changes |= XDreamStateChanges.Steering;
            if (state.LeftBrake != this.previousState.LeftBrake) changes |= XDreamStateChanges.LeftBrake;
            if (state.RightBrake != this.previousState.RightBrake) changes |= XDreamStateChanges.RightBrake;
            if (state.Flywheel != this.previousState.Flywheel) changes |= XDreamStateChanges.Flywheel;
            if (state.Crank != this.previousState.Crank) changes |= XDreamStateChanges.Crank;
            if (state.HeartRate != this.previousState.HeartRate) changes |= XDreamStateChanges.HeartRate;
            if (state.CrankPosition != this.previousState.CrankPosition) changes |= XDreamStateChanges.CrankPosition;

            changes &= this.Filter;

            if (changes != XDreamStateChanges.None)
                this.OnChange(changes, state);         

            this.previousState = state;
        }
    }
}
