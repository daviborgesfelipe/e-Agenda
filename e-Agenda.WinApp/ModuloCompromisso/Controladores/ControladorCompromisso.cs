using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;
using e_Agenda.WinApp.ModuloCompromisso.Interfaces;
using e_Agenda.WinApp.ModuloContato.Interfaces;

namespace e_Agenda.WinApp.ModuloCompromisso.Controladores
{
    internal class ControladorCompromisso : ControladorBase
    {
        IRepositorioCompromisso repositorioCompromisso;
        IRepositorioContato repositorioContato;
        TabelaCompromissoControl listagemCompromisso;

        public ControladorCompromisso(IRepositorioCompromisso repositorioCompromisso, IRepositorioContato repositorioContato)
        {
            this.repositorioCompromisso = repositorioCompromisso;
            this.repositorioContato = repositorioContato;
        }

        public override string ToolTipInserir { get { return "Inserir novo Compromisso"; } }
        public override string ToolTipEditar { get { return "Editar Compromisso existente"; } }
        public override string ToolTipExcluir { get { return "Excluir Compromisso existente"; } }
        public override string ToolTipFiltrar { get { return "Filtrar Compromissos existente"; } }

        public override void Editar()
        {
            Compromisso compromisso = ObterCompromissoSelecionado();

            if (compromisso == null)
            {
                MessageBox.Show(
                    $"Selecione um compromisso primeiro!",
                    "Edição de Compromissos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

                return;
            }

            TelaCompromissoForm telaCompromisso = new TelaCompromissoForm(repositorioCompromisso, repositorioContato);
            telaCompromisso.Compromisso = compromisso;
            DialogResult opcaoEscolhida = telaCompromisso.ShowDialog();
            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioCompromisso.Editar(compromisso.id, telaCompromisso.Compromisso);
                CarregarCompromisso();
            }
        }

        public override void Excluir()
        {
            Compromisso compromisso = ObterCompromissoSelecionado();

            if (compromisso == null)
            {
                MessageBox.Show(
                    "Selecione um compromisso primeiro",
                    "Exclusao de Compromissos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir o compromisso {compromisso.assunto}?",
                "Exclusao de Compromissos"
                );
            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioCompromisso.Excluir(compromisso);

                CarregarCompromisso();
            }
        }

        private Compromisso ObterCompromissoSelecionado()
        {
            int id = listagemCompromisso.ObterIdSelecionado();
            return repositorioCompromisso.SelecionarPorId(id);
        }

        public override void Inserir()
        {
            TelaCompromissoForm telaCompromisso = new TelaCompromissoForm(repositorioCompromisso, repositorioContato);
            DialogResult opcaoEscolhida = telaCompromisso.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Compromisso compromisso = telaCompromisso.Compromisso;
                repositorioCompromisso.Inserir(compromisso);
                CarregarCompromisso();
            }
        }

        public override void Filtrar()
        {
            TelaFiltroCompromissosForm telaFiltro = new TelaFiltroCompromissosForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                StatusCompromissoEnum statusSelecionado = telaFiltro.StatusSelecionado;
                DateTime dataInicial = telaFiltro.DataInicial.Date;
                DateTime dataFinal = telaFiltro.DataFinal.Date;
                CarregarCompromissoComFiltro(statusSelecionado, dataInicial, dataFinal);
            }
        }
        private void CarregarCompromissoComFiltro(StatusCompromissoEnum statusSelecionado, DateTime dataInicial, DateTime dataFinal)
        {
            string tipoCompromisso;
            List<Compromisso> compromissos;

            switch (statusSelecionado)
            {
                case StatusCompromissoEnum.Futuros:
                    compromissos = repositorioCompromisso.SelecionarCompromissosFuturos(dataInicial, dataFinal);
                    tipoCompromisso = "Futuro";
                    break;
                case StatusCompromissoEnum.Passados:
                    compromissos = repositorioCompromisso.SelecionarCompromissosPassados(DateTime.Now);
                    tipoCompromisso = "Passado";
                    break;
                default:
                    compromissos = repositorioCompromisso.SelecionarTodos();
                    tipoCompromisso = "";
                    break;
            }
            listagemCompromisso.AtualizarRegistros(compromissos);
        }
        private void CarregarCompromisso()
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            listagemCompromisso.AtualizarRegistros(compromissos);
        }
        public override UserControl ObterListagem()
        {
            if (listagemCompromisso == null)
            {
                listagemCompromisso = new TabelaCompromissoControl();
            }
            CarregarCompromisso();
            return listagemCompromisso;
        }
        public override string ObterTipoCadastro()
        {
            return "Cadastro de Compromissos";
        }
    }
}
