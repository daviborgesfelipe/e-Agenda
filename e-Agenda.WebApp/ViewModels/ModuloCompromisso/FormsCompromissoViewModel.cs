﻿using e_Agenda.Dominio.ModuloCompromisso;

namespace e_Agenda.WebApp.ViewModels.ModuloCompromisso
{
    public class FormsCompromissoViewModel
    {
        public string Assunto { get; set; }
        public string Local { get; set; }
        public TipoLocalizacaoCompromissoEnum TipoLocal { get; set; }
        public string Link { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }

        public Guid ContatoId { get; set; }
    }
}
