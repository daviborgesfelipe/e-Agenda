using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.WebApp.ViewModels.ModuloTarefa
{
    public class FormsItensTarefaViewModel
    {
        public Guid? Id { get; set; }
        public string Titulo { get; set; }
        public StatusItemTarefa Status { get; set; }
        public bool Concluido { get; set; }
    }
}
