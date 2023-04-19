using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarMax.DI
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddApplicationDependencies()
                           .AddInfrastructureDependencies()
                           .AddPersistenceDependencies(configuration);
        }
    }
}
