namespace BloodBank.Core.Entity
{
    public class Address : BaseEntity
    {
        public Address(string publicPlace, int cityId, string cep, int donorId)
        {
            PublicPlace = publicPlace;
            CityId = cityId;
            Cep = cep;
            DonorId = donorId;
        }

        public string PublicPlace { get; private set; }
        public int CityId { get; private set; }
        public string Cep { get; private set; }
        public int DonorId { get; private set; }
        public Donor Donor { get; private set; }
        public City City { get; private set; }

    }
}
