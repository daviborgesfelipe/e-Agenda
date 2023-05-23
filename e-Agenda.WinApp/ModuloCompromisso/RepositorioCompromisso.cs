using e_Agenda.WinApp.Compartilhado;
using e_Agenda.WinApp.ModuloCompromiso;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
        List<Compromisso> compromissos;

        public RepositorioCompromisso(List<Compromisso> compromissos)
        {
            this.listaRegistros = compromissos;
            compromissos = listaRegistros;
        }

        internal List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicial, DateTime dataFinal)
        {
            return compromissos.Where(c => c.dataCompromisso >= dataInicial && c.dataCompromisso <= dataFinal).ToList();

        }
        internal List<Compromisso> SelecionarCompromissosPassados(DateTime now)
        {
            return compromissos.Where(c => c.dataCompromisso < now).ToList();
        }
    }
}
