using e_Agenda.Aplicacao.Compartilhado;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using FluentResults;
using Serilog;

namespace e_Agenda.Aplicacao.ModuloCompromisso
{
    public class ServicoCompromisso : ServicoBase<Compromisso, ValidadorCompromisso>
    {
        private IRepositorioCompromisso repositorioCompromisso;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCompromisso(
            IRepositorioCompromisso repositorioCompromisso,
            IContextoPersistencia contextoPersistencia
        )
        {
            this.repositorioCompromisso = repositorioCompromisso;
            this.contextoPersistencia = contextoPersistencia;
        }

        #region Assincrono
        public async Task<Result<Compromisso>> InserirAsync(Compromisso compromisso)
        {
            Log.Logger.Debug("Tentando inserir compromisso... {@c}", compromisso);

            Result resultado = Validar(compromisso);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioCompromisso.InserirAsync(compromisso);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Compromisso {CompromissoId} inserido com sucesso", compromisso.Id);

                return Result.Ok(compromisso);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir o Compromisso";

                Log.Logger.Error(ex, msgErro + " {CompromissoId} ", compromisso.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result> Excluir(Compromisso compromisso)
        {
            Log.Logger.Debug("Tentando excluir compromisso... {@c}", compromisso);

            try
            {
                repositorioCompromisso.ExcluirAsync(compromisso);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Compromisso {CompromissoId} editado com sucesso", compromisso.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir o Compromisso";

                Log.Logger.Error(ex, msgErro + " {CompromissoId}", compromisso.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result> Excluir(Guid id)
        {
            var compromissoResult = await SelecionarPorIdAsync(id);

            if (compromissoResult.IsSuccess)
                return await Excluir(compromissoResult.Value);

            return Result.Fail(compromissoResult.Errors);
        }

        public async Task<Result<Compromisso>> EditarAsync(Compromisso compromisso)
        {
            repositorioCompromisso.EditarAsync(compromisso);

            await contextoPersistencia.GravarDadosAsync();

            return Result.Ok();
        }

        public async Task<Result<List<Compromisso>>> SelecionarCompromissosPassadosAsync(DateTime hoje)
        {
            return await repositorioCompromisso.SelecionarCompromissosPassadosAsync(hoje);
        }

        public async Task<Result<List<Compromisso>>> SelecionarCompromissosFuturosAsync(DateTime dataInicial, DateTime dataFinal)
        {
            return await repositorioCompromisso.SelecionarCompromissosFuturosAsync(dataInicial, dataFinal);
        }

        public async Task<Result<Compromisso>> SelecionarPorIdAsync(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar compromisso {CompromissoId}...", id);

            try
            {
                var compromisso = await repositorioCompromisso.SelecionarPorIdAsync(id); ;

                if (compromisso == null)
                {
                    Log.Logger.Warning("Compromisso {CompromissoId} não encontrado", id);

                    return Result.Fail("Compromisso não encontrado");
                }

                Log.Logger.Information("Compromisso {CompromissoId} selecionado com sucesso", id);

                return Result.Ok(compromisso);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Compromisso";

                Log.Logger.Error(ex, msgErro + " {CompromissoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Compromisso>>> SelecionarTodosAsync()
        {
            Log.Logger.Debug("Tentando selecionar compromissos...");

            try
            {
                var compromissos = await repositorioCompromisso.SelecionarTodosAsync();

                Log.Logger.Information("Compromissos selecionados com sucesso");

                return Result.Ok(compromissos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Compromissos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        #endregion
    }
}
