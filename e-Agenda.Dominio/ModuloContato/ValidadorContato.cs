using FluentValidation.Validators;
using FluentValidation;
using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloContato
{
    public class ValidadorContato : AbstractValidator<Contato>, IValidadorContato
    {
        public ValidadorContato()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty();

            RuleFor(x => x.Telefone)
                .Telefone();

            RuleFor(x => x.Empresa)
                .MinimumLength(3)
                .NotNull().NotEmpty();

            RuleFor(x => x.Cargo)
                .MinimumLength(3)
                .NotNull().NotEmpty();
        }

    }
}
