using CarMax.Application.Interfaces;
using CarMax.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarMax.DI
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            return services.AddSingleton<ICarRepository, CarRepository>();
        }

    }
}
