using e_Agenda.Aplicacao.Compartilhado;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloContato;
using FluentResults;
using Serilog;

namespace e_Agenda.Aplicacao.ModuloContato
{
    public class ServicoContato : ServicoBase<Contato, ValidadorContato>
    {
        private IRepositorioContato repositorioContato;
        private IContextoPersistencia contextoPersistencia;

        public ServicoContato(IRepositorioContato repositorioContato,
                             IContextoPersistencia contexto)
        {
            this.repositorioContato = repositorioContato;
            this.contextoPersistencia = contexto;
        }

        public async Task<Result<Contato>> InserirAsync(Contato contato)
        {
            Result resultado = Validar(contato);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            await repositorioContato.InserirAsync(contato);

            await contextoPersistencia.GravarDadosAsync();

            return Result.Ok(contato);
        }

        public async Task<Result<Contato>> Editar(Contato contato)
        {
            var contatoExistente = await repositorioContato.SelecionarPorIdAsync(contato.Id);

            if (contatoExistente == null)
                return Result.Fail($"Contato com ID {contato.Id} não encontrado.");

            var resultado = Validar(contato);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            await EditarAsync(contatoExistente);

            return Result.Ok(contato);
        }

        private async Task<Result<Contato>> EditarAsync(Contato contato)
        {
            repositorioContato.EditarAsync(contato);

            await contextoPersistencia.GravarDadosAsync();

            return Result.Ok();
        }

        public async Task<Result> Excluir(Guid id)
        {
            var contatoResult = await SelecionarPorIdAsync(id);

            if (contatoResult.IsSuccess)
                return await Excluir(contatoResult.Value);

            return Result.Fail(contatoResult.Errors);
        }

        public async Task<Result> Excluir(Contato contato)
        {
            await repositorioContato.ExcluirAsync(contato);

            await contextoPersistencia.GravarDadosAsync();

            return Result.Ok();
        }

        public async Task<Result<List<Contato>>> SelecionarTodosAsync(StatusFavoritoEnum statusFavorito)
        {
            var contatos = await repositorioContato.SelecionarTodosAsync(statusFavorito);

            return Result.Ok(contatos);
        }

        public async Task<Result<Contato>> SelecionarPorIdAsync(Guid id)
        {
            var contato = await repositorioContato.SelecionarPorIdAsync(id);
            
            if (contato == null)
            {
                Log.Logger.Warning("Contato {ContatoId} não encontrado", id);

                return Result.Fail("Contato não encontrado");
            }

            return Result.Ok(contato);
        }

        public async Task<Result<Contato>> ConfigurarFavoritos(Contato contato)
        {
            contato.ConfigurarFavorito();

            await repositorioContato.EditarAsync(contato);

            await contextoPersistencia.GravarDadosAsync();

            return Result.Ok(contato);
        }
    }
}
