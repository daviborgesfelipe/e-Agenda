using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;

namespace e_Agenda.WinApp.ModuloCompromisso.Repositorios
{
    public class RepositorioCompromissoMemoria : RepositorioMemoriaBase<Compromisso>
    {
        List<Compromisso> compromissos;

        public RepositorioCompromissoMemoria(List<Compromisso> compromissos)
        {
            listaRegistros = compromissos;
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
