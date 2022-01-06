using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Trixter.XDream.API.Flywheel;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Implementation of <see cref="XDreamMachine"/>.
    /// </summary>
    public class XDreamBike : ThreadLockable, XDreamMachine, IDisposable
    {
        
        // Using member fields for access to all members of actual rather than publically exposed type
        private ThreadSafeFlywheelMeter flywheelMeter;
        private ThreadSafeCrankMeter crankMeter;
        private ThreadSafeTripMeter tripMeter;
        private ThreadSafePowerMeter powerMeter;

        private ConcurrentQueue<XDreamState> stateQueue;
        private XDreamState state;        
        private BackgroundWorker queueProcessor;


        public event XDreamStateUpdatedDelegate<XDreamMachine> StateUpdated;

        protected virtual void OnStateUpdated(XDreamState state) => this.StateUpdated?.Invoke(this, state);

        public XDreamClient DataSource { get; }

        public IFlywheelMeter FlywheelMeter => this.flywheelMeter;

        public ICrankMeter CrankMeter => this.crankMeter;

        public ITripMeter TripMeter => this.tripMeter;

        public IPowerMeter PowerMeter => this.powerMeter;

        public XDreamState State => this.DoLocked(() => this.state);

        public int Resistance
        {
            get => this.DataSource.Resistance;
            set => this.DataSource.Resistance = value;
        }
     
        public XDreamBike(XDreamClient dataSource, IFlywheelMeter flywheelMeter, ICrankMeter crankMeter)
        {
            this.DataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            this.flywheelMeter = ThreadSafeFlywheelMeter.TryCreate(flywheelMeter) ?? throw new ArgumentNullException(nameof(flywheelMeter));
            this.crankMeter = ThreadSafeCrankMeter.TryCreate(crankMeter) ?? throw new ArgumentNullException(nameof (crankMeter));
            this.tripMeter = ThreadSafeTripMeter.TryCreate(new TripMeter(flywheelMeter, crankMeter));
            this.powerMeter = ThreadSafePowerMeter.TryCreate(new PowerMeter(XDreamFlywheel.Default.MomentOfInertia));
            this.flywheelMeter.SyncRoot = this.SyncRoot;
            this.crankMeter.SyncRoot = this.SyncRoot;
            this.tripMeter.SyncRoot = this.SyncRoot;
            this.powerMeter.SyncRoot = this.SyncRoot;
            this.stateQueue = new ConcurrentQueue<XDreamState>();

            this.DataSource.StateUpdated += DataSource_StateUpdated;

            this.queueProcessor = new BackgroundWorker();
            this.queueProcessor.WorkerSupportsCancellation = true;
            this.queueProcessor.DoWork += QueueProcessor_DoWork;
            this.queueProcessor.RunWorkerAsync();
        }

        private void QueueProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.queueProcessor.CancellationPending)
            {
                while (!this.queueProcessor.CancellationPending && this.stateQueue.TryDequeue(out var newState))
                {
                    lock (this.SyncRoot)
                    {
                        if (this.state?.TimeStamp >= newState.TimeStamp)
                            continue; // TODO: warning log

                        this.FlywheelMeter.AddData(newState);
                        this.CrankMeter.AddData(newState);
                        this.PowerMeter.Update(newState.TimeStamp, this.FlywheelMeter.RPM);
                        this.TripMeter.Update(newState.TimeStamp);

                        this.state = newState;
                    }

                    this.OnStateUpdated(newState);
                }
                Thread.Sleep(1);
            }

        }

        private void DataSource_StateUpdated(XDreamClient sender, XDreamState state)
        {
            // Quickly put the new state on the queue and go back to monitoring
            this.stateQueue.Enqueue(state);
        }        
        
        public void Dispose()
        {
            if (this.queueProcessor != null)
            {
                this.queueProcessor.CancelAsync();

                // wait a few ms for the processing to stop
                for (DateTimeOffset start = DateTimeOffset.Now;
                    this.queueProcessor.CancellationPending && DateTimeOffset.Now.Subtract(start).TotalMilliseconds < 500;) { }

                this.queueProcessor.Dispose();
                this.queueProcessor = null;
            }
        }
       

    }
}