using System;
using System.Collections;

namespace Trixter.XDream.API
{
    public class ThreadLockable
    {
        private object syncRoot;

        public object SyncRoot
        {
            get => this.syncRoot;
            set => this.syncRoot = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected T DoLocked<T>(Func<T> func) 
        {
            lock(this.SyncRoot)
                return func();
        }

        protected void DoLocked(Action action)
        {
            lock (this.SyncRoot) 
                action();
        }

        public ThreadLockable() : this(new object())
        {
           
        }

        public ThreadLockable(object syncRoot)
        {
            this.SyncRoot  = syncRoot; 
        }
    }
}
