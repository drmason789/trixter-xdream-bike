using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class StateMonitorTests
    {
        /// <summary>
        /// All individual <see cref="XDreamStateChanges"/> values.
        /// </summary>
        static readonly XDreamStateChanges[] allChanges = Enum.GetValues(typeof(XDreamStateChanges)).Cast<XDreamStateChanges>().Where(x => x != XDreamStateChanges.Buttons).ToArray();

        /// <summary>
        /// A mapping of <see cref="XDreamStateChanges"/> to an action that modifies an <see cref="XDreamStateBuilder"/> object to produce that change.
        /// </summary>
        static readonly Dictionary<XDreamStateChanges, Action<XDreamStateBuilder>> mockers = new Dictionary<XDreamStateChanges, Action<XDreamStateBuilder>>
            {
                { XDreamStateChanges.Blue, s => ChangeButton(s, XDreamControllerButtons.Blue) },
                { XDreamStateChanges.Green, s => ChangeButton(s, XDreamControllerButtons.Green) },
                { XDreamStateChanges.Red, s => ChangeButton(s, XDreamControllerButtons.Red) },
                { XDreamStateChanges.BackGearDown, s => ChangeButton(s, XDreamControllerButtons.BackGearDown) },
                { XDreamStateChanges.BackGearUp, s => ChangeButton(s, XDreamControllerButtons.BackGearUp) },
                { XDreamStateChanges.FrontGearDown, s => ChangeButton(s, XDreamControllerButtons.FrontGearDown) },
                { XDreamStateChanges.FrontGearUp, s => ChangeButton(s, XDreamControllerButtons.FrontGearUp) },
                { XDreamStateChanges.LeftArrow, s => ChangeButton(s, XDreamControllerButtons.LeftArrow) },
                { XDreamStateChanges.RightArrow, s => ChangeButton(s, XDreamControllerButtons.RightArrow) },
                { XDreamStateChanges.UpArrow, s => ChangeButton(s, XDreamControllerButtons.UpArrow) },
                { XDreamStateChanges.DownArrow, s => ChangeButton(s, XDreamControllerButtons.DownArrow) },
                { XDreamStateChanges.Seated, s => ChangeButton(s, XDreamControllerButtons.Seated) },

                { XDreamStateChanges.Crank, s => ChangeCrank(s) },
                { XDreamStateChanges.RightBrake, s => ChangeRightBrake(s) },
                { XDreamStateChanges.LeftBrake, s => ChangeLeftBrake(s) },
                { XDreamStateChanges.HeartRate, s => ChangeHeartRate(s) },
                { XDreamStateChanges.CrankPosition, s => ChangeCrankPosition(s) },
                { XDreamStateChanges.Flywheel, s => ChangeFlywheel(s) },
                { XDreamStateChanges.Steering, s => ChangeSteering(s) }
            };

        /// <summary>
        /// Generate an array of all combinations of <see cref="XDreamStateChanges"/>.
        /// </summary>
        /// <returns></returns>
        private static XDreamStateChanges[] GetAllCombinations()
        {
            // Assumes that XDreamStateChanges has no skipped values
            return Enumerable.Range(1, 2 * allChanges.Cast<int>().Max()-1).Select(i => (XDreamStateChanges)i).ToArray();
        }

        private static void ChangeSteering(XDreamStateBuilder state)
        {
            if (state.Steering > 100)
                state.Steering--;
            else
                state.Steering++;
        }

        private static int ChangeBrake(int level)
        {
            if (level > Constants.MinBrake)
                return level - 1;
            return level + 1;
        }

        private static void ChangeLeftBrake(XDreamStateBuilder state)
            => state.LeftBrake = ChangeBrake(state.LeftBrake);

        private static void ChangeRightBrake(XDreamStateBuilder state)
            => state.RightBrake = ChangeBrake(state.RightBrake);

        private static void ChangeCrank(XDreamStateBuilder state)
        {
            if (state.Crank > 1000)
                state.Crank--;
            else
                state.Crank++;
        }

        private static void ChangeCrankPosition(XDreamStateBuilder state)
            => state.CrankPosition = CrankPositions.Add(state.CrankPosition, 1);


        private static void ChangeHeartRate(XDreamStateBuilder state)
        {
            if (state.HeartRate < 200)
                state.HeartRate++;
            else state.HeartRate--;
        }

        private static void ChangeFlywheel(XDreamStateBuilder state)
        {
            if (state.Flywheel > 1000)
                state.Flywheel--;
            else
                state.Flywheel++;
        }

        private static void ChangeButton(XDreamStateBuilder state, XDreamControllerButtons button)
        {
            if (state.Buttons.HasFlag(button))
                state.Buttons &= ~button;
            else
                state.Buttons |= button;
        }

        private void ConcoctTest(XDreamStateBuilder state0, XDreamStateChanges changes)
        {
            foreach (var change in allChanges.Where(x => (x & changes) != 0))
                mockers[change](state0);
        }


        public void TestCombination(XDreamStateChanges change)
        {
            List<XDreamStateChangeEventArgs> args = new List<XDreamStateChangeEventArgs>();
            XDreamStateMonitor monitor = new XDreamStateMonitor();
            monitor.Change += (s, e) => { lock (args) args.Add(e); };
            DateTimeOffset t0 = DateTimeOffset.UtcNow;
            XDreamStateBuilder builder = new XDreamStateBuilder();

            builder.Steering = 128;
            builder.RightBrake = Constants.MaxBrake;
            builder.LeftBrake = Constants.MaxBrake;
            builder.Buttons = XDreamControllerButtons.None;
            builder.Crank = 0;
            builder.CrankPosition = 1;
            builder.HeartRate = 0;
            builder.Flywheel = 65534;
            builder.TimeStamp = t0;
            XDreamState state0 = builder.ToReadOnly();
            ConcoctTest(builder, change);
            XDreamState state1 = builder.ToReadOnly();

            monitor.UpdateMessage(state0);
            monitor.UpdateMessage(state1);

            Assert.AreEqual(1, args.Count, $"Nothing for {change}");
            Assert.AreEqual(change, args[0].Changes, $"{change} not detected");
            Assert.AreEqual(args[0].State, state1, $"Current state not set properly for {change}");
            Assert.AreEqual(args[0].PreviousState, state0, $"Previous state not set properly for {change}");

        }


        [Test(Description ="Test every combination of change type.")]

        public void TestAllCombinations()
        {
            var allCombinations = GetAllCombinations();

            foreach (var change in allCombinations)
            {
                TestCombination(change);
            }

        }

        [Test(Description ="A test that uses real data, obtained from a real X-Dream bike, with a real person pedalling, pushing buttons and pulling levers.")]
        public void KeepingItReal()
        {
            Random random = new Random();
            DateTimeOffset t = DateTimeOffset.UtcNow;
            Func<DateTimeOffset> getTimestamp = () => t = t.AddMilliseconds(11d + (1d - 2 * random.NextDouble()));
            var states = XDreamMessageIO.GetStates(Resources.input, getTimestamp);
            List<XDreamStateChangeEventArgs> stateChanges = new List<XDreamStateChangeEventArgs>();

            XDreamStateMonitor monitor = new XDreamStateMonitor();

            monitor.Change += (s, e) =>
            {
                lock (stateChanges)
                    stateChanges.Add(e);
            };

            foreach (var state in states)
                monitor.UpdateMessage(state);


            Assert.AreEqual(1600, stateChanges.Count);

        }

    }
}
