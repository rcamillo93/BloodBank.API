namespace BloodBank.Core.Entity
{
    public class City : BaseEntity
    {
        public City(string cityName, int stateId)
        {
            CityName = cityName;
            StateId = stateId;
        }

        public string CityName { get; private set; }
        public int StateId { get; private set; }
        public State State { get; private set; }
        public List<Address> Addresses { get; private set; }
    }
}
