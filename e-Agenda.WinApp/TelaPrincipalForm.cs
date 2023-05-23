using e_Agenda.WinApp.Compartilhado;
using e_Agenda.WinApp.ModuloCompromiso;
using e_Agenda.WinApp.ModuloCompromisso;
using e_Agenda.WinApp.ModuloContato;
using e_Agenda.WinApp.ModuloTarefa;
using System.Globalization;

namespace e_Agenda.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private RepositorioContato repositorioContato = new RepositorioContato(new List<Contato>());
        private RepositorioCompromisso repositorioCompromisso = new RepositorioCompromisso(new List<Compromisso>());

        public TelaPrincipalForm()
        {
            InitializeComponent();

            IniciaAlgumasInstanciasNoRepositorio();
        }

        private void IniciaAlgumasInstanciasNoRepositorio()
        {
            Contato contato1 = new Contato("Davi", "3241-3078", "davi@gmail.com", "Desenvolvedor", "NDD");
            Contato contato2 = new Contato("Thiagao", "3345-7833", "thiagao@gmail.com", "Professor Desenvolvedor", "Academia do Programador");
            Contato contato3 = new Contato("Caio", "3111-9844", "caio@gmail.com", "Desenvolvedor", "NDD");
            contato1.id = 30;
            contato2.id = 31;
            contato3.id = 32;
            repositorioContato.Inserir(contato1);
            repositorioContato.Inserir(contato2);
            repositorioContato.Inserir(contato3);

            Compromisso compromisso1 = new Compromisso("Aula", "Online", Convert.ToDateTime("25/05/2023").Date, Convert.ToDateTime("11:00"), Convert.ToDateTime("12:00"));
            Compromisso compromisso2 = new Compromisso("Estudar", "Presencial", Convert.ToDateTime("18/05/2023").Date, Convert.ToDateTime("08:00", CultureInfo.InvariantCulture), Convert.ToDateTime("22:00", CultureInfo.InvariantCulture));
            Compromisso compromisso3 = new Compromisso("Trabalho", "Online", Convert.ToDateTime("13/06/2023").Date, Convert.ToDateTime("12:00", CultureInfo.InvariantCulture), Convert.ToDateTime("23:00", CultureInfo.InvariantCulture));
            compromisso1.id = 14;
            compromisso1.contato = contato2;
            compromisso2.id = 24;
            compromisso2.contato = contato1;
            compromisso3.id = 34;
            compromisso3.contato = contato3;
            repositorioCompromisso.Inserir(compromisso1);
            repositorioCompromisso.Inserir(compromisso2);
            repositorioCompromisso.Inserir(compromisso3);
        }

        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCompromisso(repositorioCompromisso, repositorioContato);

            ConfigurarTelaPrincipal(controlador);

            HabilitarBotoesInserirEditarExcluir(true);

        }

        private void contatosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorContato(repositorioContato);

            ConfigurarTelaPrincipal(controlador);

            HabilitarBotoesInserirEditarExcluir(false);
        }

        private void tarefasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTarefa();

            ConfigurarTelaPrincipal(controlador);

            HabilitarBotoesInserirEditarExcluir(true);

        }

        private void HabilitarBotoesInserirEditarExcluir(bool temFiltro)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnInserir.Enabled = true;
            if (temFiltro)
            {
                btnFiltrar.Enabled = true;
            }
            else
            {
                btnFiltrar.Enabled = false;
            }
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarToolTips(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }
    }
}