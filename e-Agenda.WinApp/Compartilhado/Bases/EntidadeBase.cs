using e_Agenda.WinApp.Compartilhado.Interfaces;

namespace e_Agenda.WinApp.Compartilhado.Bases
{
    [Serializable]
    public abstract class EntidadeBase<IEntidadeBase>
        where IEntidadeBase : EntidadeBase<IEntidadeBase>
    {
        public int id;
        public abstract void AtualizarInformacoes(IEntidadeBase registroAtualizado);
        public abstract string[] Validar();

    }
}
