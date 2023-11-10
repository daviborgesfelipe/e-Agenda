using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Aplicacao.ModuloDespesa;
using e_Agenda.Aplicacao.ModuloTarefa;

using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.Dominio.ModuloTarefa;

using e_Agenda.Infra.Orm.Compartilhado;
using e_Agenda.Infra.Orm.ModuloCompromisso;
using e_Agenda.Infra.Orm.ModuloContato;
using e_Agenda.Infra.Orm.ModuloDespesa;
using e_Agenda.Infra.Orm.ModuloTarefa;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.WebApp.Config
{
    public static class InjecaoDependenciaConfigExtension
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<IContextoPersistencia, eAgendaDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepositorioContato, RepositorioContatoOrm>();
            services.AddTransient<IValidadorContato, ValidadorContato>();
            services.AddTransient<ServicoContato>();

            services.AddTransient<IRepositorioCompromisso, RepositorioCompromissoOrm>();
            services.AddTransient<IValidadorCompromisso, ValidadorCompromisso>();
            services.AddTransient<ServicoCompromisso>();

            services.AddTransient<IRepositorioTarefa, RepositorioTarefaOrm>();
            services.AddTransient<IValidadorTarefa, ValidadorTarefa>();
            services.AddTransient<ServicoTarefa>();

            services.AddScoped<IRepositorioCategoria, RepositorioCategoriaOrm>();
            services.AddTransient<IValidadorCategoria, ValidadorCategoria>();
            services.AddTransient<ServicoCategoria>();

            services.AddScoped<IRepositorioDespesa, RepositorioDespesaOrm>();
            services.AddTransient<IValidadorDespesa, ValidadorDespesa>();
            services.AddTransient<ServicoDespesa>();
        }
    }
}
