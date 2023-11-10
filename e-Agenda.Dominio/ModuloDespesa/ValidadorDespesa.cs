using FluentValidation;

namespace e_Agenda.Dominio.ModuloDespesa
{
    public class ValidadorDespesa : AbstractValidator<Despesa>, IValidadorDespesa
    {
        public ValidadorDespesa()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Valor)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Data)
                .NotNull()
                .NotEmpty();
        }
    }
}