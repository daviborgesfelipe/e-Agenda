using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public List<ListarContatoViewModel> SeleciontarTodos(StatusFavoritoEnum statusFavorito)
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

            return contatosViewModel;
        }

        [HttpGet("visualizacao-completa/{id}")]
        public VisualizarContatoViewModel SeleciontarPorId(string id)
        {
            var contato = servicoContato.SelecionarPorId(Guid.Parse(id)).Value;

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

            return contatoViewModel;
        }
    }
}
