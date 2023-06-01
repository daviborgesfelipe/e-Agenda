using e_Agenda.WinApp.Compartilhado.Extensions;
using e_Agenda.WinApp.ModuloContato.Entidades;

namespace e_Agenda.WinApp.ModuloContato
{
    public partial class TabelaContatoControl : UserControl
    {
        public TabelaContatoControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            grid.ConfigurarGridZebrado();

            grid.ConfigurarGridSomenteLeitura();
        }
        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "nome",
                    HeaderText = "Nome"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "telefone",
                    HeaderText = "Telefone"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "cargo",
                    HeaderText = "Cargo"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "empresa",
                    HeaderText = "Empresa"
                }
            };

            grid.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<Contato> contatos)
        {
            grid.Rows.Clear();
            foreach (Contato contato in contatos)
            {
                grid.Rows.Add(contato.id, contato.nome, contato.telefone, contato.cargo, contato.empresa);
            }
        }

        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                id = -1;
            }

            return id;
        }
    }
}
