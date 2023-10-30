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

        public ContatoController(ServicoContato servicoContato)
        {
            this.servicoContato = servicoContato;
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] FormsContatoViewModel novoContato
        )
        {
            var contato = new Contato
            {
                Nome = novoContato.Nome,
                Email = novoContato.Email,
                Telefone = novoContato.Telefone,
                Empresa = novoContato.Empresa,
                Cargo = novoContato.Cargo
            };

            var resultado = servicoContato.Inserir(contato);

            if (resultado.IsSuccess)
            {
                return Created("registration", novoContato);
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
            FormsContatoViewModel contatoAtualizado
        )
        {
            var contato =  servicoContato.SelecionarPorId(id).Value;

            contato.Id = id;
            contato.Nome = contatoAtualizado.Nome;
            contato.Email = contatoAtualizado.Email;
            contato.Telefone = contatoAtualizado.Telefone;
            contato.Empresa = contatoAtualizado.Empresa;
            contato.Cargo = contatoAtualizado.Cargo;
            

            var resultado = servicoContato.Editar(contato);

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
            
            var contatosViewModel = new List<ListarContatoViewModel>();

            foreach (var contato in contatos)
            {
                var contatoViewModel = new ListarContatoViewModel
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Empresa = contato.Empresa,
                    Cargo = contato.Cargo,
                    Email = contato.Email,
                    Telefone = contato.Telefone
                };

                contatosViewModel.Add(contatoViewModel);
            }

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

            var contatoViewModel = new VisualizarContatoViewModel
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Empresa = contato.Empresa,
                Cargo = contato.Cargo,
                Email = contato.Email,
                Telefone = contato.Telefone
            };

            foreach (var c in contato.Compromissos)
            {
                var compromissoViewModel = new ListarCompromissoViewModel
                {
                    Id = c.Id,
                    Assunto = c.Assunto,
                    Data = c.Data,
                    HoraInicio = c.HoraInicio.ToString(@"hh\:mm\:ss"),
                    HoraTermino = c.HoraTermino.ToString(@"hh\:mm\:ss")
                };

                contatoViewModel.Compromissos.Add(compromissoViewModel);
            }

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
