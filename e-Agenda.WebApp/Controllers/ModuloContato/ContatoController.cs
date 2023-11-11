using AutoMapper;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.Controllers.Shared;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Agenda.WebApp.Controllers.ModuloContato
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ApiControllerBase
    {
        private ServicoContato servicoContato;
        private IMapper mapeador;

        public ContatoController(ServicoContato servicoContato, IMapper mapeador)
        {
            this.servicoContato = servicoContato;
            this.mapeador = mapeador;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InserirContatoViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Post( InserirContatoViewModel contatoViewModel )
        {
            var contatoMap = mapeador.Map<Contato>(contatoViewModel);

            var resultadoPost = await servicoContato.InserirAsync(contatoMap);

            return ProcessarResultado(resultadoPost.ToResult(), contatoViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EditarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Put(
            Guid id,
            EditarContatoViewModel contatoViewModel
        )
        {
            var resultadoGet = await servicoContato.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(resultadoGet.Errors);

            var contato = mapeador.Map(contatoViewModel, resultadoGet.Value);

            var resultadoPut = await servicoContato.Editar(contato);

            return ProcessarResultado(resultadoPut.ToResult(), contatoViewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll( StatusFavoritoEnum statusFavorito )
        {
            var resultadoGetAll = await servicoContato.SelecionarTodosAsync(statusFavorito);

            if (resultadoGetAll.IsFailed)
                return NotFound(resultadoGetAll.Errors);

            return Ok(mapeador.Map<List<ListarContatoViewModel>>(resultadoGetAll.Value));
        }

        [HttpGet("visualizacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarContatoViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetCompleteById( Guid id )
        {
            var resultadoGet = await servicoContato.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(resultadoGet.Errors);

            return Ok(mapeador.Map<VisualizarContatoViewModel>(resultadoGet.Value));
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
                return NotFound(resultadoSelecao.Errors);

            var resultadoDelete = await servicoContato.Excluir(resultadoSelecao.Value);

            return ProcessarResultado(resultadoDelete);
        }
    }
}
