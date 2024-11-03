using BloodBank.Core.ExternalModels;
using BloodBank.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BloodBank.Infrastructure.ExternalApi
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public CepService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration["ViaCep"];
        }

        public async Task<CepModel> GetCepQuery(string cep)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{cep}/json");
            
            response.EnsureSuccessStatusCode();

            var cepModel = await response.Content.ReadFromJsonAsync<CepModel>();

            return cepModel;
        }
    }
}
