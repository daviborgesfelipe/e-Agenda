using AutoMapper;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace e_Agenda.WebApp.Controllers.ModuloContato
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private ServicoContato servicoContato;
        private IMapper mapeador;

        public ContatoController(ServicoContato servicoContato, IMapper mapeador)
        {
            this.servicoContato = servicoContato;
            this.mapeador = mapeador;
        }

        [HttpPost]
        public IActionResult Post(
            FormsContatoViewModel contatoViewModel
        )
        {
            try
            {
                var contato = mapeador.Map<Contato>(contatoViewModel);

                var resultado = servicoContato.Inserir(contato);

                if (resultado.IsFailed)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao inserir o contato",
                        Erros = resultado.Errors.Select(x => x.Message),
                        resultado.IsFailed
                    });
                }

                var enderecoContato = Request.GetDisplayUrl() + "/visualizacao-completa/" + resultado.Value.Id;

                return Created(enderecoContato, contatoViewModel);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            Guid id, [FromBody] 
            FormsContatoViewModel contatoViewModel
        )
        {
            try
            {
                var resultadoGet =  servicoContato.SelecionarPorId(id);
                
                if (resultadoGet.IsFailed)
                {
                    return NotFound(resultadoGet.Errors.Select(x => x.Message));
                }

                var contato = mapeador.Map(contatoViewModel, resultadoGet.Value);
                
                var resultadoPut = servicoContato.Editar(contato);

                if (resultadoPut.IsFailed) 
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao editar o contato",
                        Erros = resultadoPut.Errors.Select(x => x.Message),
                        resultadoPut.IsFailed
                    });
                }

                var enderecoContato = Request.GetDisplayUrl() + "/visualizacao-completa/" + resultadoPut.Value.Id;

                return Ok(contatoViewModel);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            StatusFavoritoEnum statusFavorito
        )
        {
            try
            {
                var resultadoGet = servicoContato.SelecionarTodos(statusFavorito);

                if (resultadoGet.IsFailed)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao selecionar a lista de contatos",
                        Erros = resultadoGet.Errors.Select(x => x.Message),
                        resultadoGet.IsFailed
                    });
                }

                var contatosViewModel = mapeador.Map<List<ListarContatoViewModel>>(resultadoGet.Value);

                return Ok(contatosViewModel);

            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpGet("visualizacao-completa/{id}")]
        public IActionResult GetCompleteById(
            Guid id
        )
        {

            try
            {
                var resultadoGet = servicoContato.SelecionarPorId(id);

                if (resultadoGet.IsFailed)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao selecionar o contato por Id",
                        Erros = resultadoGet.Errors.Select(x => x.Message),
                        resultadoGet.IsFailed
                    });
                }

                var contatoViewModel = mapeador.Map<VisualizarContatoViewModel>(resultadoGet.Value);

                return Ok(contatoViewModel);
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById( Guid id ) 
        {

            try
            {
                var resultado = servicoContato.Excluir(id);

                if (resultado.IsFailed)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao excluir o contato por Id",
                        Erros = resultado.Errors.Select(x => x.Message),
                        resultado.IsFailed
                    });
                }

                return NoContent();
            }
            catch (Exception exc)
            {
                return StatusCode(500, exc.Message);
            }
        }
    }
}
