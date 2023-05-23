﻿namespace e_Agenda.WinApp.Compartilhado
{
    public abstract class EntidadeBase<IEntidadeBase>
    {
        public int id;
        public abstract void AtualizarInformacoes(IEntidadeBase registroAtualizado);
        public abstract List<string> Validar();

    }
}
