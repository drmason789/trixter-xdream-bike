using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Trixter.XDream.API.Communications;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Experimental
{
    [TestFixture]
    public class CrankMeterExperiments
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
        public void CorrelateCrankSpeed1()
        {
            var messages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);

            HashSet<int>[] rpms = Enumerable.Range(0, 1000).Select(i => new HashSet<int>()).ToArray(); // If we get a calculated 1000RPM, something is unnatural

            ICrankMeter cs = new PositionalCrankMeter();
            XDreamState last = messages[0];

            cs.AddData(last);

            for (int i = 1; i < messages.Length; i++)
            {

                cs.AddData(messages[i]);
                last = messages[i];

                if (cs.RPM >= rpms.Length || cs.RPM < 0)
                    throw new Exception($"Unexpected RPM calculation: {cs.RPM} at sample {i}");

                rpms[cs.RPM].Add(last.Crank);
            }

            System.Console.WriteLine("RPM: samples");
            for (int i = 0; i < rpms.Length; i++)
                if (rpms[i].Count > 0)
                    System.Console.WriteLine($"{i}: {string.Join(",", rpms[i].OrderBy(x => x).Select(x => x.ToString()))}");
        }


        [Explicit]
        [Test(Description = "Use average values over 500ms and least squares interpolation to find a line for the RPM from raw input.")]
        public void CorrelateCrankSpeed2()
        {
            XDreamMessage[] messages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);

            StatisticsGatheringCrankMeter cm = new StatisticsGatheringCrankMeter(new PositionalCrankMeter(), 500);

            Array.ForEach(messages, cm.AddData);

            cm.GetLinearCoefficients(out var slope, out var intercept);

            System.Console.WriteLine($"Least squares interpolation of crank reading C and RPM: RPM = {slope} * (1/C) + {intercept}");
            System.Console.WriteLine();

            System.Console.WriteLine("RPM and RawValues for same sample");
            System.Console.WriteLine("================================");
            System.Console.WriteLine(cm.GetRpmToRawData());

            System.Console.WriteLine();
            System.Console.WriteLine("Raw values and RPM states calculated");
            System.Console.WriteLine("====================================");
            System.Console.WriteLine(cm.GetRawToRpmData());

        }



        
    }
}
