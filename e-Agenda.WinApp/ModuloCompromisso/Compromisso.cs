using e_Agenda.WinApp.Compartilhado;
using e_Agenda.WinApp.ModuloCompromisso.Enums;
using e_Agenda.WinApp.ModuloContato;

namespace e_Agenda.WinApp.ModuloCompromiso
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public Contato contato;
        public string assunto;
        public string localRemoto;
        public string localPresencial;
        public DateTime dataCompromisso;
        public DateTime dataInicio;
        public DateTime dataTermino;
        public TipoCompromissoEnum tipoLocal;

        public List<Contato> contatoList;

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime dataInicio, DateTime dataTermino, TipoCompromissoEnum tipoLocal)
        {
            this.assunto = assunto;
            this.dataCompromisso = dataCompromisso;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.tipoLocal = tipoLocal;

            if (tipoLocal == TipoCompromissoEnum.Remoto)
            {
                this.localRemoto = local;
            }
            else
            {
                this.localPresencial = local;
            }
            this.contatoList = new List<Contato>();
        }

        public override void AtualizarInformacoes(Compromisso registroAtualizado)
        {
            this.assunto = registroAtualizado.assunto;
            this.contato = registroAtualizado.contato;
            this.dataCompromisso = registroAtualizado.dataCompromisso;
            this.dataInicio = registroAtualizado.dataInicio;
            this.dataTermino = registroAtualizado.dataTermino;
            this.contato = registroAtualizado.contato;
            if (this.tipoLocal == TipoCompromissoEnum.Remoto)
            {
                this.localRemoto = registroAtualizado.localRemoto;
            }
            else
            {
                this.localPresencial = registroAtualizado.localPresencial;
            }
        }

        public override string ToString()
        {
            return "Id: " + id + "  - Assunto: " + assunto + "  - Contato: " + contato.nome + "  - Tipo Local: " + tipoLocal.ToString()  + "  - Data Compromisso: " + dataCompromisso.ToShortDateString() + "  - Horario Inicio: " + dataInicio.ToShortTimeString() + "  - Horario Termino: " + dataTermino.ToShortTimeString();
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            if (assunto == null)
            {
                erros.Add("O campo \"assunto\" é obrigatorio");
            }
            if (dataInicio > dataTermino)
            {
                erros.Add("O campo \"dataIncio\" data do inicio esta no futuro da data de termino");
            }
            if (dataInicio == null)
            {
                erros.Add("O campo \"dataIncio\" é obrigatoria");
            }
            if (dataTermino > dataInicio)
            {
                erros.Add("O campo \"dataTermino\" data de termino esta do passado da data de inicio");
            }
            if (dataTermino == null)
            {
                erros.Add("O campo \"dataTermino\" é obrigatorio");
            }
            return erros;
        }
    }
}
