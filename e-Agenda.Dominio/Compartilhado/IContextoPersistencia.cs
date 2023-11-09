namespace e_Agenda.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        void DesfazerAlteracoes();

        void GravarDados();

        Task<bool> GravarDadosAsync();
    }
}
