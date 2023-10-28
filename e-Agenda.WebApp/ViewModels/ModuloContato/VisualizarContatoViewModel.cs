using e_Agenda.WebApp.ViewModels.ModuloCompromisso;

namespace e_Agenda.WebApp.ViewModels.ModuloContato
{
    public class VisualizarContatoViewModel
    {
        public VisualizarContatoViewModel()
        {
            Compromissos = new List<ListarCompromissoViewModel>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public List<ListarCompromissoViewModel> Compromissos { get; set; }
    }
}
