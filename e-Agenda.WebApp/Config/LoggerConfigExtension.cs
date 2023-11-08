using Serilog;

namespace e_Agenda.WebApp.Config
{
    public static class LoggerConfigExtension
    {
        public static void ConfigurarLogger(this IServiceCollection services, ILoggingBuilder logging)
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