using e_Agenda.Aplicacao.ModuloTarefa;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.WebApp.ViewModels.ModuloTarefa;

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
        [ProducesResponseType(typeof(InserirTarefaViewModel), 201)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Post(
            InserirTarefaViewModel tarefaViewModel
        )
        {
            var tarefa = mapeador.Map<Tarefa>(tarefaViewModel);

            var resultado = await servicoTarefa.InserirAsync(tarefa);

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
        [ProducesResponseType(typeof(ListarTarefaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll(StatusTarefaEnum statusTarefa)
        {
            var tarefas = await servicoTarefa.SelecionarTodosAsync(statusTarefa);

            var tarefaViewModel = mapeador.Map<List<ListarTarefaViewModel>>(tarefas);

            var resultado = await servicoTarefa.SelecionarTodosAsync(StatusTarefaEnum.Todos);

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
        [ProducesResponseType(typeof(VisualizarTarefaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetCompleteById(
        Guid id
        )
        {
            var tarefa = await servicoTarefa.SelecionarPorIdAsync(id);

            var tarefaViewModel = mapeador.Map<VisualizarTarefaViewModel>(tarefa);

            tarefa.Value.CalcularPercentualConcluido();

            var resultado = await servicoTarefa.SelecionarPorIdAsync(id);

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
        [ProducesResponseType(typeof(EditarTarefaViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Put(
            Guid id,
            EditarTarefaViewModel tarefaVIewModel
        )
        {
            var tarefaDb = await servicoTarefa.SelecionarPorIdAsync(id);

            var tarefa = mapeador.Map(tarefaVIewModel, tarefaDb);

            var resultado = await servicoTarefa.EditarAsync(tarefaDb.Value);

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

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var resultadoGet = await servicoTarefa.SelecionarPorIdAsync(id);

            if (resultadoGet.IsFailed)
                return NotFound(resultadoGet.Errors);

            var resultadoDelete = await servicoTarefa.ExcluirAsync(resultadoGet.Value);

            string[] erros = resultadoDelete
                .Errors.Select(e => e.Message).ToArray();

            if (resultadoDelete.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new
                {
                    Mensagem = "Erro ao editar o contato",
                    Erros = erros,
                    resultadoDelete.IsFailed

                });
            }
        }
    }
}
