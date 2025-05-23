using System;
using System.Collections;
using System.Collections.Generic;

namespace Trixter.XDream.API.Filters
{
    internal class SampleList : IEnumerable<Sample>
    {
        /// <summary>
        /// Delegate to be called when a sample is to be removed from the list.
        /// Used to update statistics.
        /// </summary>
        /// <param name="removing">The sample that is to be removed.</param>
        /// <param name="limit">The lower limit on <see cref="Sample.T"/></param>
        /// <param name="remove">Signals if the sample can be removed entirely, not just deactivated.</param>
        public delegate void RemoveSampleDelegate(Sample removing, double limit, out bool remove);

        public Sample Latest { get; private set; }
        public Sample Oldest { get; private set; }

        public int Count { get; private set; }

        public double Period => this.Count > 1 ? (this.Latest.T - this.Oldest.T-this.Oldest.dT) : 0;

        public SampleList()
        {
            
        }

        public void Clear()
        {
            this.Latest = this.Oldest = null;
            this.Count = 0;
        }      

        public void Add(Sample newSample)
        {
            if (this.Latest != null && this.Latest.T > newSample.T)
                throw new ArgumentException("Sample timestamps must increase.", nameof(newSample));

            newSample.Previous = this.Latest;
            this.Latest = newSample;

            if (this.Oldest == null)
                this.Oldest = this.Latest;

            this.Count++;
        }

        public void Trim(double limit, RemoveSampleDelegate onRemove)
        {
            bool changed = false;

            // While trimming, don't chop the tail off the list as we go, because this changes the dT value in the next sample.
            
            while (this.Oldest?.T <= limit)
            {
                Sample current = this.Oldest;

                bool remove = true;
                if (onRemove != null)
                {
                    onRemove(current, limit, out remove);
                }
                if (remove)
                {
                    this.Oldest = current.Next;
                    this.Count--;
                    changed = true;
                }
                if (current.T == limit)
                    break;
            }

            if (!changed)
                return;

            if (this.Oldest == null)
                this.Latest = null;
            else
            {
                // chop off the tail
                this.Oldest.Previous = null;
            }
        }

        public IEnumerator<Sample> GetEnumerator()
        {
            for (Sample current = this.Oldest; current != null; current = current.Next)
                yield return current;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }

}
