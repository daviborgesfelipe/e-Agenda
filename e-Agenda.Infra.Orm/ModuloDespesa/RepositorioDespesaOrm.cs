using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloDespesa
{
    public class RepositorioDespesaOrm : RepositorioBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public List<Despesa> SelecionarDespesasUltimos30Dias(DateTime dataAtual)
        {
            return registros
               .Where(x => x.Data >= dataAtual.AddDays(-30))
               .ToList();
        }

        public List<Despesa> SelecionarDespesasAntigas(DateTime dataAtual)
        {
            return registros
               .Where(x => x.Data <= dataAtual.AddDays(-30))
               .ToList();
        }

        public override Despesa SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Categorias)
                .SingleOrDefault(x => x.Id == id);
        }

        public async Task<List<Despesa>> SelecionarDespesasAntigasAsync(DateTime dataAtual)
        {
            return await registros
               .Where(x => x.Data <= dataAtual.AddDays(-30))
               .ToListAsync();
        }

        public async Task<List<Despesa>> SelecionarDespesasUltimos30DiasAsync(DateTime dataAtual)
        {
            return await registros
               .Where(x => x.Data >= dataAtual.AddDays(-30))
               .ToListAsync();
        }

        public async Task<bool> EditarAsync(Despesa registro)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExcluirAsync(Despesa registro)
        {
            throw new NotImplementedException();
        }
    }
}