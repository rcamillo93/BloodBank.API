using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetByDonor
{
    public class GetDonationByDonorQuery : IRequest<ResultViewModel<List<DonationViewModel>>>
    {
        public GetDonationByDonorQuery(int idDonor)
        {
            IdDonor = idDonor;
        }

        public int IdDonor { get; set; }
    }
}
