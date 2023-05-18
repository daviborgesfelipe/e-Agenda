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
        string assunto;
        string local;
        DateTime dataCompromisso;
        DateTime dataInicio;
        DateTime dataTermino;

        Contato contato;

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime dataInicio, DateTime dataTermino)
        {
            this.assunto = assunto;
            this.local = local;
            this.dataCompromisso = dataCompromisso;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
        }
        public override string ToString()
        {
            return "Id: " + id + ", " + assunto + ", Contato: " + contato.nome;
        }
    }
}
