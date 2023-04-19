using CarMax.Application.Interfaces;
using CarMax.Domain;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarMax.Application.ServiceBuilders
{
    public abstract class CosmosDbServiceClientBuilder<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly Container _container;
        protected readonly ICosmosDbServiceClient _comosDbServiceClient;
        protected abstract string ContainerName { get; }

        protected CosmosDbServiceClientBuilder(ICosmosDbServiceClient cosmosDbServiceClient)
        {
            _comosDbServiceClient = cosmosDbServiceClient;
            var dbName = _comosDbServiceClient.Settings.DatabaseName;
            _container = _comosDbServiceClient.CosmosClient.GetContainer(dbName, ContainerName);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var response = await _container.CreateItemAsync<T>(entity, new PartitionKey(entity.id));

            return response.Resource;
        }

        public async Task DeleteAsync(T entity)
        {
            await _container.DeleteItemAsync<T>(entity.id, new PartitionKey(entity.id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            FeedIterator<T> feed = _container.GetItemQueryIterator<T>(new QueryDefinition("Select * from c"));

            List<T> entities = new List<T>();

            while (feed.HasMoreResults)
            {
                FeedResponse<T> reponse = await feed.ReadNextAsync();

                foreach (var entity in reponse)
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null!;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _container.UpsertItemAsync<T>(entity, new PartitionKey(entity.id));
        }
    }
}
