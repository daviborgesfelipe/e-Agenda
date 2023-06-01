using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;
using e_Agenda.WinApp.ModuloContato.Entidades;
using e_Agenda.WinApp.ModuloContato.Interfaces;
using System.Text.Json;

namespace e_Agenda.WinApp.ModuloContato.Repositorios
{
    public class RepositorioContatoArquivo : RepositorioArquivoBase<Contato>, IRepositorioContato
    {

        private const string NOME_ARQUIVO_CONTATOS = "Contatos.json";
        private List<Contato> contatos;

        public RepositorioContatoArquivo()
        {
            if (File.Exists(NOME_ARQUIVO_CONTATOS))
                LerEntidadeNoArquivo();
            this.listaRegistros = contatos;
        }

        public override void AdicionarEntidadeNoArquivo()
        {
            AdicionarContatosDoArquivo();
        }
        public override void LerEntidadeNoArquivo()
        {
            LerContatosEmArquivo();
        }

        private void AdicionarContatosDoArquivo()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            string tarefasJson = JsonSerializer.Serialize(contatos, opcoes);
            File.WriteAllText(NOME_ARQUIVO_CONTATOS, tarefasJson);

            AtualizarContador();
        }
        private void LerContatosEmArquivo()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            string tarefasJson = File.ReadAllText(NOME_ARQUIVO_CONTATOS);
            if (tarefasJson.Length > 0)
            {
                contatos = JsonSerializer.Deserialize<List<Contato>>(tarefasJson, options);
            }
        }

        private void AtualizarContador()
        {
            contador = contatos.Max(x => x.id);
        }
        public override List<Contato> SelecionarTodos()
        {
            return contatos;
        }
        /*
        public override Contato SelecionarPorId(int id)
        {
            Contato contato = contatos.FirstOrDefault(x => x.id == id);

            return contato;
        }
        public override void Inserir(Contato novoContato)
        {
            contador++;
            novoContato.id = contador;
            contatos.Add(novoContato);
            AdicionarEntidadeNoArquivo();

        }
        public override void Excluir(Contato entidadeSelecionada)
        {
            contatos.Remove(entidadeSelecionada);
            AdicionarEntidadeNoArquivo();

        }
        public override void Excluir(int id)
        {
            Contato entidadeSelecionado = SelecionarPorId(id);
            contatos.Remove(entidadeSelecionado);
            AdicionarEntidadeNoArquivo();
        }
        public override void Editar(int id, Contato entidadeAtualizada)
        {
            Contato entidadeSelecionada = SelecionarPorId(id);
            entidadeSelecionada.AtualizarInformacoes(entidadeAtualizada);
            AdicionarEntidadeNoArquivo();
        }
         */
    }
}
