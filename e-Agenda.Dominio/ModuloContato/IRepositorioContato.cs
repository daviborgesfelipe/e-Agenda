using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloContato
{
    public interface IRepositorioContato : IRepositorio<Contato>
    {
        List<Contato> SelecionarTodos(StatusFavoritoEnum statusFavorito);
    }
}
