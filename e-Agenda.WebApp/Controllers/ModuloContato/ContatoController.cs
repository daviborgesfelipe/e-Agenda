using AutoMapper;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using Microsoft.AspNetCore.Mvc;

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
            [FromBody] FormsContatoViewModel contatoViewModel
        )
        {
            var contato = mapeador.Map<Contato>(contatoViewModel);

            var resultado = servicoContato.Inserir(contato);

            if (resultado.IsSuccess)
            {
                return Created("registration", contatoViewModel);
            }

            string[] erros = resultado.Errors.Select(e => e.Message).ToArray();
            
            return BadRequest(new
            {
                Mensagem = "Erro ao inserir o contato",
                Erros = erros,
                resultado.IsFailed
            }); 
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            Guid id, [FromBody] 
            FormsContatoViewModel contatoVielModel
        )
        {
            var contatoDb =  servicoContato.SelecionarPorId(id).Value;

            var contato = mapeador.Map(contatoVielModel, contatoDb);
            
            var resultado = servicoContato.Editar(contatoDb);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao editar o contato",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            StatusFavoritoEnum statusFavorito
        )
        {
            var contatos = servicoContato.SelecionarTodos(statusFavorito).Value;

            var contatosViewModel = mapeador.Map<List<ListarContatoViewModel>>(contatos);

            var resultado = servicoContato.SelecionarTodos(statusFavorito);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(contatosViewModel);
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao selecionar a lista de contatos",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }

        [HttpGet("visualizacao-completa/{id}")]
        public IActionResult GetCompleteById(
            Guid id
        )
        {
            var contato = servicoContato.SelecionarPorId(id).Value;

            var contatoViewModel = mapeador.Map<VisualizarContatoViewModel>(contato);

            var resultado = servicoContato.SelecionarPorId(id);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(contatoViewModel);
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao selecionar o contato por Id",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById( Guid id ) 
        {
            var resultado = servicoContato.Excluir(id);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return NoContent(); 
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao excluir o contato por Id",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }
    }
}
