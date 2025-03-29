using NUnit.Framework;
using System;
using System.Threading;

namespace Trixter.XDream.API.Testing.Experimental
{
    [TestFixture]
    public class ActivationMonitorTests
    {
        private ActivationMonitor monitor;
        private bool eventTriggered;
        private bool eventState;

        private long currentTime;

        [SetUp]
        public void Setup()
        {
            currentTime = 9834982; // Some arbitrary time

            monitor = new ActivationMonitor(1000, () => currentTime)
            {
                ActivationThreshold = 0.6,
                DeactivationThreshold = 0.4,
            };

            eventTriggered = false;
            eventState = false;

            monitor.ActivationChanged += (s, e) =>
            {
                eventTriggered = true;
                eventState = e;
            };
        }

        private void AdvanceTimeByMilliseconds(int milliseconds)
        {
            currentTime += TimeSpan.FromMilliseconds(milliseconds).Ticks;
        }

        [Test]
        public void Update_TriggersActivation_WhenThresholdIsExceeded()
        {
            monitor.Update(true);
            monitor.Update(true);
            monitor.Update(true);

            AdvanceTimeByMilliseconds(10);

            Assert.That(eventTriggered, Is.True);
            Assert.That(eventState, Is.True);
            Assert.That(monitor.IsActive, Is.True);
        }

        [Test]
        public void Update_TriggersDeactivation_WhenThresholdFallsBelow()
        {
            monitor.Update(true);
            monitor.Update(true);
            monitor.Update(true);

            AdvanceTimeByMilliseconds(10);
            Assert.That(monitor.IsActive, Is.True);

            // Simulate deactivation by adding false samples
            eventTriggered = false;
            monitor.Update(false);
            monitor.Update(false);
            monitor.Update(false);

            AdvanceTimeByMilliseconds(10);

            Assert.That(eventTriggered, Is.True);
            Assert.That(eventState, Is.False);
            Assert.That(monitor.IsActive, Is.False);
        }

        [Test]
        public void Update_DoesNotTriggerEvent_IfStateRemainsSame()
        {
            monitor.Update(true);
            monitor.Update(true);

            AdvanceTimeByMilliseconds(10);

            Assert.That(eventTriggered, Is.True);
            Assert.That(monitor.IsActive, Is.True);

            eventTriggered = false;

            monitor.Update(true);
            monitor.Update(true);

            AdvanceTimeByMilliseconds(10);

            Assert.That(eventTriggered, Is.False);
            Assert.That(monitor.IsActive, Is.True);
        }

        [Test]
        public void IsActive_ReturnsFalse_Initially()
        {
            Assert.That(monitor.IsActive, Is.False);
        }
            
        [Test]
        public void Thresholds_CanBeModified()
        {
            monitor.ActivationThreshold = 0.8;
            monitor.DeactivationThreshold = 0.2;

            Assert.That(monitor.ActivationThreshold, Is.EqualTo(0.8));
            Assert.That(monitor.DeactivationThreshold, Is.EqualTo(0.2));
        }
    }

}
