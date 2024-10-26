
using BloodBank.Application.Commands.DonationComands;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateDonationCommandValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationCommandValidator()
        {
            RuleFor(d => d.QuantityMl)
                .InclusiveBetween(420, 470)
                    .WithMessage("A quantidade doada deve ser entre 420ml e 470ml.");

            RuleFor(d => d.DonorId)
                   .NotEmpty()
                        .WithMessage("O doador deve ser informado");
        }
    }
}
