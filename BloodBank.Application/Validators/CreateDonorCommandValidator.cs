using BloodBank.Application.Commands.DonorComands.CreateDonor;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateDonorCommandValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorCommandValidator()
        {
            RuleFor(d => d.FullName)
                   .NotEmpty()
                        .WithMessage("O nome deve ser informado")
                   .Length(5, 50)
                        .WithMessage("O nome deve ter entre 5 de 50 caracteres");

            RuleFor(d => d.Email)
                .NotEmpty()
                    .WithMessage("O e-mail deve ser informado")
                .EmailAddress()
                    .WithMessage("Deve ser informado um endereço de e-mail válido");

            RuleFor(d => d.Weight)
                .GreaterThanOrEqualTo(50)
                    .WithMessage("É necessário ter no minímo 50kg para ser um doador");

            RuleFor(d => d.BloodType)
                .IsInEnum()
                    .WithMessage("Valor inválido para prioridade");

            RuleFor(d => d.RhFactor)
                   .IsInEnum()
                        .WithMessage("Valor inválido para prioridade");



        }
    }
}
