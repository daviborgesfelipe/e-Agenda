using System.Text.Json.Serialization;
using Taikandi;

namespace e_Agenda.Dominio.ModuloTarefa
{
    public class ItemTarefa
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public bool Concluido { get; set; }

        public StatusItemTarefa Status { get; set; }

        [JsonIgnore]
        public Tarefa Tarefa { get; set; }

        public Guid TarefaId { get; set; }



        public ItemTarefa()
        {
            Id = SequentialGuid.NewGuid();
        }

        public ItemTarefa(string titulo) : this()
        {
            this.Titulo = titulo;
        }

        public ItemTarefa(Guid id)
        {
            Id = id;
        }



        public override string ToString()
        {
            return Titulo;
        }

        public void Concluir()
        {
            Concluido = true;
        }

        internal void MarcarPendente()
        {
            Concluido = false;
        }

        public override bool Equals(object obj)
        {
            return obj is ItemTarefa tarefa &&
                   Id == tarefa.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Titulo, Concluido);
        }
    }
}
