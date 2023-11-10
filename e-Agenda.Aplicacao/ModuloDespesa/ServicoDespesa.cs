using e_Agenda.Aplicacao.Compartilhado;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;
using FluentResults;
using Serilog;

namespace e_Agenda.Aplicacao.ModuloDespesa
{
    public class ServicoDespesa : ServicoBase<Despesa, ValidadorDespesa>
    {
        private IRepositorioDespesa repositorioDespesa;
        private IContextoPersistencia contextoPersistencia;

        public ServicoDespesa(IRepositorioDespesa repositorioDespesa,
                             IContextoPersistencia contexto)
        {
            this.repositorioDespesa = repositorioDespesa;
            this.contextoPersistencia = contexto;
        }

        public async Task<Result<Despesa>> InserirAsync(Despesa despesa)
        {
            Log.Logger.Debug("Tentando inserir despesa... {@d}", despesa);

            Result resultado = Validar(despesa);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioDespesa.InserirAsync(despesa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Despesa {DespesaId} inserida com sucesso", despesa.Id);

                return Result.Ok(despesa);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Despesa";

                Log.Logger.Error(ex, msgErro + " {DespesaId} ", despesa.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Despesa>> EditarAsync(Despesa despesa)
        {
            Log.Logger.Debug("Tentando editar despesa... {@d}", despesa);

            var resultado = Validar(despesa);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioDespesa.EditarAsync(despesa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Despesa {DespesaId} editada com sucesso", despesa.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Despesa";

                Log.Logger.Error(ex, msgErro + " {DespesaId}", despesa.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(despesa);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var resultadoGet = await SelecionarPorIdAsync(id);

            if (resultadoGet.IsSuccess)
                return await ExcluirAsync(resultadoGet.Value);

            return Result.Fail(resultadoGet.Errors);
        }

        public async Task<Result> ExcluirAsync(Despesa despesa)
        {
            Log.Logger.Debug("Tentando excluir despesa... {@d}", despesa);

            try
            {
                await repositorioDespesa.ExcluirAsync(despesa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Despesa {DespesaId} editada com sucesso", despesa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Despesa";

                Log.Logger.Error(ex, msgErro + " {DespesaId}", despesa.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Despesa>>> SelecionarTodosAsync()
        {
            Log.Logger.Debug("Tentando selecionar despesas...");

            try
            {
                var despesas = await repositorioDespesa.SelecionarTodosAsync();

                Log.Logger.Information("Despesas selecionadas com sucesso");

                return Result.Ok(despesas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Despesas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Despesa>>> SelecionarDespesasAntigasAsync(DateTime dataAtual)
        {
            Log.Logger.Debug("Tentando selecionar despesas antigas...");

            try
            {
                var despesas = await repositorioDespesa.SelecionarDespesasAntigasAsync(dataAtual);

                Log.Logger.Information("Despesas antigas selecionadas com sucesso");

                return Result.Ok(despesas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar as despesas antigas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Despesa>>> SelecionarDespesasUltimos30DiasAsync(DateTime dataAtual)
        {
            Log.Logger.Debug("Tentando selecionar despesas recentes...");

            try
            {
                var despesas = await repositorioDespesa.SelecionarDespesasUltimos30DiasAsync(dataAtual);

                Log.Logger.Information("Despesas recentes selecionadas com sucesso");

                return Result.Ok(despesas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar as despesas recentes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Despesa>> SelecionarPorIdAsync(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar despesa {DespesaId}...", id);

            try
            {
                var despesa = await repositorioDespesa.SelecionarPorIdAsync(id);

                if (despesa == null)
                {
                    Log.Logger.Warning("Despesa {DespesaId} não encontrada", id);

                    return Result.Fail("Despesa não encontrada");
                }

                Log.Logger.Information("Despesa {DespesaId} selecionada com sucesso", id);

                return Result.Ok(despesa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Despesa";

                Log.Logger.Error(ex, msgErro + " {DespesaId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}