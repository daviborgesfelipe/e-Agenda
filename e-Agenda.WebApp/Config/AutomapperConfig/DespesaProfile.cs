using AutoMapper;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.WebApp.ViewModels.ModuloDespesa.Despesa;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<FormsDespesaViewModel, Despesa>();

            CreateMap<Despesa, ListarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()));

            CreateMap<Despesa, VisualizarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()))
                .ForMember(destino => destino.Categorias, opt => opt.MapFrom(origem => origem.Categorias.Select(x => x.Titulo)));
        }
    }
}