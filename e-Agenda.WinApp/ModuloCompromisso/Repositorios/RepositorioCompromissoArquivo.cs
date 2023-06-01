using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;
using e_Agenda.WinApp.ModuloCompromisso.Interfaces;
using System.Text.Json;

namespace e_Agenda.WinApp.ModuloCompromisso.Repositorios
{
    internal class RepositorioCompromissoArquivo : RepositorioArquivoBase<Compromisso>, IRepositorioCompromisso
    {
        private const string NOME_ARQUIVO_COMPROMISSOS = "Compromissos.json";
        private List<Compromisso> compromissos;
        public RepositorioCompromissoArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_COMPROMISSOS))
                LerEntidadeNoArquivo();
            this.listaRegistros = compromissos;
        }

        public override void AdicionarEntidadeNoArquivo()
        {
            AdicionarCompromissossDoArquivo();
        }
        public override void LerEntidadeNoArquivo()
        {
            LerCompromissosEmArquivo();
        }

        private void AdicionarCompromissossDoArquivo()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            string compromissosJson = JsonSerializer.Serialize(compromissos, opcoes);
            File.WriteAllText(NOME_ARQUIVO_COMPROMISSOS, compromissosJson);

            AtualizarContador();
        }
        private void LerCompromissosEmArquivo()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            string compromissosJson = File.ReadAllText(NOME_ARQUIVO_COMPROMISSOS);
            if (compromissosJson.Length > 0)
            {
                compromissos = JsonSerializer.Deserialize<List<Compromisso>>(compromissosJson, options);
            }
        }

        private void AtualizarContador()
        {
            contador = compromissos.Max(x => x.id);
        }
        public override List<Compromisso> SelecionarTodos()
        {
            return compromissos;
        }
        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataTermino)
        {
            return compromissos.Where(c => c.dataCompromisso >= dataInicio && c.dataCompromisso <= dataTermino).ToList();

        }
        public List<Compromisso> SelecionarCompromissosPassados(DateTime dateTime)
        {
            return compromissos.Where(c => c.dataCompromisso < dateTime).ToList();
        }
        /*
        public override Compromisso SelecionarPorId(int id)
        {
            Compromisso entidade = compromissos.FirstOrDefault(x => x.id == id);
            return entidade;
        }
        public override void Inserir(Compromisso novoEntidade)
        {
            contador++;
            novoEntidade.id = contador;
            compromissos.Add(novoEntidade);
            AdicionarEntidadeNoArquivo();
        }
        public override void Excluir(Compromisso entidadeSelecionada)
        {
            compromissos.Remove(entidadeSelecionada);
            AdicionarEntidadeNoArquivo();

        }
        public override void Excluir(int id)
        {
            Compromisso entidadeSelecionado = SelecionarPorId(id);
            compromissos.Remove(entidadeSelecionado);
            AdicionarEntidadeNoArquivo();

        }
        public override void Editar(int id, Compromisso entidadeAtualizada)
        {
            Compromisso entidadeSelecionada = SelecionarPorId(id);
            entidadeSelecionada.AtualizarInformacoes(entidadeAtualizada);
            AdicionarEntidadeNoArquivo();
        }         
         */
    }
}
