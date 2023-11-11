﻿namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public static class AutoMapperConfigExtension
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<ContatoProfile>();
                opt.AddProfile<CompromissoProfile>();
                opt.AddProfile<CategoriaProfile>();
                opt.AddProfile<DespesaProfile>();
                opt.AddProfile<TarefaProfile>();
            });
        }
    }
}
