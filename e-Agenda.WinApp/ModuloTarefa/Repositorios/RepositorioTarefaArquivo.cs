using e_Agenda.WinApp.ModuloCompromisso.Entidades;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using e_Agenda.WinApp.ModuloTarefa.Interfaces;
using System.Text.Json;


namespace e_Agenda.WinApp.ModuloTarefa.Repositorios
{
    public class RepositorioTarefaArquivo : RepositorioArquivoBase<Tarefa>, IRepositorioTarefa
    {

        private const string NOME_ARQUIVO_TAREFAS = "Tarefas.json";
        private List<Tarefa> tarefas = new List<Tarefa>();

        public RepositorioTarefaArquivo()
        {
            this.listaRegistros = tarefas;
            if (File.Exists(NOME_ARQUIVO_TAREFAS))
                LerEntidadeNoArquivo();
        }
        public override Tarefa SelecionarPorId(int id)
        {
            Tarefa entidade = tarefas.FirstOrDefault(x => x.id == id);
            return entidade;
        }
        public override void Inserir(Tarefa novoEntidade)
        {
            contador++;
            novoEntidade.id = contador;
            tarefas.Add(novoEntidade);
            AdicionarEntidadeNoArquivo();
        }
        public override void Editar(int id, Tarefa entidadeAtualizada)
        {
            Tarefa tarefaSelecionada = SelecionarPorId(id);
            tarefaSelecionada.AtualizarInformacoes(entidadeAtualizada);
            AdicionarEntidadeNoArquivo();
        }
        public override void Excluir(Tarefa entidadeSelecionada)
        {
            tarefas.Remove(entidadeSelecionada);
            AdicionarEntidadeNoArquivo();

        }
        public override void Excluir(int id)
        {
            Tarefa entidadeSelecionado = SelecionarPorId(id);
            tarefas.Remove(entidadeSelecionado);
            AdicionarEntidadeNoArquivo();

        }
        
        public override void AdicionarEntidadeNoArquivo()
        {
            AdicionarTarefasDoArquivo();
        }
        public override void LerEntidadeNoArquivo()
        {
            LerTarefasEmArquivo();
        }
        
        private void AtualizarContador()
        {
            contador = tarefas.Max(x => x.id);
        }
        private void AdicionarTarefasDoArquivo()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            string tarefasJson = JsonSerializer.Serialize(tarefas, opcoes);
            File.WriteAllText(NOME_ARQUIVO_TAREFAS, tarefasJson);

            AtualizarContador();
        }
        private void LerTarefasEmArquivo()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            string tarefasJson = File.ReadAllText(NOME_ARQUIVO_TAREFAS);
            if (tarefasJson.Length > 0)
            {
                tarefas = JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson, options);
            }
        }

        public List<Tarefa> SelecionarPendentes()
        {
            return tarefas
                    .Where(x => x.percentualConcluido < 100)
                    .ToList();
        }
        public List<Tarefa> SelecionarConcluidas()
        {
            return tarefas
                    .Where(x => x.percentualConcluido == 100)
                    .ToList();
        }
        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return tarefas
                    .OrderByDescending(x => x.prioridade)
                    .ToList();
        }
    }
}
