using CarMax.Application.Interfaces.appSettings;
using Microsoft.Azure.Cosmos;

namespace CarMax.Application.Interfaces
{
    public interface ICosmosDbServiceClient
    {
        public CosmosClient CosmosClient { get; }
        public ICosmosDbSettings Settings { get; }
    }
}
