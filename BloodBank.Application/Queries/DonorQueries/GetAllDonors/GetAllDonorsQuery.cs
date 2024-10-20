using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.DonorQueries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<ResultViewModel<List<DonorViewModel>>>
    {      

    }
}
