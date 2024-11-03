using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.BloodStockQueries.GetAllByType
{
    public class GetAllBloodStockByTypeQueryHandler : IRequestHandler<GetAllBloodStockByTypeQuery, ResultViewModel<List<BloodStockViewModel>>>
    {
        private readonly IBloodStockRepository _stockRepository;

        public GetAllBloodStockByTypeQueryHandler(IBloodStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStockByTypeQuery request, CancellationToken cancellationToken)
        {
            var stockBlood = await _stockRepository.GetAllByType(request.BloodType);

            var viewModel = stockBlood.Select(sb =>
                            new BloodStockViewModel(sb.BloodType, sb.RhFactor, sb.QuantityMl)).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Sucess(viewModel);
        }
    }
}
