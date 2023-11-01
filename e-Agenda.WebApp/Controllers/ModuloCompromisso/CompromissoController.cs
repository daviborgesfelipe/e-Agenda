using AutoMapper;
using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
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
        public IActionResult Post(
            [FromBody] FormsCompromissoViewModel compromissoViewModel
        )
        {
            var compromisso = mapeador.Map<Compromisso>(compromissoViewModel);

            var resultado = servicoCompromisso.Inserir(compromisso);

            if (resultado.IsSuccess)
            {
                return Created("registration", compromissoViewModel);
            }

            string[] erros = resultado.Errors.Select(e => e.Message).ToArray();

            return BadRequest(new
            {
                Mensagem = "Erro ao inserir o compromisso",
                Erros = erros,
                resultado.IsFailed
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var compromissos = servicoCompromisso.SelecionarTodos().Value;

            var compromissosViewModel = mapeador.Map<ListarCompromissoViewModel>(compromissos);

            var resultado = servicoCompromisso.SelecionarTodos();

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(compromissosViewModel);
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
            var compromisso = servicoCompromisso.SelecionarPorId(id).Value;

            var compromissoViewModel = mapeador.Map<ListarCompromissoViewModel>(compromisso);

            var resultado = servicoCompromisso.SelecionarPorId(id);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(compromissoViewModel);
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao selecionar o compromisso por Id",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            Guid id, [FromBody]
            FormsCompromissoViewModel compromissoViewModel
        )
        {
            var compromissoDb = servicoCompromisso.SelecionarPorId(id).Value;

            var compromisso = mapeador.Map(compromissoViewModel, compromissoDb);

            var resultado = servicoCompromisso.Editar(compromissoDb);

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
                    Mensagem = "Erro ao editar o compromisso",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var resultado = servicoCompromisso.Excluir(id);

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
                    Mensagem = "Erro ao excluir o compromisso por Id",
                    Erros = erros,
                    resultado.IsFailed
                });
            }
        }
    }
}
