using FluentValidation;

namespace e_Agenda.Dominio.ModuloDespesa
{
    public class ValidadorCategoria : AbstractValidator<Categoria>, IValidadorCategoria
    {
        public ValidadorCategoria()
        {
            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty();
        }
    }
}