using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class Experiments
    {
        [Explicit]
        [Test]
        public void BackAndForwardWithRealData()
        {
            var messages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);

            HybridCrankMeter cs = new HybridCrankMeter();
            XDreamState last = messages[0];
            DateTimeOffset t0 = messages[0].TimeStamp;

            cs.AddData(last);

            for (int i = 1; i < messages.Length; i++)
            {
                if (messages[i].TimeStamp.Subtract(last.TimeStamp).TotalMilliseconds >= 1d)
                {
                    cs.AddData(messages[i]);
                    last = messages[i];

                    System.Console.WriteLine($"{(last.TimeStamp - t0).TotalMilliseconds:0.0} : {cs.DebuggerDisplay}");
                }


            }
        }

        [Explicit]
        [Test(Description = "Initial (not final) attempt to see relationship between crank speed measurement and calculation from position. ")]
        public void CorrelateCrankSpeed()
        {
            var messages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);

            HashSet<int>[] rpms = Enumerable.Range(0, 1000).Select(i => new HashSet<int>()).ToArray(); // If we get a calculated 1000RPM, something is unnatural

            ICrankMeter cs = new PositionalCrankMeter();
            XDreamState last = messages[0];

            cs.AddData(last);

            for (int i = 1; i < messages.Length; i++)
            {
                if (messages[i].TimeStamp.Subtract(last.TimeStamp).TotalMilliseconds >= 1d)
                {
                    cs.AddData(messages[i]);
                    last = messages[i];
                }

                if (cs.RPM >= rpms.Length || cs.RPM < 0)
                    throw new Exception($"Unexpected RPM calculation: {cs.RPM} at sample {i}");

                rpms[cs.RPM].Add(last.Crank);
            }

            System.Console.WriteLine("RPM: samples");
            for (int i = 0; i < rpms.Length; i++)
                if (rpms[i].Count > 0)
                    System.Console.WriteLine($"{i}: {string.Join(",", rpms[i].OrderBy(x => x).Select(x => x.ToString()))}");
        }
    }
}
