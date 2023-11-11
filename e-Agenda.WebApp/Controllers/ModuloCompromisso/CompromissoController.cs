using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.Controllers.Shared;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;

namespace e_Agenda.WebApp.Controllers.ModuloCompromisso
{
    [Route("api/compromissos")]
    [ApiController]
    public class CompromissoController : ApiControllerBase
    {
        ServicoCompromisso servicoCompromisso;
        private IMapper mapeador;

        public CompromissoController(
            ServicoCompromisso servicoCompromisso,
            IMapper mapeador
        )
        {
            this.servicoCompromisso = servicoCompromisso;
            this.mapeador = mapeador;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InserirCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Post(
            InserirCompromissoViewModel compromissoViewModel
        )
        {
            var compromissoMap = mapeador.Map<Compromisso>(compromissoViewModel);

            var resultadoPut = await servicoCompromisso.InserirAsync(compromissoMap);

            return ProcessarResultado(resultadoPut.ToResult(), compromissoViewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll()
        {

            var resultadoGetAll = await servicoCompromisso.SelecionarTodosAsync();

            if (resultadoGetAll.IsFailed)
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao selecionar a lista de compromissos",
                    Erros = resultadoGetAll.Errors.Select(e => e.Message).ToArray(),
                    resultadoGetAll.IsFailed
                });
            }

            return Ok(new
            {
                Sucesso = true,
                Dados = mapeador.Map<List<ListarCompromissoViewModel>>(resultadoGetAll.Value),
                QtdRegistros = resultadoGetAll.Value.Count
            });
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarCompromissoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetCompleteById(
            Guid id
        )
        {
            var resultadoGetComplete = await servicoCompromisso.SelecionarPorIdAsync(id);

            if (resultadoGetComplete.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoGetComplete.Errors.Select(x => x.Message)
                });

            return Ok(new
            {
                Sucesso = true,
                Dados = mapeador.Map<VisualizarCompromissoViewModel>(resultadoGetComplete.Value)
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EditarCompromissoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Put(
            Guid id,
            EditarCompromissoViewModel compromissoViewModel
        )
        {
            var resultadoGet = await servicoCompromisso.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoGet.Errors.Select(x => x.Message)
                });

            var compromisso = mapeador.Map(compromissoViewModel, resultadoGet);

            var resultadoPut = await servicoCompromisso.EditarAsync(resultadoGet.Value);

            return ProcessarResultado(resultadoPut.ToResult(), compromissoViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var resultadoGet = await servicoCompromisso.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoGet.Errors.Select(x => x.Message)
                });

            var resultadoDelete = await servicoCompromisso.Excluir(resultadoGet.Value);

            return ProcessarResultado(resultadoDelete);
        }

        [HttpGet("hoje/{dataAtual:datetime}")]
        [ProducesResponseType(typeof(ListarCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCompromissosDeHoje(DateTime dataAtual)
        {
            var resultadoGet = await servicoCompromisso.SelecionarCompromissosFuturosAsync(dataAtual, dataAtual);

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultadoGet.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = compromissoViewModel
            });
        }

        [HttpGet("futuros/{dataInicial:datetime}={dataFinal:datetime}")]
        [ProducesResponseType(typeof(ListarCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCompromissosFuturos(DateTime dataInicial, DateTime dataFinal)
        {
            var resultadoGet = await servicoCompromisso.SelecionarCompromissosFuturosAsync(dataInicial, dataFinal);

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultadoGet.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = compromissoViewModel
            });
        }

        [HttpGet("passados/{dataAtual:datetime}")]
        [ProducesResponseType(typeof(ListarCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarCompromissosPassados(DateTime dataAtual)
        {
            var resultGet = await servicoCompromisso.SelecionarCompromissosPassadosAsync(dataAtual);

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultGet.Value);

            return Ok(new
            {
                Sucesso = true,
                Dados = compromissoViewModel
            });
        }
    }
}
