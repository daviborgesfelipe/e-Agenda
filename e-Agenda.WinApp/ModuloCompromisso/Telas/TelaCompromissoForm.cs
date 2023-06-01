using e_Agenda.WinApp.ModuloCompromisso.Entidades;
using e_Agenda.WinApp.ModuloCompromisso.Enums;
using e_Agenda.WinApp.ModuloCompromisso.Interfaces;
using e_Agenda.WinApp.ModuloContato.Entidades;
using e_Agenda.WinApp.ModuloContato.Interfaces;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public partial class TelaCompromissoForm : Form
    {
        Compromisso compromisso;
        IRepositorioContato repositorioContato;
        IRepositorioCompromisso repositorioCompromisso;

        public TelaCompromissoForm(
            IRepositorioCompromisso _repositorioCompromisso,
            IRepositorioContato _repositorioContato
            )
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
                comboBoxContatos.DataSource = repositorioContato.SelecionarTodos();
                txtDataCompromisso.Text = value.dataCompromisso.ToShortDateString();
                txtInicio.Text = value.dataInicio.ToShortTimeString();
                txtTermino.Text = value.dataTermino.ToShortTimeString();
                if (radioBtnPresencial.Checked)
                {
                    txtBoxPresencial.Text = value.tipoLocal.ToString();
                }
                else
                {
                    txtBoxRemoto.Text = value.tipoLocal.ToString();
                }
            }
            get { return compromisso; }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string assunto = txtAssunto.Text;
            string local = TextoLocalSelecionado;
            DateTime dataCompromisso = txtDataCompromisso.Value;
            DateTime dataInicio = Convert.ToDateTime(txtInicio.Text);
            DateTime dataTermino = Convert.ToDateTime(txtTermino.Text);
            Contato contato = (Contato)comboBoxContatos.SelectedValue;
            TipoCompromissoEnum tipoLocal = LocalSelecionado;
            // se p tipoEnum.Remoto estiver selecionado o tipoLocal recebe remoto e txtBoxRemoto recebe o valor

            if (tipoLocal == TipoCompromissoEnum.Presencial)
            {
                local = txtBoxPresencial.Text;
            }
            else
            {
                local = txtBoxRemoto.Text;
            }

            compromisso = new Compromisso(assunto, local, dataCompromisso, dataInicio, dataTermino, tipoLocal);
            if (contato != null)
            {
                compromisso.contato = contato;
            }
            //compromisso.contato = contato;
            if (comboBoxContatos.SelectedValue != null)
                compromisso.contato = contato;
            if (txtNumero.Text != "0")
                compromisso.id = Convert.ToInt32(txtNumero.Text);
        }
        public string TextoLocalSelecionado
        {
            get
            {
                if (radioBtnPresencial.Checked)
                {
                    return txtBoxPresencial.Text;
                }
                else
                {
                    return txtBoxRemoto.Text;
                }
            }
        }
        public TipoCompromissoEnum LocalSelecionado
        {
            get
            {
                if (radioBtnPresencial.Checked)
                {
                    return TipoCompromissoEnum.Presencial;
                }
                else if(radioBtnRemoto.Checked)
                {
                    return TipoCompromissoEnum.Remoto;
                }
                else
                {
                    return TipoCompromissoEnum.Nenhum;
                }
            }
        }
    }
}
