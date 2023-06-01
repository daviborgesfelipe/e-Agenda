using e_Agenda.WinApp.ModuloCompromisso.Controladores;
using e_Agenda.WinApp.ModuloCompromisso.Interfaces;
using e_Agenda.WinApp.ModuloCompromisso.Repositorios;

using e_Agenda.WinApp.ModuloContato.Controladores;
using e_Agenda.WinApp.ModuloContato.Interfaces;
using e_Agenda.WinApp.ModuloContato.Repositorios;

using e_Agenda.WinApp.ModuloTarefa.Controladores;
using e_Agenda.WinApp.ModuloTarefa.Interfaces;
using e_Agenda.WinApp.ModuloTarefa.Repositorios;

namespace e_Agenda.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private static TelaPrincipalForm telaPrincipal;

        private ControladorBase controlador;

        private IRepositorioContato repositorioContato = new RepositorioContatoArquivo();
        private IRepositorioCompromisso repositorioCompromisso = new RepositorioCompromissoArquivo();
        private IRepositorioTarefa repositorioTarefa = new RepositorioTarefaArquivo();
        public TelaPrincipalForm()
        {
            InitializeComponent();
        }
        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();
                return telaPrincipal;
            }
        }
        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCompromisso(repositorioCompromisso, repositorioContato);
            ConfigurarTelaPrincipal(controlador);
            HabilitarBotoesInserirEditarExcluir(true, false);

        }

        private void contatosMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorContato(repositorioContato);
            ConfigurarTelaPrincipal(controlador);
            HabilitarBotoesInserirEditarExcluir(false, false);
        }

        private void tarefasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTarefa(repositorioTarefa);
            ConfigurarTelaPrincipal(controlador);
            HabilitarBotoesInserirEditarExcluir(true, true);

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
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnConcluirItemTarefa_Click(object sender, EventArgs e)
        {
            controlador.ConcluirItens();
        }

        public void AtualizarRodape(string mensagem)
        {
            labelValidacaoRodape.Text = mensagem;
        }
        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();
            ConfigurarToolTips(controlador);
            ConfigurarListagem(controlador);
        }
        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnAddItems.ToolTipText = controlador.ToolTipAddItems;
            btnConcluirItemTarefa.ToolTipText = controlador.ToolTipConcluirItemTarefa;
        }
        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();
            listagem.Dock = DockStyle.Fill;
            panelRegistros.Controls.Clear();
            panelRegistros.Controls.Add(listagem);
        }
        private void HabilitarBotoesInserirEditarExcluir(bool temFiltro, bool temItem)
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

            if (temItem)
            {
                btnAddItems.Enabled = true;
                btnConcluirItemTarefa.Enabled = true;
            }
            else
            {
                btnAddItems.Enabled = false;
                btnConcluirItemTarefa.Enabled = false;
            }
        }

    }
}