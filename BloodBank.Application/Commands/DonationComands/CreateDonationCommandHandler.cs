using BloodBank.Application.Models;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationComands
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;

        public CreateDonationCommandHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation(request.DonorId, request.QuantityMl);

            await _donationRepository.AddAsync(donation);
            await _donationRepository.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(donation.Id);
            
        }
    }
}
