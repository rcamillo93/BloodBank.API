using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonationComands
{
    public class ValidateCreateDonationCommand : IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly BloodBankDbContext _dbContext;

        public ValidateCreateDonationCommand(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donor =  _dbContext.Donations.Any(d => d.Donor.Weight > 50);

            if (!donor)
                return ResultViewModel<int>.Error("É necessário pesar mínimo 50kg para fazer uma doação ");

            var days = _dbContext.Donations.Any(d =>
                        d.DonationDate.Date >
                             (d.Donor.Gender.Equals("M") ? DateTime.Now.AddDays(-60) : DateTime.Now.AddDays(-60)));

            var result = await next();



            return result;
        }
    }
}
