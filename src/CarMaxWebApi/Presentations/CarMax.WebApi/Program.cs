using Serilog;
using Serilog.Core;

namespace CarMax.WebApi
{
    public class Program
    {
        protected Program()
        {
        }
        public static int Main(string[] args)
        {
            Log.Logger = ConfigureLogging();

            try
            {
                Log.Information("Starting web host");

                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");

                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
        private static Logger ConfigureLogging()
        {
            return new LoggerConfiguration()
                               .MinimumLevel.Debug()
                               .Enrich.FromLogContext()
                               .WriteTo.Console()
                               .WriteTo.Trace()
                               .CreateLogger();
        }

    }
}
