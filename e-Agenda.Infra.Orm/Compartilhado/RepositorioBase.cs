using e_Agenda.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBase<TEntity> where TEntity : EntidadeBase<TEntity>
    {
        protected DbSet<TEntity> registros;
        private readonly eAgendaDbContext dbContext;

        public RepositorioBase(IContextoPersistencia contextoPersistencia)
        {
            dbContext = (eAgendaDbContext)contextoPersistencia;
            registros = dbContext.Set<TEntity>();
        }

        public virtual void Inserir(TEntity novoRegistro)
        {
            registros.Add(novoRegistro);
        }

        public virtual void Editar(TEntity registro)
        {
            registros.Update(registro);
        }

        public virtual void Excluir(TEntity registro)
        {
            registros.Remove(registro);
        }

        public virtual TEntity SelecionarPorId(Guid id)
        {
            return registros
                .SingleOrDefault(x => x.Id == id);
        }

        public virtual List<TEntity> SelecionarTodos()
        {
            return registros.ToList();
        }


        public virtual async Task<bool> EditarAsync(TEntity registro)
        {
            registros.Update(registro);
            return true;
        }

        public virtual async Task<bool> ExcluirAsync(TEntity registro)
        {
            registros.Remove(registro);
            return true;
        }

        public virtual async Task<bool> InserirAsync(TEntity novoRegistro)
        {
            await registros.AddAsync(novoRegistro);
            return true;
        }

        public virtual async Task<TEntity> SelecionarPorIdAsync(Guid id)
        {
            return await registros
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<TEntity>> SelecionarTodosAsync()
        {
            return await registros.ToListAsync();
        }


    }
}
