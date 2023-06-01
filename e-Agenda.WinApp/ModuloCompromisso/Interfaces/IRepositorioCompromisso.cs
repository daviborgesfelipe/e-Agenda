using e_Agenda.WinApp.Compartilhado.Interfaces;
using e_Agenda.WinApp.ModuloCompromisso.Entidades;

namespace e_Agenda.WinApp.ModuloCompromisso.Interfaces
{
    public interface IRepositorioCompromisso : IRepositorioBase<Compromisso>
    {
        void Inserir(Compromisso novoCompromisso);
        void Editar(int id, Compromisso compromisso);
        void Excluir(Compromisso compromissoSelecionada);
        Compromisso SelecionarPorId(int id);
        List<Compromisso> SelecionarCompromissosFuturos(DateTime dataInicio, DateTime dataTermino);
        List<Compromisso> SelecionarCompromissosPassados(DateTime dateTime);
    }
}
