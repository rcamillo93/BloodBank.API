using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.DonationQueries.GetById
{
    public class GetDonationByIdQuery : IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetDonationByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
