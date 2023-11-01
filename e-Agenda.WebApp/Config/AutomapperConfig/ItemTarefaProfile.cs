using AutoMapper;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.WebApp.ViewModels.ModuloTarefa;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class ItemTarefaProfile : Profile
    {
        public ItemTarefaProfile()
        {
            CreateMap<ItemTarefa, VisualizarItemTarefaViewModel>();
            CreateMap<FormsItensTarefaViewModel, ItemTarefa>();
        }
    }
}
