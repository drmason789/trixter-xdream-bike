using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.Diagnostics
{
    internal class XDreamDeviceGroupPolicyUsbDeviceRestrictionReader
    {
        static readonly string[] DeviceIDs = new[] { @"USB\VID_067B&PID_2303&REV_0300", @"USB\VID_067B&PID_2303" };
                
        private GroupPolicyUsbDeviceRestrictionReader restrictionReader;

        public XDreamDeviceGroupPolicyUsbDeviceRestrictionReader()
        {
            this.restrictionReader = new GroupPolicyUsbDeviceRestrictionReader();
            this.restrictionReader.Load();

            this.XDreamDevicesListed = this.restrictionReader.BlockedDeviceIDs.Intersect(DeviceIDs).ToArray();
        }

        public bool DenyDeviceIDs => this.restrictionReader.DenyDeviceIDs;
        public bool DenyDeviceIDsRetroactive => this.restrictionReader.DenyDeviceIDsRetroactive;

        public IReadOnlyList<string> XDreamDevicesListed { get; }

        public bool XDreamDeviceListed => XDreamDevicesListed.Count > 0;

        public bool XDreamDeviceDenied => XDreamDeviceListed && this.restrictionReader.DenyDeviceIDs;

    }
}
