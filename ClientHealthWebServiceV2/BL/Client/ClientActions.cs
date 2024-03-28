using ClientHealthWebServiceV2.Models;
using ClientHealthWebServiceV2.Models.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace ClientHealthWebServiceV2.BL.ClientActions
{
    public class ClientActions : IClientActions
    {
        private readonly ClientDBContext _context;
        private readonly ILogger<ClientActions> _logger;
        public ClientActions(ClientDBContext context, ILogger<ClientActions> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Client? GetClient(string name)
        {
            var clients = GetClients(name);
            if (clients.Count == 0)
            {
                return null;
            }
            if (clients.Count > 1)
            {
                throw new Exception($"More than one Record found for device [{name}]");
            }
            return clients[0];
        }
        public List<Client> GetClients(string? name = null)
        {
            _logger.LogInformation("Finding data for client.");
            var clients = _context.Clients;
            if (name != null)
            {
                var found = clients.Find(name);
                if (found != null)
                {
                    return new List<Client> { found };
                }
                return new List<Client>();
            }
            else
            {
                var clientList = clients.ToList();
                return clientList;
            }
        }

        public ActionResult<Client> SetClient(Client client)
        {
            Client? thisClient = null;
            if (client.ClientHealthId == (new Guid().ToString()))
            {
                client.ClientHealthId = Guid.NewGuid().ToString();
                _logger.LogDebug("Client Id not passed, adding new client with id: {exMessage}", client.ClientHealthId);
            }
            else
            {
                _logger.LogDebug("Searching for client with id: {exMessage}", client.ClientHealthId);
                thisClient = _context.Clients.Find(client.ClientHealthId);
                if (thisClient == null)
                {
                    _logger.LogWarning("Client Sent a client Id but not found in the database.  This may be a problem if you see it a lot.  Will create a new record for... ClientId: {ClientHealthId}  Hostname: {Hostname}", client.ClientHealthId, client.Hostname);
                }
            }
            if (thisClient == null)
            {
                try
                {
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                    return client;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to add to database. Message: {exMessage}", ex.Message);
                    throw new Exception($"Failed to add to database. Message: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    _context.Entry(thisClient).CurrentValues.SetValues(client);
                    _context.SaveChanges();
                    return client;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to update database. Message: {exMessage}", ex.Message);
                    throw new Exception($"Failed to update database. Message: {ex.Message}");
                }
            }

        }
        public ClientConfigDto GetClientConfiguration()
        {
            var clientConfig = _context.ClientConfiguration.AsQueryable();
            var config = clientConfig.FirstOrDefault(c => c.Id == "default");
            if (config != null)
            {
                try
                {
                    var deSerialConfig = JsonConvert.DeserializeObject<ClientConfigDto>(config.Configuration);
                    if (deSerialConfig == null)
                    {
                        _logger.LogError("Failed to convert configuration data. Deserialized config is null.");
                        throw new Exception("Failed to convert configuration data.");
                    }
                    return deSerialConfig;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to convert configuration data. Message: {exMessage}", ex.Message);
                    throw new Exception("Failed to convert configuration data.");
                }
            }
            _logger.LogError("Default configuration not found.");
            throw new Exception("Default configuration not found.");
        }
        public ClientConfigDto SetClientConfiguration(ClientConfigDto config)
        {
            //var thisConfig = _context.ClientConfiguration.Find(config.Id);
            var configId = "default";
            var serialConfig = JsonConvert.SerializeObject(config, Formatting.None);
            var clientConfig = new ClientConfiguration() {
                Id = configId,
                Configuration = serialConfig
            };
            var thisConfig = _context.ClientConfiguration.Find(configId);
            if (thisConfig == null)
            {
                try
                {
                    _context.ClientConfiguration.Add(clientConfig);
                    _context.SaveChanges();
                    return config;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to add configuration into database. Message: {exMessage}", ex.Message);
                    throw new Exception($"Failed to add configuration into database. Message: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    _context.Entry(thisConfig).CurrentValues.SetValues(clientConfig);
                    _context.SaveChanges();
                    return config;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to update configuration in database. Message: {exMessage}", ex.Message);
                    throw new Exception($"Failed to update configuration in database. Message: {ex.Message}");
                }
            }
        }
    }
}
