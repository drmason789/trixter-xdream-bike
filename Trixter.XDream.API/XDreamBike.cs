using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

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

        private ConcurrentQueue<XDreamState> stateQueue;
        private XDreamState state;        
        private BackgroundWorker queueProcessor;


        public event XDreamStateUpdatedDelegate<XDreamMachine> StateUpdated;

        protected virtual void OnStateUpdated(XDreamState state) => this.StateUpdated?.Invoke(this, state);

        public XDreamClient DataSource { get; }

        public IFlywheelMeter FlywheelMeter => this.flywheelMeter;

        public ICrankMeter CrankMeter => this.crankMeter;

        public ITripMeter TripMeter => this.tripMeter;

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

            this.flywheelMeter.SyncRoot = this.SyncRoot;
            this.crankMeter.SyncRoot = this.SyncRoot;
            this.tripMeter.SyncRoot = this.SyncRoot;
            this.stateQueue = new ConcurrentQueue<XDreamState>();

            this.DataSource.StateUpdated += DataSource_StateUpdated;

            this.queueProcessor = new BackgroundWorker();
            this.queueProcessor.DoWork += QueueProcessor_DoWork;
            this.queueProcessor.RunWorkerAsync();
            
        }

        private void QueueProcessor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.queueProcessor.CancellationPending)
            {
                while (!this.queueProcessor.CancellationPending && this.stateQueue.TryDequeue(out var state))
                {
                    lock (this.SyncRoot)
                    {
                        this.FlywheelMeter.AddData(state);
                        this.CrankMeter.AddData(state);
                        this.TripMeter.Update(state.TimeStamp);
                        this.state = state;
                    }

                    this.OnStateUpdated(state);
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
            this.queueProcessor?.Dispose();
            this.queueProcessor = null;
        }
       

    }
}