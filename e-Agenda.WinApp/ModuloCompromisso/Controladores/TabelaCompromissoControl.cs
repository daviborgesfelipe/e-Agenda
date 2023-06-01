using e_Agenda.WinApp.ModuloTarefa;
using e_Agenda.WinApp.Compartilhado.Extensions;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public partial class TabelaCompromissoControl : UserControl
    {
        public TabelaCompromissoControl()
        {
            InitializeComponent();
            ConfigurarColunas();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
        }
        public void AtualizarRegistros(List<Compromisso> compromissos)
        {
            grid.Rows.Clear();
            foreach (Compromisso compromisso in compromissos)
            {
                grid.Rows.Add(
                    compromisso.id,
                    compromisso.assunto,
                    compromisso.contato.nome,
                    compromisso.dataInicio.ToShortTimeString(),
                    compromisso.dataTermino.ToShortTimeString(),
                    compromisso.dataCompromisso.ToShortDateString()
                    );
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
                    Name = "assunto",
                    HeaderText = "Título"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "contato.nome",
                    HeaderText = "Contato"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "dataInicio",
                    HeaderText = "Inicio"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "dataTermino",
                    HeaderText = "Termino"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "dataCompromisso",
                    HeaderText = "Data"
                }
            };

            grid.Columns.AddRange(colunas);
        }
    }
}
