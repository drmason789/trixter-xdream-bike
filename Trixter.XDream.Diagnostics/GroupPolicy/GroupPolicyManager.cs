using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.Diagnostics
{

    /// <summary>
    /// Manages USB device restrictions in group policy.
    /// </summary>
    internal class GroupPolicyUsbDeviceRestrictionReader
    {
        private static class Constants
        {
            public const string RestrictionsKey = @"SOFTWARE\Policies\Microsoft\Windows\DeviceInstall\Restrictions";
            
            public const string DenyDeviceIDs = "DenyDeviceIDs";
            public const string DenyDeviceIDsRetroactive = "DenyDeviceIDsRetroactive";

        }        

        /// <summary>
        /// Indicates if USB device blocking is enabled on the system.
        /// I.e. existing installations are pormitted, but updates and new installations are not.
        /// </summary>
        public bool DenyDeviceIDs { get; private set; }

        /// <summary>
        /// Indicates if USB device blocking is retroactively enabled on the system.
        /// I.e. the device is not permitted at all.
        /// </summary>
        public bool DenyDeviceIDsRetroactive { get; private set; }

        /// <summary>
        /// The blockages as defined in the registry, keyed by number.
        /// </summary>
        public IReadOnlyDictionary<string, string> Blockages { get; private set; }

        /// <summary>
        /// A list of distinct USB device IDs that are registered for blocking.
        /// </summary>
        public IReadOnlyList<string> BlockedDeviceIDs { get; private set; }

        private static bool TryGetDwordValue(RegistryKey key, string name)
        {
            try
            {
                object value = key.GetValue(name, 0);
                if (value is int i)
                    return i != 0;
            }
            catch
            {
            }
            return false;
        }

        public void Load()
        {
            RegistryKey restrictionsKey = Registry.LocalMachine.OpenSubKey(Constants.RestrictionsKey);

            if (restrictionsKey == null)
            {
                this.Blockages = new Dictionary<string, string>();
                this.BlockedDeviceIDs = Array.Empty<String>();
                return;
            }

            this.DenyDeviceIDs = TryGetDwordValue(restrictionsKey, Constants.DenyDeviceIDs);
            this.DenyDeviceIDsRetroactive = TryGetDwordValue(restrictionsKey, Constants.DenyDeviceIDsRetroactive);

            RegistryKey denyDeviceIDsKey = restrictionsKey.OpenSubKey(Constants.DenyDeviceIDs);

            if (denyDeviceIDsKey == null)
                return;

            this.Blockages = denyDeviceIDsKey.GetValueNames()
                .Select(n=>new { Name = n, Value = denyDeviceIDsKey.GetValue(n) })
                .Where(nv=>nv.Value is string)
                .ToDictionary(nv=>nv.Name, nv=>nv.Value as string);

            this.BlockedDeviceIDs = this.Blockages.Values.Distinct().ToArray();
        }
    }
}
