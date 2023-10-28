﻿using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace e_Agenda.Infra.Orm.ModuloContato
{
    public class RepositorioContatoOrm : RepositorioBase<Contato>, IRepositorioContato
    {

        public RepositorioContatoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Contato SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Compromissos)
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Contato> SelecionarTodos(StatusFavoritoEnum statusFavorito)
        {
            if (statusFavorito == StatusFavoritoEnum.Todos)
                return registros
                    .ToList();

            else if (statusFavorito == StatusFavoritoEnum.Sim)
                return registros
                    .Where(x => x.Favorito == true)
                    .ToList();
            else
                return registros
                   .Where(x => x.Favorito == false)
                   .ToList();
        }
    }
}
