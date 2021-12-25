namespace Trixter.XDream.API
{
    public static class XDreamBikeFactory
    {
        /// <summary>
        /// Creates an instance of the most basic configuration, notably using the <see cref="MappedCrankMeter"/>
        /// which does not support RPM measurement for backpedalling and is less accurate for slow RPM forwards.
        /// </summary>
        /// <param name="client">Optional <see cref="XDreamClient"/> object for interaction with the device. Defaults to an instance of <see cref="XDreamSerialPort"/>.</param>
        /// <returns></returns>
        public static XDreamMachine CreateBasic(XDreamClient client=null)
        {
            if(client==null)
                client = new XDreamSerialPort();
            return new XDreamBike(client, new MappedFlywheelMeter(), new MappedCrankMeter());
        }

        /// <summary>
        /// Creates an instance of the a configuration with the highest capability components.
        /// </summary>
        /// <param name="client">Optional <see cref="XDreamClient"/> object for interaction with the device. Defaults to an instance of <see cref="XDreamSerialPort"/>.</param>
        /// <returns></returns>
        public static XDreamMachine CreatePremium(XDreamClient client = null)
        {
            if (client == null)
                client = new XDreamSerialPort();
            return new XDreamBike(client, new MappedFlywheelMeter(), new HybridCrankMeter());
        }
    }
}