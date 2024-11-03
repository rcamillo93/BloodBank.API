using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStock
{
    public class GetAllBloodStockQuery : IRequest<ResultViewModel<List<BloodStockViewModel>>>
    {
    }
}
