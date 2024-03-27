using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientHealthWebServiceV2.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [MaxLength(36)]
        public string ClientHealthId { get; set; } = (new Guid()).ToString();
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
        public string? Extension_000 { get; set; }
        public string? Extension_001 { get; set; }
        public string? Extension_002 { get; set; }
        public string? Extension_003 { get; set; }
        public string? Extension_004 { get; set; }
        public string? Extension_005 { get; set; }
        public string? Extension_006 { get; set; }
        public string? Extension_007 { get; set; }
        public string? Extension_008 { get; set; }
        public string? Extension_009 { get; set; }
        public string? Extension_010 { get; set; }
        public string? Extension_011 { get; set; }
        public string? Extension_012 { get; set; }
        public string? Extension_013 { get; set; }
        public string? Extension_014 { get; set; }
        public string? Extension_015 { get; set; }
        public string? Extension_016 { get; set; }
        public string? Extension_017 { get; set; }
        public string? Extension_018 { get; set; }
        public string? Extension_019 { get; set; }
    }
}
