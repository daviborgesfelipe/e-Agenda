using Taikandi;

namespace e_Agenda.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }


        public EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();
        }

        public abstract void Atualizar(T registro);

    }
}
