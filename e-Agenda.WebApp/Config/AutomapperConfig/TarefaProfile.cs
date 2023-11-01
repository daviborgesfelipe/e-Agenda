using AutoMapper;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.WebApp.ViewModels.ModuloTarefa;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, ListarTarefaViewModel>();
            CreateMap<Tarefa, VisualizarTarefaViewModel>();
            CreateMap<FormsTarefaViewModel, Tarefa>();
        }
    }
}
