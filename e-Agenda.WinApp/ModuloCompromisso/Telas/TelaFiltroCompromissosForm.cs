namespace e_Agenda.WinApp.ModuloCompromisso
{
    public partial class TelaFiltroCompromissosForm : Form
    {
        public TelaFiltroCompromissosForm()
        {
            InitializeComponent();
        }

        public StatusCompromissoEnum StatusSelecionado
        {
            get
            {
                if (radioBtnCompromissosPassados.Checked)
                {
                    return StatusCompromissoEnum.Passados;
                }
                else if (radioBtnCompromissosFuturos.Checked)
                {
                    return StatusCompromissoEnum.Futuros;
                }
                else
                {
                    return StatusCompromissoEnum.Todos;
                }
            }
        }

        public DateTime DataInicial
        {
            get { return txtDataInicial.Value; }
        }
        public DateTime DataFinal
        {
            get { return txtDataFinal.Value; }
        }
    }
}
