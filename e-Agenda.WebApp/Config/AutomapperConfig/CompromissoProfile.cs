using AutoMapper;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class CompromissoProfile : Profile
    {
        public CompromissoProfile()
        {
            CreateMap<Compromisso, ListarCompromissoViewModel>()
                .ForMember(destino => destino.Data, opt => opt.MapFrom(origem => origem.Data.ToShortDateString()))
                .ForMember(destino => destino.HoraInicio, opt => opt.MapFrom(origem => origem.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(destino => destino.HoraTermino, opt => opt.MapFrom(origem => origem.HoraTermino.ToString(@"hh\:mm")));

            CreateMap<FormsCompromissoViewModel, Compromisso>();
            CreateMap<Compromisso, VisualizarCompromissoViewModel>();
        }
    }
}
