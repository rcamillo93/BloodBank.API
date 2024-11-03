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
            var donor = await _donorRepository.GetDonorLastDonationsInfoAsync(request.DonorId);

            if (donor.FirstOrDefault().Age < 18)
                return ResultViewModel<int>.Error("É necessário ter mínimo 18 anos para fazer uma doação ");

            if (donor.FirstOrDefault().Weight < 50)
                 return ResultViewModel<int>.Error("É necessário pesar mínimo 50kg para fazer uma doação ");              
           
            int days = donor.FirstOrDefault().Gender == 'M' ? 60 : 90;

            if(donor.FirstOrDefault().DonationDate != null) { 

                var lastDonation = DateTime.Now.AddDays(days) < donor.FirstOrDefault().DonationDate;

                if(!lastDonation)
                   return ResultViewModel<int>.Error($"É necessário ter um intervalo de no minímo {days} " +
                         $"entre as doações. \nData da última doação: {donor.FirstOrDefault().DonationDate?.ToShortDateString()}.");

            }

            var result = await next();

            return result;
        }
    }
}
