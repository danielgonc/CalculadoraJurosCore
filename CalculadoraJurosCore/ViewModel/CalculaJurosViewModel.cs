using FluentValidation;

namespace CalculadoraJurosCore.ViewModel
{
    public class CalculaJurosViewModel
    {
        public decimal valorInicial { get; set; }
        public int meses { get; set; }
    }

    public class CalculaJurosViewModelValidator : AbstractValidator<CalculaJurosViewModel>
    {
        public CalculaJurosViewModelValidator()
        {
            RuleFor(c => c.valorInicial)
                .NotNull().WithMessage("valorInicial deve ser informado.")
                .GreaterThan(0).WithMessage("valorInicial deve ser maior que 0.");

            RuleFor(c => c.meses)
                .NotNull().WithMessage("meses deve ser informado.")
                .GreaterThan(0).WithMessage("meses deve ser maior que 0.");
        }
    }
}
