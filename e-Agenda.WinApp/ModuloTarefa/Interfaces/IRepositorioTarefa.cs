using e_Agenda.WinApp.Compartilhado.Interfaces;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloTarefa.Interfaces
{
    public interface IRepositorioTarefa : IRepositorioBase<Tarefa>
    {
        void Inserir(Tarefa novaTarefa);
        void Editar(int id, Tarefa tarefa);
        void Excluir(Tarefa tarefaSelecionada);
        Tarefa SelecionarPorId(int id);
        List<Tarefa> SelecionarPendentes();
        List<Tarefa> SelecionarConcluidas();
        List<Tarefa> SelecionarTodosOrdenadosPorPrioridade();
    }
}
