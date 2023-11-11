﻿using e_Agenda.Dominio.ModuloTarefa;

namespace e_Agenda.WebApp.ViewModels.ModuloTarefa
{
    public class InserirTarefaViewModel
    {
        public string Titulo { get; set; }

        public PrioridadeTarefaEnum Prioridade { get; set; }

        public List<ItemTarefaViewModel> Itens { get; set; }
    }
}
