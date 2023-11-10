using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloDespesa
{
    public class RepositorioCategoriaOrm : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoriaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public List<Categoria> SelecionarMuitos(List<Guid> idsCategoriasSelecionadas)
        {
            return registros.Where(categoria => idsCategoriasSelecionadas.Contains(categoria.Id)).ToList();
        }

        public override Categoria SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Despesas)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}

