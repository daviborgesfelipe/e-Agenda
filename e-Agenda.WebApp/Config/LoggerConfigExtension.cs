using Serilog;

namespace e_Agenda.WebApp.Config
{
    public static class LoggerConfigExtension
    {
        public static void ConfigurarLogger()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();
        }
    }
}
