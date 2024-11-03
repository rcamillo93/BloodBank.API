namespace BloodBank.Application.ViewModel
{
    public class AddressViewModel 
    {
        public AddressViewModel(string publicPlace, int cityId, string cep, string neighborhood,
                                string cityName, string stateName, int? ibge)
        {
            PublicPlace = publicPlace;
            CityId = cityId;
            Cep = cep;
            Neighborhood = neighborhood;
            CityName = cityName;
            StateName = stateName;
            Ibge = ibge;
        }

        public string PublicPlace { get; private set; }        
        public int CityId { get; private set; }
        public string Cep { get; private set; }
        public string Neighborhood { get; private set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int? Ibge { get; set; }
    }
}
