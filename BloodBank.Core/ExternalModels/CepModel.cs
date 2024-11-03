namespace BloodBank.Core.ExternalModels
{
    public class CepModel
    {
        public CepModel(string? logradouro, string? cep, string? bairro, string? localidade, string? uf, string estado, int? ibge, string? complemento)
        {
            Logradouro = logradouro;
            Cep = cep;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Estado = estado;
            Ibge = ibge;
            Complemento = complemento;
        }

        public string? Logradouro { get; private set; }        
        public string? Cep { get; private set; }
        public string? Bairro { get; private set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string Estado { get; set; }
        public int? Ibge { get; set; }
        public string? Complemento { get; set; }
    }
}
