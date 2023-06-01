using e_Agenda.WinApp.Compartilhado.Extensions;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp.ModuloTarefa
{
    public partial class TabelaTarefaControl : UserControl
    {
        public TabelaTarefaControl()
        {
            InitializeComponent();
            ConfigurarColunas();
            gridTarefas.ConfigurarGridZebrado();
            gridTarefas.ConfigurarGridSomenteLeitura();
        }
        public void AtualizarRegistros(List<Tarefa> tarefas)
        {
            gridTarefas.Rows.Clear();
            foreach (Tarefa tarefa in tarefas)
            {
                gridTarefas.Rows.Add(tarefa.id, tarefa.titulo, tarefa.prioridade, tarefa.percentualConcluido);
            }
        }
        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(gridTarefas.SelectedRows[0].Cells["id"].Value);
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
                    Name = "titulo",
                    HeaderText = "Título"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "prioridade",
                    HeaderText = "Prioridade"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "percentualConcluido",
                    HeaderText = "% Concluído"
                }
            };

            gridTarefas.Columns.AddRange(colunas);
        }
    }
}
