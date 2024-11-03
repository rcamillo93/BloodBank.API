using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands
{
    public class OutputBloodStockCommandHandler : IRequestHandler<OutputBloodStockCommand, ResultViewModel<int>>
    {
        private readonly IBloodStockRepository _stockRepository;

        public OutputBloodStockCommandHandler(IBloodStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<ResultViewModel<int>> Handle(OutputBloodStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetStockBloodBy(request.BloodType, request.RHFactor);

            if (stock.QuantityMl < request.Quantity)
                return ResultViewModel<int>.Error($"Quantidade superior ao estoque disponível: {stock.QuantityMl}");

            stock.OutputBloodStock(request.Quantity);

            await _stockRepository.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(stock.Id);
        }
    }
}
