using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using Microsoft.AspNetCore.Mvc;
using e_Agenda.Aplicacao.ModuloCompromisso;

namespace e_Agenda.WebApp.Controllers.ModuloCompromisso
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissoController : ControllerBase
    {
        ServicoCompromisso servicoCompromisso;

        public CompromissoController(ServicoCompromisso servicoCompromisso)
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
    }
}
