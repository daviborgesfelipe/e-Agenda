using e_Agenda.WinApp.ModuloCompromiso;
using e_Agenda.WinApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    public class RepositorioCompromisso
    {
        List<Compromisso> compromissos = new List<Compromisso>();
        private static int contador;
        internal void Inserir(Compromisso compromisso)
        {
            contador++;
            compromisso.id = contador;
            compromissos.Add(compromisso);
        }

        internal List<Compromisso> SelecionarTodos()
        {
            return compromissos;
        }
        public void Editar(Compromisso compromisso)
        {
            Compromisso compromissoSelecionado = SelecionarPorId(compromisso.id);

            compromissoSelecionado.assunto = compromisso.assunto;
            compromissoSelecionado.local = compromisso.local;
            compromissoSelecionado.contato = compromisso.contato;
            compromissoSelecionado.dataCompromisso = compromisso.dataCompromisso;
            compromissoSelecionado.dataInicio = compromisso.dataInicio;
            compromissoSelecionado.dataTermino = compromisso.dataTermino;
        }
        private Compromisso SelecionarPorId(int id)
        {
            return compromissos.FirstOrDefault(x => x.id == id);
        }
        public void Excluir(Compromisso compromisso)
        {
            compromissos.Remove(compromisso);
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
