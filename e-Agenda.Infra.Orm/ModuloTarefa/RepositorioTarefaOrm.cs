using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloTarefa
{
    public class RepositorioTarefaOrm : RepositorioBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override async Task<Tarefa> SelecionarPorIdAsync(Guid id)
        {
            return await registros
                .Include(x => x.Itens)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tarefa>> SelecionarTodosAsync(StatusTarefaEnum status)
        {
            if (status == StatusTarefaEnum.Concluidas)
                return await registros
                    .Where(x => x.PercentualConcluido == 100).ToListAsync();

            else if (status == StatusTarefaEnum.Pendentes)
                return await registros
                    .Where(x => x.PercentualConcluido < 100).ToListAsync();

            else
                return await registros.ToListAsync();
        }
    }
}
