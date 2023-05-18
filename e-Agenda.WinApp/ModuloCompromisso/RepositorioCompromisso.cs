using e_Agenda.WinApp.ModuloCompromiso;
using e_Agenda.WinApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCompromisso
{
    internal class RepositorioCompromisso
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

            //compromisso selecionado = compromisso
        }
        private Compromisso SelecionarPorId(int id)
        {
            return compromissos.FirstOrDefault(x => x.id == id);
        }
        public void Excluir(Compromisso compromisso)
        {
            compromissos.Remove(compromisso);
        }
    }
}
