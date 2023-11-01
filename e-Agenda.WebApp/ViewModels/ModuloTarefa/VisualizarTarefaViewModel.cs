using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.WebApp.ViewModels.ModuloTarefa
{
    public class VisualizarTarefaViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string DataCriacao { get; set; }
        public string DataConclusao { get; set; }

        public int QntdItens { get; set; }
        public double PercentualConcluido { get; set; }
        public string Prioridade { get; set; }
        public string Situacao { get; set;}

        public List<VisualizarItemTarefaViewModel> Itens { get; set; }
    }
}
