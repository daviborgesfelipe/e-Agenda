using AutoMapper;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Agenda.WebApp.Controllers.ModuloContato
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private ServicoContato servicoContato;
        private IMapper mapeador;
        private readonly ILogger<ContatoController> logger;

        public ContatoController(ServicoContato servicoContato, IMapper mapeador, ILogger<ContatoController> logger)
        {
            this.servicoContato = servicoContato;
            this.mapeador = mapeador;
            this.logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FormsContatoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Post(
            FormsContatoViewModel contatoViewModel
        )
        {
            var contatoMap = mapeador.Map<Contato>(contatoViewModel);

            var resultadoPost = await servicoContato.InserirAsync(contatoMap);

            return ProcessarResultado(resultadoPost, contatoViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FormsContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Put(
            Guid id, 
            FormsContatoViewModel contatoViewModel
        )
        {
            var resultadoGet = await servicoContato.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoGet.Errors.Select(x => x.Message)
                });

            var contato = mapeador.Map(contatoViewModel, resultadoGet.Value);

            var resultadoPut = await servicoContato.Editar(contato);

            return ProcessarResultado(resultadoPut, contatoViewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll(
            StatusFavoritoEnum statusFavorito
        )
        {
            logger.LogInformation("Selecionado todos os contatos " + statusFavorito);

            var contatos = await servicoContato.SelecionarTodosAsync(statusFavorito);

            return Ok(new
            {
                Sucesso = true,
                Dados = mapeador.Map<List<ListarContatoViewModel>>(contatos.Value),
                QtdRegistros = contatos.Value.Count
            });
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetCompleteById(
            Guid id
        )
        {
            var contatoResult = await servicoContato.SelecionarPorIdAsync(id);

            if (contatoResult.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = contatoResult.Errors.Select(x => x.Message)
                });

            return Ok(new
            {
                Sucesso = true,
                Dados = mapeador.Map<VisualizarContatoViewModel>(contatoResult)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> DeleteById( Guid id ) 
        {
            var resultadoSelecao = await servicoContato.SelecionarPorIdAsync(id);

            if (resultadoSelecao.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoSelecao.Errors.Select(x => x.Message)
                });

            var resultadoDelete = await servicoContato.Excluir(resultadoSelecao.Value);

            return ProcessarResultado(resultadoDelete);
        }

        private IActionResult ProcessarResultado(Result<Contato> contatoResult, FormsContatoViewModel contatoViewModel = null)
        {
            if (contatoResult.IsFailed)
                return BadRequest(new
                {
                    Sucesso = false,
                    Erros = contatoResult.Errors.Select(x => x.Message)
                });

            return Ok(new
            {
                Sucesso = true,
                Dados = contatoViewModel
            });
        }
    }
}
