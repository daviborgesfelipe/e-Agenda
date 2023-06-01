using e_Agenda.WinApp.Compartilhado;
using e_Agenda.WinApp.Compartilhado.Enums;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using e_Agenda.WinApp.ModuloTarefa.Interfaces;
using e_Agenda.WinApp.ModuloTarefa.Repositorios;

namespace e_Agenda.WinApp.ModuloTarefa.Controladores
{
    public class ControladorTarefa : ControladorBase
    {
        IRepositorioTarefa repositorioTarefa;
        TabelaTarefaControl tabelaTarefa;
        public ControladorTarefa(IRepositorioTarefa repositorioTarefa)
        {
            this.repositorioTarefa = repositorioTarefa;
        }
        public override string ToolTipInserir { get { return "Inserir nova Tarefa"; } }
        public override string ToolTipEditar { get { return "Editar Tarefa existente"; } }
        public override string ToolTipExcluir { get { return "Excluir Tarefa existente"; } }
        public override string ToolTipFiltrar { get { return "Filtrar Tarefa existente"; } }

        public override void Inserir()
        {
            TelaTarefaForm telaTarefa = new TelaTarefaForm(edicaoDeTarefa: false);
            DialogResult opcaoEscolhida = telaTarefa.ShowDialog();
            if (opcaoEscolhida == DialogResult.OK)
            {
                Tarefa novaTarefa = telaTarefa.ObterTarefa();
                repositorioTarefa.Inserir(novaTarefa);
                CarregarTarefas();
            }
        }
        public override void Editar()
        {
            Tarefa tarefaSelecionada = ObterTarefaSelecionada();
            if (tarefaSelecionada == null)
            {
                MessageBox.Show(
                    "Selecione uma tarefa primeiro",
                    "Edição de Tarefa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
                return;
            }
            TelaTarefaForm telaTarefa = new TelaTarefaForm(edicaoDeTarefa: true);
            telaTarefa.ConfigurarTelaDeEdicao(tarefaSelecionada);
            DialogResult opcaoEscolhida = telaTarefa.ShowDialog();
            if (opcaoEscolhida == DialogResult.OK)
            {
                Tarefa tarefa = telaTarefa.ObterTarefa();
                repositorioTarefa.Editar(tarefa.id, tarefa);
                CarregarTarefas();
            }
        }

        public override void Excluir()
        {
            Tarefa tarefaSelecionada = ObterTarefaSelecionada();
            if (tarefaSelecionada == null)
            {
                MessageBox.Show(
                    "Selecione uma tarefa primeiro",
                    "Exclusão de Tarefa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );
                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir a tarefa {tarefaSelecionada.titulo}?",
                "Exclusão de Tarefa",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );
            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTarefa.Excluir(tarefaSelecionada);
                CarregarTarefas();
            }
        }
        private Tarefa ObterTarefaSelecionada()
        {
            int id = tabelaTarefa.ObterIdSelecionado();

            return repositorioTarefa.SelecionarPorId(id);
        }
        private void CarregarTarefas(List<Tarefa> tarefas)
        {
            tabelaTarefa.AtualizarRegistros(tarefas);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s)");
        }
        public override UserControl ObterListagem()
        {
            if (tabelaTarefa == null)
            {
                tabelaTarefa = new TabelaTarefaControl();
            }
            CarregarTarefas();
            return tabelaTarefa;
        }
        public override string ObterTipoCadastro()
        {
            return "Cadastro de Tarefas";
        }
        
        public override void ConcluirItens()
        {
            Tarefa tarefaSelecionada = ObterTarefaSelecionada();
            if (tarefaSelecionada == null)
            {
                MessageBox.Show(
                    "Selecione uma tarefa primeiro",
                    "Atualização de Itens da Tarefa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

                return;
            }
            TelaConcluirItensTarefaForm telaAtualizacaoItensTarefa = new TelaConcluirItensTarefaForm(tarefaSelecionada);
            DialogResult opcaoEscolhida = telaAtualizacaoItensTarefa.ShowDialog();
            if (opcaoEscolhida == DialogResult.OK)
            {
                List<ItemTarefa> itensMarcados = telaAtualizacaoItensTarefa.ObterItensMarcados();
                List<ItemTarefa> itensPendentes = telaAtualizacaoItensTarefa.ObterItensPendentes();
                foreach (ItemTarefa item in itensMarcados)
                {
                    tarefaSelecionada.ConcluirItem(item);
                }
                foreach (ItemTarefa item in itensPendentes)
                {
                    tarefaSelecionada.DesmarcarItem(item);
                }
                repositorioTarefa.Editar(tarefaSelecionada.id, tarefaSelecionada);
                CarregarTarefas();
            }
        }
        public override void Adicionar()
        {
            Tarefa tarefaSelecionada = ObterTarefaSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show(
                    "Selecione uma tarefa primeiro",
                    "Adição de Itens da Tarefa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                    );

                return;
            }

            TelaItensTarefaForm telaCadastroItensTarefa = new TelaItensTarefaForm(tarefaSelecionada);

            DialogResult opcaoEscolhida = telaCadastroItensTarefa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                List<ItemTarefa> itensParaAdicionar = telaCadastroItensTarefa.ObterItensCadastrados();

                foreach (ItemTarefa item in itensParaAdicionar)
                {
                    tarefaSelecionada.AdicionarItem(item);
                }

                repositorioTarefa.Editar(tarefaSelecionada.id, tarefaSelecionada);
                CarregarTarefas();
            }
        }
        private void CarregarTarefas()
        {
            List<Tarefa> tarefas = repositorioTarefa.SelecionarTodosOrdenadosPorPrioridade();
            tabelaTarefa.AtualizarRegistros(tarefas);
            //TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {tarefas.Count} tarefa(s)");
        }
        public override void Filtrar()
        {
            TelaFiltroTarefaForm telaFiltroTarefa = new TelaFiltroTarefaForm();

            DialogResult opcaoEscolhida = telaFiltroTarefa.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                List<Tarefa> tarefas;

                StatusFiltroTarefaEnum status = telaFiltroTarefa.ObterFiltroTarefa();

                switch (status)
                {
                    case StatusFiltroTarefaEnum.Pendentes:
                        tarefas = repositorioTarefa.SelecionarPendentes();
                        break;

                    case StatusFiltroTarefaEnum.Concluidas:
                        tarefas = repositorioTarefa.SelecionarConcluidas();
                        break;

                    default:
                        tarefas = repositorioTarefa.SelecionarTodosOrdenadosPorPrioridade();
                        break;
                }

                CarregarTarefas(tarefas);
            }
        }
    }
}
