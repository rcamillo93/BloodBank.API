using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetById
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDonationByIdQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetById(request.Id);

            var model = new DonationViewModel(donation.Id, donation.Donor.FullName, donation.Donor.Gender, donation.Donor.Weight,
                                                donation.Donor.BloodType, donation.Donor.RhFactor, 
                                                donation.QuantityMl, donation.DonationDate);

            return new ResultViewModel<DonationViewModel>(model);
        }
    }
}
