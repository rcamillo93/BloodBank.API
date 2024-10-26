using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetByDonor
{
    public class GetDonationByDonorQueryHandler : IRequestHandler<GetDonationByDonorQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDonationByDonorQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetDonationByDonorQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetAllDonationByDonor(request.IdDonor);

            var viewModel = donations
                                .Select(d => new DonationViewModel(d.Id, d.Donor.FullName, d.Donor.Gender, d.Donor.Weight,
                                        d.Donor.BloodType, d.Donor.RhFactor, d.QuantityMl, d.DonationDate))
                                .ToList();

            return ResultViewModel<List<DonationViewModel>>.Sucess(viewModel);
        }
    }
}
