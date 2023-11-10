using e_Agenda.WebApp.ViewModels.ModuloDespesa.Despesa;

namespace e_Agenda.WebApp.ViewModels.ModuloDespesa.Categoria
{
    public class VisualizarCategoriaViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public List<ListarDespesaViewModel> Despesas { get; set; }

    }
}