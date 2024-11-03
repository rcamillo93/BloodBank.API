using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.CreateDonor
{
    public class ValidateCreateDonorCommandBehavior : IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly BloodBankDbContext _context;

        public ValidateCreateDonorCommandBehavior(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donor = _context.Donors.Any(d => d.Email == request.Email);

            if(donor)
                return ResultViewModel<int>.Error("E-mail já cadastrado.");

            return await next();
        }
    }
}
