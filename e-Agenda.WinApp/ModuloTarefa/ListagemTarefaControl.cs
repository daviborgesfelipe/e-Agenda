namespace e_Agenda.WinApp.ModuloTarefa
{
    public partial class ListagemTarefaControl : UserControl
    {
        List<Tarefa> tarefas = new List<Tarefa>();

        public ListagemTarefaControl()
        {
            InitializeComponent();

            tarefas.Add(new Tarefa(1, "Lavar o carro", "alta"));
            tarefas.Add(new Tarefa(2, "Lavar o cachorro", "alta"));

            foreach (Tarefa tarefa in tarefas)
            {
                listTarefas.Items.Add(tarefa);  
            }
        }
    }
}

