using CarMax.Application.Interfaces.appSettings;
using Microsoft.Extensions.DependencyInjection;

namespace CarMax.DI
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ICosmosDbSettings).Assembly));
        }

    }
}
