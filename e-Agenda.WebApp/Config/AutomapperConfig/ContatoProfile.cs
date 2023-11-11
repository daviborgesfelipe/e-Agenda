using AutoMapper;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloContato;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
            CreateMap<Contato, ListarContatoViewModel>();

            CreateMap<Contato, VisualizarContatoViewModel>();

            CreateMap<FormsContatoViewModel, Contato>();

            CreateMap<InserirContatoViewModel, Contato>();

            CreateMap<EditarContatoViewModel, Contato>();
        }
    }
}
