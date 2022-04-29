using System;
using System.Collections;
using System.Collections.Generic;

namespace Trixter.XDream.API.Filters
{
    internal class SampleList : IEnumerable<Sample>
    {        
        public Sample Latest { get; private set; }
        public Sample Oldest { get; private set; }

        public int Count { get; private set; }

        public double Period => this.Count > 1 ? (this.Latest.T - this.Oldest.T) : 0;

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

        public void Trim(double limit, Action<Sample, double> onRemove)
        {
            bool changed = false;
            
            while (this.Oldest != null && this.Oldest.T < limit)
            {
                bool remove = true;
                if (onRemove != null)
                {
                    onRemove(this.Oldest, limit);
                    remove = this.Oldest.T < limit;
                }
                if (remove)
                {
                    this.Oldest = this.Oldest.Next;
                    this.Count--;
                    changed = true;
                }
            }

            if (!changed)
                return;

            if (this.Oldest == null)
                this.Latest = null;
            else
            {
                this.Oldest.Previous = null;
                if (this.Oldest.Next == null)
                    this.Latest = this.Oldest;
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
