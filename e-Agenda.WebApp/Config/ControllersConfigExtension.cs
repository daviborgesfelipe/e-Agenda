using e_Agenda.WebApp.Filters;

namespace e_Agenda.WebApp.Config
{
    public static class ControllersConfigExtension
    {
        public static void ConfigurarControllers(this IServiceCollection services)
        {
            services.AddControllers(config => { config.Filters.Add<SerilogActionFilter>(); })
                .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));
        }
    }
}
