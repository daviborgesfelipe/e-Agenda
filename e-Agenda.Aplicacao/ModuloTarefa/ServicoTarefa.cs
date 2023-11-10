using e_Agenda.Aplicacao.Compartilhado;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloTarefa;
using FluentResults;
using Serilog;

namespace e_Agenda.Aplicacao.ModuloTarefa
{
    public class ServicoTarefa : ServicoBase<Tarefa, ValidadorTarefa>
    {
        private IRepositorioTarefa repositorioTarefa;
        private IContextoPersistencia contextoPersistencia;

        public ServicoTarefa(IRepositorioTarefa repositorioTarefa,
                             IContextoPersistencia contexto)
        {
            this.repositorioTarefa = repositorioTarefa;
            this.contextoPersistencia = contexto;
        }

        public async Task<Result<Tarefa>> InserirAsync(Tarefa tarefa)
        {
            Log.Logger.Debug("Tentando inserir tarefa... {@t}", tarefa);

            Result resultado = Validar(tarefa);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioTarefa.InserirAsync(tarefa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Tarefa {TarefaId} inserida com sucesso", tarefa.Id);

                return Result.Ok(tarefa);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Tarefa";

                Log.Logger.Error(ex, msgErro + " {TarefaId} ", tarefa.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Tarefa>> EditarAsync(Tarefa tarefa)
        {
            Log.Logger.Debug("Tentando editar tarefa... {@t}", tarefa);

            var resultado = Validar(tarefa);
            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                tarefa.CalcularPercentualConcluido();

                await repositorioTarefa.EditarAsync(tarefa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Tarefa {TarefaId} editada com sucesso", tarefa.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Tarefa";

                Log.Logger.Error(ex, msgErro + " {TarefaId}", tarefa.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(tarefa);
        }

        public async Task<Result<Tarefa>> AtualizarItens(Tarefa tarefa,
            List<ItemTarefa> itensConcluidos, List<ItemTarefa> itensPendentes)
        {
            foreach (var item in itensConcluidos)
                tarefa.ConcluirItem(item.Id);

            foreach (var item in itensPendentes)
                tarefa.MarcarPendente(item.Id);

            return await EditarAsync(tarefa);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var resultadoGet = await SelecionarPorIdAsync(id);

            if (resultadoGet.IsSuccess)
                return await ExcluirAsync(resultadoGet.Value);

            return Result.Fail(resultadoGet.Errors);
        }

        public async Task<Result> ExcluirAsync(Tarefa tarefa)
        {
            Log.Logger.Debug("Tentando excluir tarefa... {@t}", tarefa);

            try
            {
                await repositorioTarefa.ExcluirAsync(tarefa);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Tarefa {TarefaId} editada com sucesso", tarefa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Tarefa";

                Log.Logger.Error(ex, msgErro + " {TarefaId}", tarefa.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Tarefa>>> SelecionarTodosAsync(StatusTarefaEnum statusSelecionado)
        {
            Log.Logger.Debug("Tentando selecionar tarefas...");

            try
            {
                var tarefas = await repositorioTarefa.SelecionarTodosAsync(statusSelecionado);

                Log.Logger.Information("Tarefas selecionadas com sucesso");

                return Result.Ok(tarefas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Tarefas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Tarefa>> SelecionarPorIdAsync(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar tarefa {TarefaId}...", id);

            try
            {
                var tarefa = await repositorioTarefa.SelecionarPorIdAsync(id);

                if (tarefa == null)
                {
                    Log.Logger.Warning("Tarefa {TarefaId} não encontrada", id);

                    return Result.Fail($"Tarefa {id} não encontrada");
                }

                Log.Logger.Information("Tarefa {TarefaId} selecionada com sucesso", id);

                return Result.Ok(tarefa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Tarefa";

                Log.Logger.Error(ex, msgErro + " {TarefaId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}
