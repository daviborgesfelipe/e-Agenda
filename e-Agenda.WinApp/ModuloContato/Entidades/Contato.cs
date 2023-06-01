using e_Agenda.WinApp.Compartilhado.Bases;

namespace e_Agenda.WinApp.ModuloContato.Entidades
{
    [Serializable]
    public class Contato : EntidadeBase<Contato>
    {
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
            nome = registroAtualizado.nome;
            telefone = registroAtualizado.telefone;
            email = registroAtualizado.email;
            cargo = registroAtualizado.cargo;
            empresa = registroAtualizado.empresa;
        }
        public override string ToString()
        {
            return "Id: " + id + " - Nome: " + nome + " - Empresa: " + empresa + " - E-mail: " + email;
        }
        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (nome == null)
            {
                erros.Add("O campo \"nome\" é obrigatorio");
            }
            if (telefone == null)
            {
                erros.Add("O campo \"telefone\"é obrigatorio");
            }
            if (email == null)
            {
                erros.Add("O campo \"email\" é obrigatoria");
            }
            if (empresa == null)
            {
                erros.Add("O campo \"empresa\" é obrigatoria");
            }
            return erros.ToArray();
        }
    }
}
