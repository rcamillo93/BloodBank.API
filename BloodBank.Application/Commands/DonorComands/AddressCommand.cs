using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DonorComands
{
    public class AddressCommand
    {
        public AddressCommand(string publicPlace, int cityId, string cep, string neighborhood)
        {
            PublicPlace = publicPlace;
            CityId = cityId;
            Cep = cep;
            Neighborhood = neighborhood;
        }

        public string PublicPlace { get; private set; }
        public int CityId { get; private set; }
        public string Cep { get; private set; }
        public string Neighborhood { get; private set; }
    }
}
