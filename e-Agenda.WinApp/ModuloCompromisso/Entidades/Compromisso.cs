using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloCompromisso.Enums;
using e_Agenda.WinApp.ModuloContato.Entidades;

namespace e_Agenda.WinApp.ModuloCompromisso.Entidades
{
    [Serializable]
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
        public Compromisso()
        {
            
        }

        public Compromisso(string assunto, string local, DateTime dataCompromisso, DateTime dataInicio, DateTime dataTermino, TipoCompromissoEnum tipoLocal)
        {
            this.assunto = assunto;
            this.dataCompromisso = dataCompromisso;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.tipoLocal = tipoLocal;

            if (tipoLocal == TipoCompromissoEnum.Remoto)
            {
                localRemoto = local;
            }
            else
            {
                localPresencial = local;
            }
        }

        public override void AtualizarInformacoes(Compromisso registroAtualizado)
        {
            assunto = registroAtualizado.assunto;
            contato = registroAtualizado.contato;
            dataCompromisso = registroAtualizado.dataCompromisso;
            dataInicio = registroAtualizado.dataInicio;
            dataTermino = registroAtualizado.dataTermino;
            contato = registroAtualizado.contato;
            if (tipoLocal == TipoCompromissoEnum.Remoto)
            {
                localRemoto = registroAtualizado.localRemoto;
            }
            else
            {
                localPresencial = registroAtualizado.localPresencial;
            }
        }
        public override string ToString()
        {
            return "Id: " + id + "  - Assunto: " + assunto + "  - Contato: " + contato.nome + "  - Tipo Local: " + tipoLocal.ToString() + "  - Data Compromisso: " + dataCompromisso.ToShortDateString() + "  - Horario Inicio: " + dataInicio.ToShortTimeString() + "  - Horario Termino: " + dataTermino.ToShortTimeString();
        }
        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (assunto == null)
            {
                erros.Add("O campo \"assunto\" é obrigatorio");
            }
            if (dataInicio > dataTermino)
            {
                erros.Add("O campo \"dataIncio\" a data do inicio esta no futuro da data de termino");
            }
            if (dataInicio == null)
            {
                erros.Add("O campo \"dataIncio\" é obrigatoria");
            }
            if (dataTermino > dataInicio)
            {
                erros.Add("O campo \"dataTermino\" a data de termino esta do passado da data de inicio");
            }
            if (dataTermino == null)
            {
                erros.Add("O campo \"dataTermino\" é obrigatorio");
            }
            return erros.ToArray();
        }
    }
}
