using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetDonorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
