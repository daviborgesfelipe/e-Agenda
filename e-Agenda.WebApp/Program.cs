using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Infra.Orm.Compartilhado;
using e_Agenda.Infra.Orm.ModuloCompromisso;
using e_Agenda.Infra.Orm.ModuloContato;
using e_Agenda.WebApp.Controllers.ModuloCompromisso;
using e_Agenda.WebApp.Controllers.ModuloContato;

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;

namespace e_Agenda.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            ConfigureServices(builder.Services);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            services.AddDbContext<IContextoPersistencia, eAgendaDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<ContatoController>();
            services.AddTransient<ServicoContato>();
            services.AddTransient<IValidadorContato, ValidadorContato>();
            services.AddTransient<IRepositorioContato, RepositorioContatoOrm>();

            services.AddTransient<CompromissoController>();
            services.AddTransient<ServicoCompromisso>();
            services.AddTransient<IValidadorCompromisso, ValidadorCompromisso>();
            services.AddTransient<IRepositorioCompromisso, RepositorioCompromissoOrm>();
        }
    }
}