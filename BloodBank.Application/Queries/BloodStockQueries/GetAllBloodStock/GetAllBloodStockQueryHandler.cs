using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStock
{
    public class GetAllBloodStockQueryHandler : IRequestHandler<GetAllBloodStockQuery, ResultViewModel<List<BloodStockViewModel>>>
    {
        private readonly IBloodStockRepository _stockRepository;

        public GetAllBloodStockQueryHandler(IBloodStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
        {
            var stockBlood = await _stockRepository.GetAllAsync();

            var viewModel = stockBlood.Select(sb => 
                            new BloodStockViewModel(sb.BloodType, sb.RhFactor, sb.QuantityMl)).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Sucess(viewModel);
        }
    }
}
