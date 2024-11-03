using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Services;
using MediatR;

namespace BloodBank.Application.Queries.AddressQueries
{
    public class GetAddressByCepQueryHandler : IRequestHandler<GetAddressByCepQuery, ResultViewModel<AddressViewModel>>
    {
        private readonly ICepService _cepService;

        public GetAddressByCepQueryHandler(ICepService cepService)
        {
            _cepService = cepService;
        }

        public async Task<ResultViewModel<AddressViewModel>> Handle(GetAddressByCepQuery request, CancellationToken cancellationToken)
        {
            var address = await _cepService.GetCepQuery(request.Cep);

            if (string.IsNullOrEmpty(address.Cep))
                return ResultViewModel<AddressViewModel>.Error("CEP não encontrado.");

            var viewModel = new AddressViewModel(address.Logradouro, 0, address.Cep, address.Bairro,
                                    address.Localidade, address.Bairro, address.Ibge);                          
          
            return ResultViewModel<AddressViewModel>.Sucess(viewModel);
        }
    }
}
