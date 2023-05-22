using e_Agenda.WinApp.ModuloCompromiso;
using e_Agenda.WinApp.ModuloContato;
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
        RepositorioContato repositorioContato;
        RepositorioCompromisso repositorioCompromisso;

        public TelaCompromissoForm(RepositorioCompromisso _repositorioCompromisso, RepositorioContato _repositorioContato)
        {
            this.repositorioContato = _repositorioContato;
            this.repositorioCompromisso = _repositorioCompromisso;
            InitializeComponent();
            PopularComboBox();
        }

        private void PopularComboBox()
        {
            comboBoxContatos.DataSource = repositorioContato.SelecionarTodos();
        }

        public Compromisso Compromisso
        {
            set
            {
                txtNumero.Text = value.id.ToString();
                txtAssunto.Text = value.assunto;
                txtBoxPresencial.Text = value.local;
                txtBoxRemoto.Text = value.local;
                comboBoxContatos.DataSource = repositorioContato.SelecionarTodos();
                txtDataCompromisso.Text = value.dataCompromisso.ToShortDateString();
                txtInicio.Text = value.dataInicio.ToShortTimeString();
                txtTermino.Text = value.dataTermino.ToShortTimeString();
            }
            get { return compromisso; }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string assunto = txtAssunto.Text;
            string local = txtBoxPresencial.Text;
            local = txtBoxRemoto.Text;
            DateTime dataCompromisso = txtDataCompromisso.Value;
            DateTime dataInicio = Convert.ToDateTime(txtInicio.Text);
            DateTime dataTermino = Convert.ToDateTime(txtTermino.Text);
            Contato contato = (Contato)comboBoxContatos.SelectedValue;

            compromisso = new Compromisso(assunto, local, dataCompromisso, dataInicio, dataTermino);

            //compromisso.contato = contato;
            if (comboBoxContatos.SelectedValue != null)
                compromisso.contato = contato;
            if (txtNumero.Text != "0")
                compromisso.id = Convert.ToInt32(txtNumero.Text);
        }
    }
}
