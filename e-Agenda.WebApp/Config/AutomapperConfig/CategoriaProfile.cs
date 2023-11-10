using AutoMapper;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.WebApp.ViewModels.ModuloDespesa.Categoria;

namespace e_Agenda.WebApp.Config.AutomapperConfig
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<FormsCategoriaViewModel, Categoria>();

            CreateMap<Categoria, ListarCategoriaViewModel>();

            CreateMap<Categoria, VisualizarCategoriaViewModel>();

            CreateMap<Categoria, CategoriaSelecionadaViewModel>();
        }
    }
}
