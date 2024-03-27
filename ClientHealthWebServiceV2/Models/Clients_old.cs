using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;

namespace ClientHealthWebServiceV2.Models
{
    [Table("Clients_old")]
    public class Client_Old
    {
        [Key]
        public string Hostname { get; set; } = string.Empty;
        public string OperatingSystem { get; set; } = string.Empty;
        [MaxLength(10)]
        public string Architecture { get; set; } = string.Empty;
        public string Build { get; set; } = string.Empty;
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public DateTime? InstallDate { get; set; }
        public DateTime? OSUpdates { get; set; }
        public string? LastLoggedOnUser { get; set; }
        public string? ClientVersion { get; set; }
        public double? PSVersion { get; set; }
        public int? PSBuild { get; set; }
        [MaxLength(3)]
        public string? Sitecode { get; set; }
        public string? Domain { get; set; }
        public int? MaxLogSize { get; set; }
        public int? MaxLogHistory { get; set; }
        public int? CacheSize { get; set; }
        public string? ClientCertificate { get; set; }
        public string? ProvisioningMode { get; set; }
        public string? DNS { get; set; }
        public string? Drivers { get; set; }
        public string? Updates { get; set; }
        public string? PendingReboot { get; set; }
        public DateTime? LastBootTime { get; set; }
        public double? OSDiskFreeSpace { get; set; }
        public string? Services { get; set; }
        public string? AdminShare { get; set; }
        public string? StateMessages { get; set; }
        public string? WUAHandler { get; set; }
        public string? WMI { get; set; }
        public DateTime? RefreshComplianceState { get; set; }
        public DateTime? ClientInstalled { get; set; }
        [MaxLength(10)]
        public string? Version { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? HWInventory { get; set; }
        public string? SWMetering { get; set; }
        public string? BITS { get; set; }
        public int? PatchLevel { get; set; }
        public string? ClientInstalledReason { get; set; }
    }
}
