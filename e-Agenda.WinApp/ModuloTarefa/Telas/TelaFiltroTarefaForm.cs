using e_Agenda.WinApp.Compartilhado.Enums;
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
    public partial class TelaFiltroTarefaForm : Form
    {
        public TelaFiltroTarefaForm()
        {
            InitializeComponent();
        }
        public StatusFiltroTarefaEnum ObterFiltroTarefa()
        {
            if (rdbConcluidas.Checked == true)
            {
                return StatusFiltroTarefaEnum.Concluidas;
            }
            else if (rdbPendentes.Checked == true)
            {
                return StatusFiltroTarefaEnum.Pendentes;
            }
            else 
            { 
                return StatusFiltroTarefaEnum.Todos;
            }                    
        }
    }
}
