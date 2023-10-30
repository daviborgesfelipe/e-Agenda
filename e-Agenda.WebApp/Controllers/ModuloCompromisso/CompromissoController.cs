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

        public CompromissoController(
            ServicoCompromisso servicoCompromisso
        )
        {
            this.servicoCompromisso = servicoCompromisso;
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] FormsCompromissoViewModel novoCompromisso
        )
        {
            var compromisso = new Compromisso
            {
                Assunto = novoCompromisso.Assunto,
                Local = novoCompromisso.Local,
                TipoLocal = (Dominio.ModuloCompromisso.TipoLocalizacaoCompromissoEnum)novoCompromisso.TipoLocal,
                Link = novoCompromisso.Link,
                HoraInicio = TimeSpan.Parse(novoCompromisso.HoraInicio),
                HoraTermino = TimeSpan.Parse(novoCompromisso.HoraTermino),
                ContatoId = novoCompromisso.ContatoId
            };

            var resultado = servicoCompromisso.Inserir(compromisso);

            if (resultado.IsSuccess)
            {
                return Created("registration", novoCompromisso);
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

            var compromissosViewModel = new List<ListarCompromissoViewModel>();


            foreach (var compromisso in compromissos)
            {
                var compromissoViewModel = new ListarCompromissoViewModel
                {
                    Id = compromisso.Id,
                    Assunto = compromisso.Assunto,
                    Data = compromisso.Data,
                    HoraInicio = compromisso.HoraInicio.ToString(),
                    HoraTermino = compromisso.HoraTermino.ToString(),
                    NomeContato = compromisso.Contato.Nome
                };

                compromissosViewModel.Add(compromissoViewModel);
            }

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

        [HttpPut("{id}")]
        public IActionResult Put(
            Guid id, [FromBody]
            FormsCompromissoViewModel compromissoAtualizado
        )
        {
            var compromisso = servicoCompromisso.SelecionarPorId(id).Value;

            compromisso.Id = id;
            compromisso.Assunto = compromissoAtualizado.Assunto;
            compromisso.Local = compromissoAtualizado.Local;
            compromisso.TipoLocal = (Dominio.ModuloCompromisso.TipoLocalizacaoCompromissoEnum)compromissoAtualizado.TipoLocal;
            compromisso.Link = compromissoAtualizado.Link;
            compromisso.Data = compromissoAtualizado.Data;
            compromisso.HoraInicio = TimeSpan.Parse(compromissoAtualizado.HoraInicio);
            compromisso.HoraTermino = TimeSpan.Parse(compromissoAtualizado.HoraTermino);
            compromisso.ContatoId = compromissoAtualizado.ContatoId;


            var resultado = servicoCompromisso.Editar(compromisso);

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
