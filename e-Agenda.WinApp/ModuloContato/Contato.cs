using e_Agenda.WinApp.Compartilhado;

namespace e_Agenda.WinApp.ModuloContato
{
    public class Contato : EntidadeBase<Contato>
    {
        public int id;
        public string nome;
        public string telefone;
        public string email;
        public string cargo;
        public string empresa;

        public Contato(string nome, string telefone, string email, string cargo, string empresa)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.cargo = cargo; 
            this.empresa = empresa;
        }

        public override void AtualizarInformacoes(Contato registroAtualizado)
        {
            this.nome = registroAtualizado.nome;
            this.telefone = registroAtualizado.telefone;
            this.email = registroAtualizado.email;
            this.cargo = registroAtualizado.cargo;
            this.empresa = registroAtualizado.empresa;
        }

        public override string ToString()
        {
            return "Id: " + id + " - Nome: " + nome + " - Empresa: " + empresa + " - E-mail: " + email;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            if (nome == null)
            {
                erros.Add("O campo \"assunto\" é obrigatorio");
            }
            if (telefone == null)
            {
                erros.Add("O campo \"dataIncio\"é obrigatorio");
            }
            if (email == null)
            {
                erros.Add("O campo \"email\" é obrigatoria");
            }
            if (empresa == null)
            {
                erros.Add("O campo \"empresa\" é obrigatoria");
            }
            return erros;
        }
    }
}
