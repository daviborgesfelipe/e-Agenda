﻿using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloTarefa
{
    public class RepositorioTarefaOrm : RepositorioBase<Tarefa>, IRepositorioTarefa
    {
        public RepositorioTarefaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }
        public override Tarefa SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Itens)
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Tarefa> SelecionarTodos(StatusTarefaEnum status)
        {
            if (status == StatusTarefaEnum.Concluidas)
                return registros
                    .Where(x => x.PercentualConcluido == 100).ToList();

            else if (status == StatusTarefaEnum.Pendentes)
                return registros
                    .Where(x => x.PercentualConcluido < 100).ToList();

            else
                return registros.ToList();
        }
    }
}
