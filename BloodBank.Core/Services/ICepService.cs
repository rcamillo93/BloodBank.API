using BloodBank.Core.ExternalModels;

namespace BloodBank.Core.Services
{
    public interface ICepService
    {
        Task<CepModel> GetCepQuery(string cep);
    }
}
