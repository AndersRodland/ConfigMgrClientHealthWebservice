using Microsoft.EntityFrameworkCore;

namespace ClientHealthWebServiceV2.Models
{
    public class ClientDBContext : DbContext
    {
        public ClientDBContext(DbContextOptions<ClientDBContext> options)
            : base(options) { }

        //public ClientDBContext(string DefaultConnection) : base(DefaultConnection) { }
        //public virtual DbSet<Client_Old> Clients_old { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientConfiguration> ClientConfiguration { get; set; } = null!;

    }
}
