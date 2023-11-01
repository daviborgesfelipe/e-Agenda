using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Agenda.Dominio.ModuloTarefa
{
    public class ValidadorTarefa : AbstractValidator<Tarefa>, IValidadorTarefa
    {
        public ValidadorTarefa()
        {
            RuleFor(x => x.Titulo)
                .NotNull().WithMessage("O campo título é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.DataCriacao)
                .NotEqual(DateTime.MinValue)
                .WithMessage("O campo Data de Criação é obrigatório");
        }
    }
}
