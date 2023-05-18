namespace e_Agenda.WinApp.ModuloContato
{
    public class RepositorioContato
    {
        List<Contato> contatos = new List<Contato>();
        private static int contador;

        public void Inserir(Contato contato)
        {
            contador++;
            contato.id = contador;
            contatos.Add(contato);
        }

        public List<Contato> SelecionarTodos()
        {
            return contatos;
        }

        public void Editar(Contato contato)
        {
            Contato contatoSelecionado = SelecionarPorId(contato.id);

            contatoSelecionado.nome = contato.nome;
            contatoSelecionado.telefone = contato.telefone;
            contatoSelecionado.email = contato.email;
            contatoSelecionado.cargo = contato.cargo;
            contatoSelecionado.empresa = contato.empresa;                 
        }

        private Contato SelecionarPorId(int id)
        {
            return contatos.FirstOrDefault(x => x.id == id);
        }

        public void Excluir(Contato contato)
        {
            contatos.Remove(contato);
        }
    }
}
