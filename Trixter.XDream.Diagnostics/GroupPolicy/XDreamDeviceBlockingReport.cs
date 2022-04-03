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
            public const string OtherDevicesRestricted = "Restrictions are active, but no X-Dream related devices are registered for restriction.";
            public const string DeviceRestricted = "At least 1 known X-Dream device is restricted from updates and new installations.";
            public const string DeviceRestrictedRetroactively = "At least 1 known X-Dream device is restricted";
        }

        public XDreamDeviceGroupPolicyUsbDeviceRestrictionReader Reader { get; }

        public XDreamDeviceBlockingReport(XDreamDeviceGroupPolicyUsbDeviceRestrictionReader reader)
        {
            this.Reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }
        
        public string GetSummary()
        {
            StringBuilder result = new StringBuilder();
         
            if (!this.Reader.DenyDeviceIDs && !this.Reader.XDreamDeviceListed)
                result.AppendLine(Constants.UnrestrictedInstallation);
            else if (!this.Reader.DenyDeviceIDs && this.Reader.XDreamDeviceListed)
                result.AppendLine(Constants.InactiveRestrictions);
            else if (this.Reader.DenyDeviceIDs && !this.Reader.XDreamDeviceListed)
                result.AppendLine(Constants.OtherDevicesRestricted);
            else if (this.Reader.XDreamDeviceDenied)
            {
                if (this.Reader.DenyDeviceIDsRetroactive)
                    result.AppendLine(Constants.DeviceRestrictedRetroactively);
                else 
                    result.AppendLine(Constants.DeviceRestricted);
            }

            return result.ToString();
        }
    }
}
