﻿namespace BloodBank.Core.Entity
{
    public class Address : BaseEntity
    {
        public Address(string publicPlace, int cityId, string cep, string neighborhood, int donorId)
        {
            PublicPlace = publicPlace;         
            CityId = cityId;
            Cep = cep;
            Neighborhood = neighborhood;
            DonorId = donorId;  
        }

        public string PublicPlace { get; private set; }
        //public int Number { get; private set; }
        public int CityId { get; private set; }
        public string Cep { get; private set; }
        public string Neighborhood { get; private set; }
        public int DonorId { get; private set; }
        //public City City { get; private set; }

        public void Update(string publicPlace, int cityId, string cep)
        {
            PublicPlace = publicPlace;
            CityId =cityId;
            Cep = cep;
        }
    }
}
