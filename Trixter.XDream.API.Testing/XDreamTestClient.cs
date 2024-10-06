using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API
{
    public class XDreamTestClient : XDreamClient
    {
        public int Resistance { get; set; }

        public event XDreamStateUpdatedDelegate<XDreamClient> StateUpdated;

        public void UpdateState(XDreamState state)
        {
            this.StateUpdated?.Invoke(this, state);
        }

        public void UpdateState(IEnumerable<XDreamState> states)
        {
            var array = states.ToArray();

            bool sorted = true;

            for(int i=1; sorted && i<array.Length; i++)
                sorted &= array[i].TimeStamp>array[i-1].TimeStamp;

            Assert.That(sorted, "States are not in order of increasing timestamp.");

            Array.ForEach(array, UpdateState);
        }

    }
}
