using e_Agenda.WinApp.Compartilhado.Extensions;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using System.Data;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public partial class TelaItensTarefaForm : Form
    {
        public TelaItensTarefaForm(Tarefa tarefa)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarTela(tarefa);
        }
        private void ConfigurarTela(Tarefa tarefa)
        {
            txtId.Text = tarefa.id.ToString();
            txtTitulo.Text = tarefa.titulo;
            listaItensTarefa.Items.AddRange(tarefa.items.ToArray());
        }

        public List<ItemTarefa> ObterItensCadastrados()
        {
            return listaItensTarefa.Items.Cast<ItemTarefa>().ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string titulo = txtDescricao.Text;
            ItemTarefa itemTarefa = new ItemTarefa(titulo);
            listaItensTarefa.Items.Add(itemTarefa);
        }
    }
}
