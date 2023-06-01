using e_Agenda.WinApp.Compartilhado.Enums;
using e_Agenda.WinApp.Compartilhado.Extensions;
using e_Agenda.WinApp.ModuloTarefa.Entidades;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public partial class TelaTarefaForm : Form
    {
        public TelaTarefaForm(bool edicaoDeTarefa)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            PopularComboBoxPrioridades();
            if (edicaoDeTarefa)
            {
                txtDataCriacao.Enabled = false;
            }
        }
        private void PopularComboBoxPrioridades()
        {
            TipoPrioridadeTarefaEnum[] prioridades = Enum.GetValues<TipoPrioridadeTarefaEnum>();
            foreach (TipoPrioridadeTarefaEnum prioridade in prioridades)
            {
                cmbPrioridade.Items.Add(prioridade);
            }
        }
        public void ConfigurarTelaDeEdicao(Tarefa tarefaSelecionada)
        {
            txtId.Text = tarefaSelecionada.id.ToString();
            txtTitulo.Text = tarefaSelecionada.titulo;
            cmbPrioridade.SelectedItem = tarefaSelecionada.prioridade;
            txtDataCriacao.Value = tarefaSelecionada.dataCriacao;
        }

        public Tarefa ObterTarefa()
        {
            int id = Convert.ToInt32(txtId.Text);
            string titulo = txtTitulo.Text;
            TipoPrioridadeTarefaEnum prioridade = (TipoPrioridadeTarefaEnum)cmbPrioridade.SelectedItem;
            DateTime dataCriacao = txtDataCriacao.Value;
            return new Tarefa(id, titulo, prioridade, dataCriacao);
        }
    }
}
