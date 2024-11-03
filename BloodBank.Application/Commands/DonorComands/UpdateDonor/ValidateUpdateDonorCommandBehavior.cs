using BloodBank.Application.Commands.DonorComands.CreateDonor;
using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.UpdateDonor
{
    public class ValidateUpdateDonorCommandBehavior : IPipelineBehavior<UpdateDonorCommand, ResultViewModel>
    {
        private readonly BloodBankDbContext _context;

        public ValidateUpdateDonorCommandBehavior(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var donor = _context.Donors.Any(d => d.Id != request.Id && d.Email == request.Email);

            if (donor)
                return ResultViewModel<int>.Error("E-mail já cadastrado.");

            return await next();
        }
    }
}
