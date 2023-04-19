using CarMax.Application.Interfaces;
using CarMax.Application.Interfaces.appSettings;
using CarMax.Persistence.appSettings;
using CarMax.Persistence.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarMax.DI
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(serviceProvider =>
            {
                CosmosDbSettings settings = new(configuration);

                CosmosClient cosmosClient = new(settings.ConnectionString);

                Database database = cosmosClient.CreateDatabaseIfNotExistsAsync(settings.DatabaseName)
                                                .GetAwaiter().GetResult();

                database.CreateContainerIfNotExistsAsync(
                        settings.CarContainerName,
                        settings.CarContainerPartitionKeyPath,
                        400).GetAwaiter().GetResult();

                return cosmosClient;
            })
            .AddSingleton<ICosmosDbSettings, CosmosDbSettings>()
            .AddSingleton<ICosmosDbServiceClient, CosmosDbServiceClient>();
        }

    }
}
