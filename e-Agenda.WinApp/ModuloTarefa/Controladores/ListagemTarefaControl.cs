using e_Agenda.WinApp.Compartilhado.Enums;
using e_Agenda.WinApp.ModuloTarefa.Entidades;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public partial class ListagemTarefaControl : UserControl
    {
        List<Tarefa> tarefas = new List<Tarefa>();

        public ListagemTarefaControl()
        {
            InitializeComponent();

            tarefas.Add(new Tarefa(111, "Tirar fotos", TipoPrioridadeTarefaEnum.Baixa, Convert.ToDateTime("11/07/2023")));
            tarefas.Add(new Tarefa(22, "Atividades", TipoPrioridadeTarefaEnum.Media, Convert.ToDateTime("12/06/2023")));
            tarefas.Add(new Tarefa(33, "Projeto", TipoPrioridadeTarefaEnum.Alta, Convert.ToDateTime("01/06/2023")));
            tarefas.Add(new Tarefa(44, "Prova", TipoPrioridadeTarefaEnum.Alta, Convert.ToDateTime("18/06/2023")));

            foreach (Tarefa tarefa in tarefas)
            {
                listTarefas.Items.Add(tarefa);
            }
        }
        public void AtualizarRegistros(List<Tarefa> tarefas)
        {
            listTarefas.Items.Clear();

            listTarefas.Items.AddRange(tarefas.ToArray());
        }

        public Tarefa ObterTarefaSelecionada()
        {
            return (Tarefa)listTarefas.SelectedItem;
        }
    }
}

