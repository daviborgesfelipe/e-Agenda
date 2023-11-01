using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.WebApp.ViewModels.ModuloTarefa
{
    public class FormsTarefaViewModel
    {
        public string Titulo {  get; set; }
        public PrioridadeTarefaEnum Prioridade { get; set; }
        public List<FormsItensTarefaViewModel> Itens { get; set; }

        public FormsTarefaViewModel()
        {
            this.Itens = new List<FormsItensTarefaViewModel>();
        }
    }
}
