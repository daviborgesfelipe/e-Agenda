using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using Microsoft.AspNetCore.Mvc;
using e_Agenda.Aplicacao.ModuloCompromisso;
using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloContato;

namespace e_Agenda.WebApp.Controllers.ModuloCompromisso
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissoController : ControllerBase
    {
        ServicoCompromisso servicoCompromisso;
        ServicoContato servicoContato;

        public CompromissoController(
            ServicoCompromisso servicoCompromisso,
            ServicoContato servicoContato
        )
        {
            this.servicoCompromisso = servicoCompromisso;
            this.servicoContato = servicoContato;
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
    }
}
