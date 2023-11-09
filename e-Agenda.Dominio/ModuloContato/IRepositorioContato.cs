using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloContato
{
    public interface IRepositorioContato : IRepositorio<Contato>
    {
        Task<Contato> SelecionarPorIdAsync(Guid id);

        List<Contato> SelecionarTodos(StatusFavoritoEnum statusFavorito);

        Task<List<Contato>> SelecionarTodosAsync(StatusFavoritoEnum statusFavorito);
    }
}
