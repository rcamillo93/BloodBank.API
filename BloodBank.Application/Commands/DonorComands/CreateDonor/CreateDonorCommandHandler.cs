using BloodBank.Application.Models;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.FullName, request.Email, request.DateBirth, request.Gender, request.Weight,
                                request.BloodType, request.RhFactor);    
                 
            await _donorRepository.AddAsync(donor);
            await _donorRepository.SaveChangesAsync();
                        
            var address = new Address(request.Address.PublicPlace, request.Address.CityId, request.Address.Cep,
                                      request.Address.Neighborhood, donor.Id);

            await _donorRepository.AddAddressAsync(address);

            return ResultViewModel<int>.Sucess(donor.Id);

        }
    }
}
