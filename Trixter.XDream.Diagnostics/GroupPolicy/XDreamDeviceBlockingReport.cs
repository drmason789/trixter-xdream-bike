using System;
using System.Text;

namespace Trixter.XDream.Diagnostics
{
    internal class XDreamDeviceBlockingReport
    {
        private static class Constants
        {
           // public const string None = "No USB device restrictions are active on this system.";
           // public const string Active = "USB device restrictions are active on this system.";
           // public const string Retroactive = "USB device restrictions are retroactive on this system.";
           // public const string KnownDevices = "The following known X-Dream related devices are registered for restriction:";
           // public const string NoKnownDevices = "No known X-Dream related devices are registered for restriction.";
            public const string UnrestrictedInstallation = "Installation of known X-Dream related devices is not restricted.";
            public const string InactiveRestrictions = "Although known X-Dream related devices are registered for restrictions, restrictions are not active.";
            public const string OtherDevicesRestricted = "Restrictions are active, but no known X-Dream related devices are registered for restriction.";
            public const string DeviceRestricted = "At least 1 known X-Dream device is restricted from updates and new installations.";
            public const string DeviceRestrictedRetroactively = "At least 1 known X-Dream device is restricted";

            public const string Ideal = "This is potentially ideal if the current driver works and is subject to automatic update by Windows.";
            public const string Risky = "The current driver could be updated. This is not ideal if the current driver works and later ones do not.";
            public const string NotIdeal = "No installations or updates of the device are permitted.";
        }

        public XDreamDeviceGroupPolicyUsbDeviceRestrictionReader Reader { get; }

        public XDreamDeviceBlockingReport(XDreamDeviceGroupPolicyUsbDeviceRestrictionReader reader)
        {
            this.Reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }
        
        public string GetSummary()
        {
            if (!this.Reader.DenyDeviceIDs)
            {
                if(!this.Reader.XDreamDeviceListed)
                    return Constants.UnrestrictedInstallation;
                return Constants.InactiveRestrictions;
            }

            if (!this.Reader.XDreamDeviceListed)
                return Constants.OtherDevicesRestricted;
            else 
            {
                if (this.Reader.DenyDeviceIDsRetroactive)
                    return Constants.DeviceRestrictedRetroactively;
                else
                    return Constants.DeviceRestricted;
            }
#pragma warning disable CS0162 // Unreachable code detected
            return String.Empty;
#pragma warning restore CS0162 // Unreachable code detected
        }

        public string GetOpinion()
        {
            if (!this.Reader.DenyDeviceIDs)
                return Constants.Risky;
            if (this.Reader.DenyDeviceIDsRetroactive)
                return Constants.NotIdeal;
            if (this.Reader.XDreamDeviceListed)
                return Constants.Ideal;

            return String.Empty;
        }
    }
}
