using BloodBank.Application.Models;
using BloodBank.Application.ViewModel;
using MediatR;

namespace BloodBank.Application.Queries.AddressQueries
{
    public class GetAddressByCepQuery : IRequest<ResultViewModel<AddressViewModel>>
    {
        public GetAddressByCepQuery(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; set; }
    }
}
