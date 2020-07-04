using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConfigMgrClientHealthWebservice.Models
{
    public partial class ClientHealthContext : DbContext
    {
        public virtual DbSet<Clients> Clients { get; set; }

        // Unable to generate entity type for table 'dbo.Configuration'. Please see the warning messages.
               
        public ClientHealthContext(DbContextOptions<ClientHealthContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.Hostname);

                entity.Property(e => e.Hostname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminShare)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Architecture)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Bits)
                    .HasColumnName("BITS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Build)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCertificate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientInstalled).HasColumnType("smalldatetime");

                entity.Property(e => e.ClientInstalledReason)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ClientVersion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dns)
                    .HasColumnName("DNS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Drivers)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hwinventory)
                    .HasColumnName("HWInventory")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.InstallDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastBootTime).HasColumnType("smalldatetime");

                entity.Property(e => e.LastLoggedOnUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OperatingSystem)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OsdiskFreeSpace).HasColumnName("OSDiskFreeSpace");

                entity.Property(e => e.Osupdates)
                    .HasColumnName("OSUpdates")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PendingReboot)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvisioningMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Psbuild).HasColumnName("PSBuild");

                entity.Property(e => e.Psversion).HasColumnName("PSVersion");

                entity.Property(e => e.Services)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sitecode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StateMessages)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Swmetering)
                    .HasColumnName("SWMetering")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.Updates)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Wmi)
                    .HasColumnName("WMI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wuahandler)
                    .HasColumnName("WUAHandler")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshComplianceState).HasColumnType("datetime");

                entity.Property(e => e.CMClientGUID)
                    .HasMaxLength(41)
                    .IsUnicode(false);
            });
        }
    }
}
