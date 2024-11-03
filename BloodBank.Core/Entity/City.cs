namespace BloodBank.Core.Entity
{
    public class City : BaseEntity
    {
        public City(string cityName, int stateId, int codIbge)
        {
            CityName = cityName;
            StateId = stateId;
            CodIbge = codIbge;
        }

        public string CityName { get; private set; }
        public int StateId { get; private set; }
        public int CodIbge { get; set; }
        public State State { get; private set; }
        public List<Address> Addresses { get; private set; }
    }
}
