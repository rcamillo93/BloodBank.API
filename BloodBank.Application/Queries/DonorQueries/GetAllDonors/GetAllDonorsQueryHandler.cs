using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorViewModel>>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetAllDonorsQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donorRepository.GetAllAsync();
            var donorViewModel = donors
                        .Select(d => new DonorViewModel(d.Id, d.FullName, d.Email, d.DateBirth,
                            d.Gender, d.Weight, d.BloodType, d.RhFactor))
                            .ToList();

            return ResultViewModel<List<DonorViewModel>>.Sucess(donorViewModel);
        }
    }
}
