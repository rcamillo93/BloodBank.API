using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonationComands
{
    public class ValidateCreateDonationCommandBehavior : IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>
    {       
        private readonly IDonorRepository _donorRepository;
        private readonly IDonationRepository _donationRepositor;

        public ValidateCreateDonationCommandBehavior(IDonorRepository donorRepository, IDonationRepository donationRepositor)
        {
            _donorRepository = donorRepository;
            _donationRepositor = donationRepositor;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetDonorLastDonationsInfoAsync(request.DonorId);

            var dto = donor.FirstOrDefault();

            if (dto.Age < 18)
                return ResultViewModel<int>.Error("É necessário ter mínimo 18 anos para fazer uma doação ");

            if (dto.Weight < 50)
                 return ResultViewModel<int>.Error("É necessário pesar mínimo 50kg para fazer uma doação ");              
           
            int days = dto.Gender == 'M' ? 60 : 90;

            if(dto.DonationDate != null) { 

                var lastDonation = DateTime.Now.AddDays(days) < dto.DonationDate;

                if(!lastDonation)
                   return ResultViewModel<int>.Error($"É necessário ter um intervalo de no mínimo {days} " +
                         $"entre as doações. \nData da última doação: {dto.DonationDate?.ToShortDateString()}.");

            }

            var result = await next();

            return result;
        }
    }
}
