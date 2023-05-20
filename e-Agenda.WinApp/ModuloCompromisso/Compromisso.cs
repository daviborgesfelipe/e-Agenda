using e_Agenda.WinApp.Compartilhado;
using e_Agenda.WinApp.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloCompromiso
{
    public class Compromisso : EntidadeBase
    {
        public Contato contato;
        public string assunto;
        public string local;
        public DateTime dataCompromisso;
        public DateTime dataInicio;
        public DateTime dataTermino;

        public List<Contato> contatoList;

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime dataInicio, DateTime dataTermino)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataCompromisso = dataCompromisso;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;

            this.contatoList = new List<Contato>();
        }

        public override string ToString()
        {
            return "Id: " + id + ", " + assunto + ", Contato: " + contato.nome + ", Local" + local + ", Data: " + dataCompromisso.ToShortDateString() + ", Inicio: " + dataInicio.ToShortTimeString() + ", Termino: " + dataTermino.ToShortTimeString();
        }
    }
}
