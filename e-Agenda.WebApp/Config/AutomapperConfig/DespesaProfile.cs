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
            CreateMap<InserirDespesaViewModel, Despesa>()
                .ForMember(destino => destino.Categorias, opt => opt.Ignore())
                .AfterMap<InserirCategoriasMappingAction>();

            CreateMap<EditarDespesaViewModel, Despesa>()
                .ForMember(destino => destino.Categorias, opt => opt.Ignore())
                .AfterMap(EditarCategoriasMappingAction);

            CreateMap<Despesa, ListarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()));

            CreateMap<Despesa, VisualizarDespesaViewModel>()
                .ForMember(destino => destino.FormaPagamento, opt => opt.MapFrom(origem => origem.FormaPagamento.GetDescription()))
                .ForMember(destino => destino.Categorias, opt => opt.MapFrom(origem => origem.Categorias.Select(x => x.Titulo)));

        }

        private void EditarCategoriasMappingAction(EditarDespesaViewModel viewModel, Despesa despesa)
        {
            viewModel.CategoriasSelecionadas = despesa.Categorias.Select(categoria => categoria.Id).ToList();
        }
    }

    public class InserirCategoriasMappingAction : IMappingAction<InserirDespesaViewModel, Despesa>
    {
        private readonly IRepositorioCategoria repositorioCategoria;

        public InserirCategoriasMappingAction(IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        public void Process(InserirDespesaViewModel source, Despesa destination, ResolutionContext context)
        {
            destination.Categorias = repositorioCategoria.SelecionarMuitos(source.CategoriasSelecionadas);
        }
    }
}