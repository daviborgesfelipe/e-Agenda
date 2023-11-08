using AutoMapper;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using FluentResults;
using Microsoft.AspNetCore.Http.Extensions;
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
        public IActionResult Post(
            FormsContatoViewModel contatoViewModel
        )
        {

            var contato = mapeador.Map<Contato>(contatoViewModel);

            return ProcessarResultado(servicoContato.Inserir(contato), contatoViewModel);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FormsContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public IActionResult Put(
            Guid id, [FromBody] 
            FormsContatoViewModel contatoViewModel
        )
        {
            var resultadoGet = servicoContato.SelecionarPorId(id);

            if (resultadoGet.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoGet.Errors.Select(x => x.Message)
                });

            var contato = mapeador.Map(contatoViewModel, resultadoGet.Value);

            return ProcessarResultado(servicoContato.Editar(contato), contatoViewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public IActionResult GetAll(
            StatusFavoritoEnum statusFavorito
        )
        {
            logger.LogInformation("Selecionado todos os contatos " + statusFavorito);

            var contatos = servicoContato.SelecionarTodos(statusFavorito).Value;

            return Ok(new
            {
                Sucesso = true,
                Dados = mapeador.Map<List<ListarContatoViewModel>>(contatos),
                QtdRegistros = contatos.Count
            });
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public IActionResult GetCompleteById(
            Guid id
        )
        {
            var contatoResult = servicoContato.SelecionarPorId(id);

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
        public IActionResult DeleteById( Guid id ) 
        {
            var resultadoSelecao = servicoContato.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
                return NotFound(new
                {
                    Sucesso = false,
                    Erros = resultadoSelecao.Errors.Select(x => x.Message)
                });

            return ProcessarResultado(servicoContato.Excluir(resultadoSelecao.Value));
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
