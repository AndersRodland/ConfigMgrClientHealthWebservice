using System;
using System.Collections.Generic;

namespace ConfigMgrClientHealthWebservice.Models
{
    public partial class Clients
    {
        public string Hostname { get; set; }
        public string OperatingSystem { get; set; }
        public string Architecture { get; set; }
        public string Build { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public DateTime? InstallDate { get; set; }
        public DateTime? Osupdates { get; set; }
        public string LastLoggedOnUser { get; set; }
        public string ClientVersion { get; set; }
        public double? Psversion { get; set; }
        public int? Psbuild { get; set; }
        public string Sitecode { get; set; }
        public string Domain { get; set; }
        public int? MaxLogSize { get; set; }
        public int? MaxLogHistory { get; set; }
        public int? CacheSize { get; set; }
        public string ClientCertificate { get; set; }
        public string ProvisioningMode { get; set; }
        public string Dns { get; set; }
        public string Drivers { get; set; }
        public string Updates { get; set; }
        public string PendingReboot { get; set; }
        public DateTime? LastBootTime { get; set; }
        public double? OsdiskFreeSpace { get; set; }
        public string Services { get; set; }
        public string AdminShare { get; set; }
        public string StateMessages { get; set; }
        public string Wuahandler { get; set; }
        public string Wmi { get; set; }
        public DateTime? ClientInstalled { get; set; }
        public string Version { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? Hwinventory { get; set; }
        public string Swmetering { get; set; }
        public string Bits { get; set; }
        public int? PatchLevel { get; set; }
        public string ClientInstalledReason { get; set; }
        public DateTime? RefreshComplianceState { get; set; }
    }
}
