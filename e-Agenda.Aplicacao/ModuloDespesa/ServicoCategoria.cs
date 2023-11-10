using e_Agenda.Aplicacao.Compartilhado;
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;
using FluentResults;
using Serilog;

namespace e_Agenda.Aplicacao.ModuloDespesa
{
    public class ServicoCategoria : ServicoBase<Categoria, ValidadorCategoria>
    {
        private IRepositorioCategoria repositorioCategoria;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria,
                             IContextoPersistencia contexto)
        {
            this.repositorioCategoria = repositorioCategoria;
            this.contextoPersistencia = contexto;
        }

        public async Task<Result<Categoria>> InserirAsync(Categoria categoria)
        {
            Log.Logger.Debug("Tentando inserir categoria... {@c}", categoria);

            Result resultado = Validar(categoria);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioCategoria.InserirAsync(categoria);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Categoria {CategoriaId} inserida com sucesso", categoria.Id);

                return Result.Ok(categoria);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar inserir a Categoria";

                Log.Logger.Error(ex, msgErro + " {CategoriaId} ", categoria.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Categoria>> Editar(Categoria categoria)
        {
            Log.Logger.Debug("Tentando editar categoria... {@c}", categoria);

            var resultado = Validar(categoria);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                await repositorioCategoria.EditarAsync(categoria);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Categoria {CategoriaId} editada com sucesso", categoria.Id);
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar editar a Categoria";

                Log.Logger.Error(ex, msgErro + " {CategoriaId}", categoria.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(categoria);
        }

        public async Task<Result> ExcluirAsync(Guid id)
        {
            var categoriaResult = await SelecionarPorIdAsync(id);

            if (categoriaResult.IsSuccess)
                return await ExcluirAsync(categoriaResult.Value);

            return Result.Fail(categoriaResult.Errors);
        }

        public async Task<Result> ExcluirAsync(Categoria categoria)
        {
            Log.Logger.Debug("Tentando excluir categoria... {@c}", categoria);

            try
            {
                await repositorioCategoria.ExcluirAsync(categoria);

                await contextoPersistencia.GravarDadosAsync();

                Log.Logger.Information("Categoria {CategoriaId} editada com sucesso", categoria.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha no sistema ao tentar excluir a Categoria";

                Log.Logger.Error(ex, msgErro + " {CategoriaId}", categoria.Id);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<List<Categoria>>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar categorias...");

            try
            {
                var resultadoGet = await repositorioCategoria.SelecionarTodosAsync();

                Log.Logger.Information("Categorias selecionadas com sucesso");

                return Result.Ok(resultadoGet);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as Categorias";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public async Task<Result<Categoria>> SelecionarPorIdAsync(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar categoria {CategoriaId}...", id);

            try
            {
                var resultadoGetById = await repositorioCategoria.SelecionarPorIdAsync(id);

                if (resultadoGetById == null)
                {
                    Log.Logger.Warning("Categoria {CategoriaId} não encontrada", id);

                    return Result.Fail("Categoria não encontrada");
                }

                Log.Logger.Information("Categoria {CategoriaId} selecionada com sucesso", id);

                return Result.Ok(resultadoGetById);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Categoria";

                Log.Logger.Error(ex, msgErro + " {CategoriaId}", id);

                return Result.Fail(msgErro);
            }
        }


    }
}