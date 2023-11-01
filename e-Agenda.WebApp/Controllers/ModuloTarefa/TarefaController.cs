using e_Agenda.Aplicacao.ModuloContato;
using e_Agenda.Aplicacao.ModuloTarefa;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.WebApp.ViewModels.ModuloContato;
using e_Agenda.WebApp.ViewModels.ModuloTarefa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace e_Agenda.WebApp.Controllers.ModuloTarefa
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        ServicoTarefa servicoTarefa;

        public TarefaController(ServicoTarefa servicoTarefa)
        {
            this.servicoTarefa = servicoTarefa;
        }

        [HttpPost]
        public IActionResult Post(
            FormsTarefaViewModel tarefa
        )
        {
            var contato = new Tarefa
            {
                Titulo = tarefa.Titulo,
                Prioridade = tarefa.Prioridade,
                DataCriacao = DateTime.Now,
                PercentualConcluido = 0
            };
    
            foreach (var _item in tarefa.Itens)
            {
                var item = new ItemTarefa
                {
                    Titulo = _item.Titulo,
                    Status = _item.Status,
                    Concluido = _item.Concluido,
                };

                contato.AdicionarItem(item);
            }

            var resultado = servicoTarefa.Inserir(contato);

            if (resultado.IsSuccess)
            {
                return Created("registration", tarefa);
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
            var listaTarefas = servicoTarefa.SelecionarTodos(statusTarefa).Value;

            var compromissosViewModel = new List<ListarTarefaViewModel>();


            foreach (var tarefa in listaTarefas)
            {
                var compromissoViewModel = new ListarTarefaViewModel
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    DataCriacao = tarefa.DataCriacao,
                    Prioridade = tarefa.Prioridade.ToString(),
                    Situacao = StatusTarefaEnum.Todos.GetDisplayName(),
                };

                compromissosViewModel.Add(compromissoViewModel);
            }

            var resultado = servicoTarefa.SelecionarTodos(StatusTarefaEnum.Todos);

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
            var tarefa = servicoTarefa.SelecionarPorId(id).Value;

            var tarefaViewModel = new VisualizarTarefaViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                DataCriacao = tarefa.DataCriacao.ToString(@"dd-MM-yyyy"),
                DataConclusao = tarefa.DataConclusao.ToString(),
                QntdItens = tarefa.Itens.Count,
                PercentualConcluido = (double)tarefa.PercentualConcluido,
                Prioridade = tarefa.Prioridade.GetDisplayName(),
                Situacao = tarefa.PercentualConcluido == 100 ? "Concluído" : "Pendente"

            };
            foreach (var item in tarefa.Itens)
            {
                var itemTarefaViewlModel = new VisualizarItemTarefaViewModel
                {
                    Titulo = item.Titulo,
                    Situacao = item.Concluido ? "Concluído" : "Pendente",
                };
                tarefaViewModel.Itens.Add(itemTarefaViewlModel);
            }

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
            FormsTarefaViewModel tarefaAtualizada
        )
        {
            var tarefa = servicoTarefa.SelecionarPorId(id).Value;

            tarefa.Id = id;
            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Prioridade = tarefaAtualizada.Prioridade;
            foreach (var item in tarefa.Itens)
            {
                tarefa.ConcluirItem(item.Id);
            }

            var resultado = servicoTarefa.Editar(tarefa);

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
