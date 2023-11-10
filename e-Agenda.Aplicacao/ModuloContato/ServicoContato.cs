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
            Log.Logger.Debug("Tentando inserir contato... {@c}", contato);

            Result resultado = Validar(contato);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioContato.InserirAsync(contato);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Contato {ContatoId} inserido com sucesso", contato.Id);

                return Result.Ok(contato);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir o Contato";

                Log.Logger.Error(ex, msgErro + " {ContatoId} ", contato.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Contato>> Editar(Contato contato)
        {
            Log.Logger.Debug("Tentando editar contato... {@c}", contato);

            var contatoExistente = await repositorioContato.SelecionarPorIdAsync(contato.Id);

            if (contatoExistente == null)
            {
                return Result.Fail($"Contato com ID {contato.Id} não encontrado.");
            }

            var resultado = Validar(contato);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await EditarAsync(contatoExistente);

                Log.Logger.Information("Contato {ContatoId} editado com sucesso", contato.Id);

                return Result.Ok(contato);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar o Contato";

                Log.Logger.Error(ex, msgErro + " {ContatoId}", contato.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Contato>> EditarAsync(Contato contato)
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
            Log.Logger.Debug("Tentando excluir contato... {@c}", contato);

            try
            {
                repositorioContato.ExcluirAsync(contato);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Contato {ContatoId} editado com sucesso", contato.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir o Contato";

                Log.Logger.Error(ex, msgErro + " {ContatoId}", contato.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Contato>>> SelecionarTodosAsync(StatusFavoritoEnum statusFavorito)
        {
            Log.Logger.Debug("Tentando selecionar contatos...");

            try
            {
                var contatos = await repositorioContato.SelecionarTodosAsync(statusFavorito);

                Log.Logger.Information("Contatos selecionados com sucesso");

                return Result.Ok(contatos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Contatos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Contato>> SelecionarPorIdAsync(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar contato {ContatoId}...", id);

            try
            {
                var contato = await repositorioContato.SelecionarPorIdAsync(id);

                if (contato == null)
                {
                    Log.Logger.Warning("Contato {ContatoId} não encontrado", id);

                    return Result.Fail("Contato não encontrado");
                }

                Log.Logger.Information("Contato {ContatoId} selecionado com sucesso", id);

                return Result.Ok(contato);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Contato";

                Log.Logger.Error(ex, msgErro + " {ContatoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Contato> ConfigurarFavoritos(Contato contato)
        {
            Log.Logger.Debug("Tentando favoritar contato {ContatoId}...", contato.Id);

            try
            {
                contato.ConfigurarFavorito();

                repositorioContato.EditarAsync(contato);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Contato {ContatoId} favoritado com sucesso", contato.Id);

                return Result.Ok(contato);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar favoritar o Contato";

                Log.Logger.Error(ex, msgErro + " {ContatoId}", contato.Id);

                return Result.Fail(msgErro);
            }
        }
    }
}
