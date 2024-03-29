﻿using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.WebApp.ViewModels.ModuloContato;

namespace e_Agenda.WebApp.ViewModels.ModuloCompromisso
{
    public class VisualizarCompromissoViewModel
    {
        public Guid Id { get; set; }

        public string Assunto { get; set; }

        public string Local { get; set; }

        public TipoLocalizacaoCompromissoEnum TipoLocal { get; set; }

        public string Link { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraTermino { get; set; }

        public ListarContatoViewModel Contato { get; set; }
    }
}