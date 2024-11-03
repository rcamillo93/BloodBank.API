using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using BloodBank.Core.Repositories;
using BloodBank.Core.Services;
using MediatR;

namespace BloodBank.Application.Queries.AddressQueries
{
    public class GetAddressByCepQueryHandler : IRequestHandler<GetAddressByCepQuery, ResultViewModel<AddressViewModel>>
    {
        private readonly ICepService _cepService;
        private readonly ICityRepository _cityRepository;

        public GetAddressByCepQueryHandler(ICepService cepService, ICityRepository cityRepository)
        {
            _cepService = cepService;
            _cityRepository = cityRepository;
        }

        public async Task<ResultViewModel<AddressViewModel>> Handle(GetAddressByCepQuery request, CancellationToken cancellationToken)
        {
            var address = await _cepService.GetCepQuery(request.Cep);                      

            if (string.IsNullOrEmpty(address.Cep))
                return ResultViewModel<AddressViewModel>.Error("CEP não encontrado.");

            var cityId = await _cityRepository.GetByCodIbgeAsync(address.Ibge);

            var viewModel = new AddressViewModel(address.Logradouro, cityId, address.Cep, address.Bairro,
                                    address.Localidade, address.Bairro, address.Ibge);                          
          
            return ResultViewModel<AddressViewModel>.Sucess(viewModel);
        }
    }
}
