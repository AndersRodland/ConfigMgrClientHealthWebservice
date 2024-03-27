using ClientHealthWebServiceV2.Models;
using ClientHealthWebServiceV2.Models.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ClientHealthWebServiceV2.BL.ClientActions
{
    public interface IClientActions
    {
        public Client? GetClient(string name);
        public List<Client> GetClients(string? name = null);
        public ActionResult<Client> SetClient(Client client);
        public ClientConfigDto GetClientConfiguration();
        public ClientConfigDto SetClientConfiguration(ClientConfigDto config);

    }
}