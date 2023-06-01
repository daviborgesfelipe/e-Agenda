using e_Agenda.WinApp.Compartilhado.Bases;
using e_Agenda.WinApp.ModuloTarefa.Entidades;
using e_Agenda.WinApp.ModuloTarefa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.WinApp.ModuloTarefa.Repositorios
{
    public class RepositorioTarefaMemoria : RepositorioMemoriaBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaMemoria(List<Tarefa> tarefas)
        {
            listaRegistros = tarefas;
        }
        public List<Tarefa>? SelecionarConcluidas()
        {
            return listaRegistros
                .Where(x => x.percentualConcluido == 100)
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }

        public List<Tarefa>? SelecionarPendentes()
        {
            return listaRegistros
                .Where(x => x.percentualConcluido < 100)
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }

        public List<Tarefa> SelecionarTodosOrdenadosPorPrioridade()
        {
            return listaRegistros
                .OrderByDescending(x => x.prioridade)
                .ToList();
        }
    }
}
