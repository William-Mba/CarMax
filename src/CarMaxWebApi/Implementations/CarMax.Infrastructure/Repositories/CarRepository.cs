using CarMax.Application.Interfaces;
using CarMax.Application.ServiceBuilders;
using CarMax.Domain.Cars;

namespace CarMax.Infrastructure.Repositories
{
    public class CarRepository : CosmosDbServiceClientBuilder<Car>, ICarRepository
    {
        public CarRepository(ICosmosDbServiceClient cosmosDbServiceClient) : base(cosmosDbServiceClient)
        {
        }

        protected override string ContainerName => _comosDbServiceClient.Settings.CarContainerName;
    }
}
