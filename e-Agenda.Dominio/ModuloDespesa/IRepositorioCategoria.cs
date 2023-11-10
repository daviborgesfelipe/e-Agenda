using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloDespesa
{
    public interface IRepositorioCategoria : IRepositorio<Categoria>
    {
        List<Categoria> SelecionarMuitos(List<Guid> idsCategoriasSelecionadas);
    }
}