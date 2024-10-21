using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetAllByPeriod
{
    public class GetAllDonationsByPeriodQueryHandler : IRequestHandler<GetAllDonationsByPeriodQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsByPeriodQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationsByPeriodQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetAllByPeriod(request.InitialDate, request.FinishDate);

            var viewModel = donations
                                .Select(d => new DonationViewModel(d.Id, d.Donor.FullName, d.Donor.Gender, d.Donor.Weight,
                                        d.Donor.BloodType, d.Donor.RhFactor, d.QuantityMl, d.DonationDate))
                                .ToList();

            return ResultViewModel<List<DonationViewModel>>.Sucess(viewModel);
        }
    }
}
