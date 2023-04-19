using CarMax.Application.Interfaces;
using CarMax.Application.Interfaces.appSettings;
using Microsoft.Azure.Cosmos;

namespace CarMax.Persistence.Data
{
    public class CosmosDbServiceClient : ICosmosDbServiceClient
    {
        private readonly CosmosClient _cosmosClient;
        private readonly ICosmosDbSettings _cosmosDbSettings;

        public CosmosDbServiceClient(CosmosClient cosmosClient, ICosmosDbSettings cosmosDbSettings)
        {
            _cosmosClient = cosmosClient;
            _cosmosDbSettings = cosmosDbSettings;
        }
        public CosmosClient CosmosClient => _cosmosClient;

        public ICosmosDbSettings Settings => _cosmosDbSettings;
    }
}
