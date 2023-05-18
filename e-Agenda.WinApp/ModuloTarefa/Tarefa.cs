namespace e_Agenda.WinApp.ModuloTarefa
{
    public class Tarefa //Model, Entidade
    {
        public int id;
        public string titulo;
        public string prioridade;

        public Tarefa(int id, string titulo, string prioridade)
        {
            this.id = id;
            this.titulo = titulo;
            this.prioridade = prioridade;
        }

        public override string ToString()
        {
            return "Id: " + id + ", " + titulo + ", Prioridade: " + prioridade;
        }
    }
}
