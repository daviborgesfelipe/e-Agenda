namespace e_Agenda.WinApp.Compartilhado
{
    [Serializable]
    public abstract class EntidadeBase<IEntidadeBase>
    {
        public int id;
        public abstract void AtualizarInformacoes(IEntidadeBase registroAtualizado);
        public abstract string[] Validar();

    }
}
