using BloodBank.Application.Commands.BloodStockCommands;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class OutputBloodStockCommandValidator : AbstractValidator<OutputBloodStockCommand>
    {
        public OutputBloodStockCommandValidator()
        {
            RuleFor(b => b.BloodType)
                    .IsInEnum()
                    .WithMessage("Valor inválido para prioridade");

            RuleFor(d => d.RHFactor)
                   .IsInEnum()
                   .WithMessage("Valor inválido para prioridade");

            RuleFor(d => d.Quantity)
                   .GreaterThanOrEqualTo(420)
                   .WithMessage("O valor mínimo para retirada é 420ml.");
        }
    }
}
