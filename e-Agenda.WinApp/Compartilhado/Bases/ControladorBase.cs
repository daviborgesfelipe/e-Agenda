using e_Agenda.WinApp.Compartilhado.Interfaces;

namespace e_Agenda.WinApp.Compartilhado.Bases
{
    public abstract class ControladorBase : IControladorBase
    {
        public abstract string ToolTipInserir { get; }
        public abstract string ToolTipEditar { get; }
        public abstract string ToolTipExcluir { get; }
        public virtual string ToolTipFiltrar { get; }
        public virtual string ToolTipAddItems { get; }
        public virtual string ToolTipConcluirItemTarefa { get; }


        public virtual void Filtrar() { }
        public virtual void Adicionar() { }
        public virtual void ConcluirItens() { }
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract UserControl ObterListagem();
        public abstract string ObterTipoCadastro();
    }

}
