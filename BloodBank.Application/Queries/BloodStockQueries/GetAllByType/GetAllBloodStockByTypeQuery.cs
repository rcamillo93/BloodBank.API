using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllByType
{
    public class GetAllBloodStockByTypeQuery : IRequest<ResultViewModel<List<BloodStockViewModel>>>
    {
        public GetAllBloodStockByTypeQuery(BloodTypeEnum bloodType)
        {
            BloodType = bloodType;
        }

        public BloodTypeEnum BloodType { get; set; }
    }
}
