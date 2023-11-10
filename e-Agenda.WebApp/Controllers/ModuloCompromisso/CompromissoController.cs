using AutoMapper;
using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Agenda.WebApp.Controllers.ModuloCompromisso
{
    [Route("api/compromissos")]
    [ApiController]
    public class CompromissoController : ControllerBase
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
        [ProducesResponseType(typeof(FormsCompromissoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Post(
            FormsCompromissoViewModel compromissoViewModel
        )
        {
            var compromissoMap = mapeador.Map<Compromisso>(compromissoViewModel);

            var resultadoPut = await servicoCompromisso.InserirAsync(compromissoMap);

            return ProcessarResultado(resultadoPut, compromissoViewModel);
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
                Dados = mapeador.Map<VisualizarCompromissoViewModel>(resultadoGetComplete)
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FormsCompromissoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Put(
            Guid id,
            FormsCompromissoViewModel compromissoViewModel
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

            return ProcessarResultado(resultadoPut, compromissoViewModel);
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

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultadoGet);

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

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultadoGet);

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

            var compromissoViewModel = mapeador.Map<List<ListarCompromissoViewModel>>(resultGet);

            return Ok(new
            {
                Sucesso = true,
                Dados = compromissoViewModel
            });
        }

        private IActionResult ProcessarResultado(Result<Compromisso> compromisso, FormsCompromissoViewModel compromissoViewModel = null)
        {
            if (compromisso.IsFailed)
                return BadRequest(new
                {
                    Sucesso = false,
                    Erros = compromisso.Errors.Select(x => x.Message)
                });

            return Ok(new
            {
                Sucesso = true,
                Dados = compromissoViewModel
            });
        }
    }
}
