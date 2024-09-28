using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodBank.Core.Entity
{
    public class Donor : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }       
        public int IdEndereco { get; private set; }
        public Address Address { get; private set; }
        public List<Donation> Donations { get; private set; }
    }
}
