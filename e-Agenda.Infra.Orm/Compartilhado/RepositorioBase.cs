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
    }
}
