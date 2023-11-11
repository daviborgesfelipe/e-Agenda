using e_Agenda.Aplicacao.ModuloDespesa;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.WebApp.Controllers.Shared;
using e_Agenda.WebApp.ViewModels.ModuloDespesa.Despesa;

namespace e_Agenda.WebApp.Controllers.ModuloDespesa
{
    [Route("api/despesas")]
    [ApiController]
    public class DespesaController : ApiControllerBase
    {
        private readonly ServicoDespesa servicoDespesa;
        private readonly IMapper mapeador;

        public DespesaController(ServicoDespesa servicoDespesa, IMapper mapeadorDespesas)
        {
            this.servicoDespesa = servicoDespesa;
            this.mapeador = mapeadorDespesas;
        }

        [HttpGet("ultimos-30-dias")]
        [ProducesResponseType(typeof(ListarDespesaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarDespesasUltimos30Dias()
        {
            var resultadoGet = await servicoDespesa.SelecionarDespesasUltimos30DiasAsync(DateTime.Now);

            var viewModel = mapeador.Map<List<ListarDespesaViewModel>>(resultadoGet.Value);

            return Ok(viewModel);
        }

        [HttpGet("antigas")]
        [ProducesResponseType(typeof(ListarDespesaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarDespesasAntigas()
        {
            var despesaResult = await servicoDespesa.SelecionarDespesasAntigasAsync(DateTime.Now);

            var viewModel = mapeador.Map<List<ListarDespesaViewModel>>(despesaResult.Value);

            return Ok(viewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarDespesaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll()
        {
            var despesaResult = await servicoDespesa.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarDespesaViewModel>>(despesaResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarDespesaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SeleciontarPorId(Guid id)
        {
            var despesaResult = await servicoDespesa.SelecionarPorIdAsync(id);

            if (despesaResult.IsFailed)
                return NotFound(despesaResult.Errors);

            var viewModel = mapeador.Map<VisualizarDespesaViewModel>(despesaResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(InserirDespesaViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(InserirDespesaViewModel despesaViewModel)
        {
            var despesa = mapeador.Map<Despesa>(despesaViewModel);

            var resultadoGet = await servicoDespesa.InserirAsync(despesa);

            return ProcessarResultado(resultadoGet.ToResult(), despesaViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EditarDespesaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, EditarDespesaViewModel despesaViewModel)
        {
            var resultadoSelecao = await servicoDespesa.SelecionarPorIdAsync(id);

            if (resultadoSelecao.IsFailed)
                return NotFound(resultadoSelecao.Errors);

            var despesa = mapeador.Map(despesaViewModel, resultadoSelecao.Value);

            var despesaResult = await servicoDespesa.EditarAsync(despesa);

            return ProcessarResultado(despesaResult.ToResult(), despesaViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultadoGet = await servicoDespesa.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(resultadoGet.Errors);

            var resultadoDelete = await servicoDespesa.ExcluirAsync(resultadoGet.Value);

            return ProcessarResultado(resultadoDelete);
        }
    }
}

