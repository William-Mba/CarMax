using CarMax.DI;
using CarMax.WebApi.Extensions;
using System.Text.Json.Serialization;

namespace CarMax.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterServices(Configuration);

            services.AddSwaggerExtension();

            services.AddControllers()
                    .AddJsonOptions(c =>
                    {
                        c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwaggerExtension();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
