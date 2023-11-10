using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloDespesa
{
    public interface IRepositorioDespesa : IRepositorio<Despesa>
    {
        List<Despesa> SelecionarDespesasAntigas(DateTime data);
        List<Despesa> SelecionarDespesasUltimos30Dias(DateTime dataBase);

        Task<List<Despesa>> SelecionarDespesasAntigasAsync(DateTime data);
        Task<List<Despesa>> SelecionarDespesasUltimos30DiasAsync(DateTime dataBase);
    }
}
