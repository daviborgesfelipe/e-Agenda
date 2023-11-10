using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloCompromisso
{
    public interface IRepositorioCompromisso : IRepositorio<Compromisso>
    {
        List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicial, DateTime dataFinal);

        List<Compromisso> SelecionarCompromissosPassados(DateTime dataDeHoje);

        Task<List<Compromisso>> SelecionarCompromissosFuturosAsync(DateTime dataInicial, DateTime dataFinal);

        Task<List<Compromisso>> SelecionarCompromissosPassadosAsync(DateTime dataDeHoje);
    }
}
