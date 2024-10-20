using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor == null)
                return ResultViewModel<DonorViewModel>.Error("Doador não encontrado");

            var donorViewModel = new DonorViewModel(donor.Id, donor.FullName, donor.Email, donor.DateBirth,
                                                    donor.Gender, donor.Weight, donor.BloodType, donor.RhFactor);

            return ResultViewModel<DonorViewModel>.Sucess(donorViewModel);
        }
    }
}
