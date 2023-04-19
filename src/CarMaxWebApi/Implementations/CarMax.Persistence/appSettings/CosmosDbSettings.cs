using CarMax.Application.Interfaces.appSettings;
using Microsoft.Extensions.Configuration;

namespace CarMax.Persistence.appSettings
{
    public class CosmosDbSettings : ICosmosDbSettings
    {
        private readonly IConfiguration _configuration;

        public CosmosDbSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString => _configuration.GetSection("CosmosDb:ConnectionString").Value!;
        public string DatabaseName => _configuration.GetSection("CosmosDb:DatabaseName").Value!;
        public string CarContainerName => _configuration.GetSection("CosmosDb:CarContainerName").Value!;
        public string CarContainerPartitionKeyPath => _configuration.GetSection("CosmosDb:CarContainerPartitionKeyPath").Value!;
    }
}
