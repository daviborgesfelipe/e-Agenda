using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace e_Agenda.WebApp.Config
{
    public static class SerilogConfigExtension
    {
        public static void ConfigurarSerilog(this IServiceCollection services, ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            Log.Logger.Information("Iniciando aplicação...");

            logging.ClearProviders();

            services.AddSerilog(Log.Logger);
        }
    }
}