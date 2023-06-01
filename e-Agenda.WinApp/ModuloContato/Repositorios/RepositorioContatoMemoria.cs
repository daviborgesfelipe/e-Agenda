using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloContato.Entidades;

namespace e_Agenda.WinApp.ModuloContato.Repositorios
{
    public class RepositorioContatoMemoria : RepositorioMemoriaBase<Contato>
    {

        public RepositorioContatoMemoria(List<Contato> contatos)
        {
            listaRegistros = contatos;
        }
    }
}
