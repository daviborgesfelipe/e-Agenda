using e_Agenda.WinApp.ModuloCompromiso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public partial class TelaCompromissoForm : Form
    {
        Compromisso compromisso;

        public TelaCompromissoForm()
        {
            InitializeComponent();
        }
        public Compromisso Compromisso 
        { 
            get { return compromisso; }
        }
    }
}
