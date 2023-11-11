using e_Agenda.Aplicacao.ModuloDespesa;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.WebApp.Controllers.Shared;
using e_Agenda.WebApp.ViewModels.ModuloDespesa.Categoria;

namespace e_Agenda.WebApp.Controllers.ModuloDespesa
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ApiControllerBase
    {
        private readonly ServicoCategoria servicoCategoria;
        private readonly IMapper mapeador;

        public CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeadorCategorias)
        {
            this.servicoCategoria = servicoCategoria;
            this.mapeador = mapeadorCategorias;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarCategoriaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SeleciontarTodos()
        {
            var categoriaResult = await servicoCategoria.SelecionarTodos();

            var viewModel = mapeador.Map<List<ListarCategoriaViewModel>>(categoriaResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarCategoriaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SeleciontarPorId(Guid id)
        {
            var categoriaResult = await servicoCategoria.SelecionarPorIdAsync(id);

            if (categoriaResult.IsFailed)
                return NotFound(categoriaResult.Errors);

            var viewModel = mapeador.Map<VisualizarCategoriaViewModel>(categoriaResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(InserirCategoriaViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(InserirCategoriaViewModel categoriaViewModel)
        {
            var categoria = mapeador.Map<Categoria>(categoriaViewModel);

            var categoriaResult = await servicoCategoria.InserirAsync(categoria);

            return ProcessarResultado(categoriaResult.ToResult(), categoriaViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EditarCategoriaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, EditarCategoriaViewModel categoriaViewModel)
        {
            var resultadoSelecao = await servicoCategoria.SelecionarPorIdAsync(id);

            if (resultadoSelecao.IsFailed)
                return NotFound(resultadoSelecao.Errors);

            var categoria = mapeador.Map(categoriaViewModel, resultadoSelecao.Value);

            var categoriaResult = await servicoCategoria.Editar(categoria);

            return ProcessarResultado(categoriaResult.ToResult(), categoriaViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultadoSelecao = await servicoCategoria.SelecionarPorIdAsync(id);

            if (resultadoSelecao.IsFailed)
                return NotFound(resultadoSelecao.Errors);

            var categoriaResult = await servicoCategoria.ExcluirAsync(resultadoSelecao.Value);

            return ProcessarResultado(categoriaResult);
        }
    }
}
