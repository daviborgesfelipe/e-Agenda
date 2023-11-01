using AutoMapper;
using e_Agenda.Aplicacao.ModuloTarefa;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.WebApp.ViewModels.ModuloTarefa;
using Microsoft.AspNetCore.Mvc;

namespace e_Agenda.WebApp.Controllers.ModuloTarefa
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private ServicoTarefa servicoTarefa;
        private IMapper mapeador;
        public TarefaController(ServicoTarefa servicoTarefa, IMapper mapeador)
        {
            this.servicoTarefa = servicoTarefa;
            this.mapeador = mapeador;
        }

        [HttpPost]
        public IActionResult Post(
            FormsTarefaViewModel tarefaViewModel
        )
        {
            var tarefa = mapeador.Map<Tarefa>(tarefaViewModel);

            var resultado = servicoTarefa.Inserir(tarefa);

            if (resultado.IsSuccess)
            {
                return Created("registration", tarefaViewModel);
            }

            string[] erros = resultado.Errors.Select(e => e.Message).ToArray();

            return BadRequest(new
            {
                Mensagem = "Erro ao inserir o Tarefa",
                Erros = erros,
                resultado.IsFailed
            });
        }

        [HttpGet]
        public IActionResult GetAll(StatusTarefaEnum statusTarefa)
        {
            var tarefas = servicoTarefa.SelecionarTodos(statusTarefa).Value;

            var tarefaViewModel = mapeador.Map<List<ListarTarefaViewModel>>(tarefas);

            var resultado = servicoTarefa.SelecionarTodos(StatusTarefaEnum.Todos);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(tarefaViewModel);
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
            var tarefa = servicoTarefa.SelecionarPorId(id).Value;

            var tarefaViewModel = mapeador.Map<ListarTarefaViewModel>(tarefa);

            tarefa.CalcularPercentualConcluido();

            var resultado = servicoTarefa.SelecionarPorId(id);

            string[] erros = resultado
                .Errors.Select(e => e.Message).ToArray();

            if (resultado.IsSuccess)
            {
                return Ok(tarefaViewModel);
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

        [HttpPut("{id}")]
        public IActionResult Put(
        Guid id, [FromBody]
            FormsTarefaViewModel tarefaVIewModel
        )
        {
            var tarefaDb = servicoTarefa.SelecionarPorId(id).Value;

            var tarefa = mapeador.Map(tarefaVIewModel, tarefaDb);

            var resultado = servicoTarefa.Editar(tarefaDb);

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
    }
}
