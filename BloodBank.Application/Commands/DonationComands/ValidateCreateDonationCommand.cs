using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonationComands
{
    public class ValidateCreateDonationCommand : IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>
    {       
        private readonly IDonorRepository _donorRepository;
        private readonly IDonationRepository _donationRepositor;

        public ValidateCreateDonationCommand(IDonorRepository donorRepository, IDonationRepository donationRepositor)
        {
            _donorRepository = donorRepository;
            _donationRepositor = donationRepositor;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donations = await _donationRepositor.GetAllDonationByDonor(request.DonorId);

            if (donations.FirstOrDefault().Donor.Weight < 50)
                return ResultViewModel<int>.Error("É necessário pesar mínimo 50kg para fazer uma doação ");
                       
            if (donations.Any())
            {
                int days = donations.FirstOrDefault().Donor.Gender == 'M' ? 60 : 90;

                var lastDonation = DateTime.Now.AddDays(days) < donations.FirstOrDefault().DonationDate;

                if(!lastDonation)
                    return ResultViewModel<int>.Error($"É necessário ter um intervalo de no minímo {days} " +
                        $"entre as doações. \nData da última doação: {donations.FirstOrDefault().DonationDate.ToShortDateString()}.");
            }

            var result = await next();

            return result;
        }
    }
}
