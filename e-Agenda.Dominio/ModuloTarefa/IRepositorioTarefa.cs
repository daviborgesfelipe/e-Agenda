﻿using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloTarefa
{
    public interface IRepositorioTarefa : IRepositorio<Tarefa>
    {
        Task<List<Tarefa>> SelecionarTodosAsync(StatusTarefaEnum status);
    }
}
