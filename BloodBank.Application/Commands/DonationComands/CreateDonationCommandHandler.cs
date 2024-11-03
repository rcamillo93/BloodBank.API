using BloodBank.Application.Models;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationComands
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;        
        private readonly IBloodStockRepository _stockRepository;
        private readonly IDonorRepository _donorRepository;

        public CreateDonationCommandHandler(IDonationRepository donationRepository, IBloodStockRepository stockRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _stockRepository = stockRepository;
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.DonorId, request.QuantityMl);

            await _donationRepository.AddAsync(donation);
            await _donationRepository.SaveChangesAsync();

            var donor = await _donorRepository.GetByIdAsync(request.DonorId);

            var stock = await _stockRepository.GetStockBloodBy(donor.BloodType, donor.RhFactor);

            if(stock is null)
            {
                var bloodStock = new BloodStock(donor.BloodType, donor.RhFactor, donation.QuantityMl);
                await _stockRepository.AddAsync(bloodStock);                
            }
            else
            {
                stock.InputBloodStock(request.QuantityMl);               
            }

            await _stockRepository.SaveChangesAsync();
            return ResultViewModel<int>.Sucess(donation.Id);
            
        }
    }
}
