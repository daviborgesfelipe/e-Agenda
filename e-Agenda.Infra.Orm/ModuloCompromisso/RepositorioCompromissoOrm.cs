using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloCompromisso
{
    public class RepositorioCompromissoOrm : RepositorioBase<Compromisso>, IRepositorioCompromisso
    {
        public RepositorioCompromissoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Compromisso SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Contato)
                .SingleOrDefault(x => x.Id == id);
        }

        public override List<Compromisso> SelecionarTodos()
        {
            return registros
                .Include(x => x.Contato)
                .ToList();
        }

        public List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicial, DateTime dataFinal)
        {
            return registros
                .Include(x => x.Contato)
                .Where(x => x.Data >= dataInicial)
                .Where(x => x.Data <= dataFinal)
                .ToList();
        }

        public List<Compromisso> SelecionarCompromissosPassados(DateTime dataDeHoje)
        {
            return registros
                .Include(x => x.Contato)
                .Where(x => x.Data < dataDeHoje)
                .ToList();
        }
    }
}
