using BloodBank.Core.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodBank.Core.Entity
{
    public class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime dateBirth, char gender, double weight, 
                    BloodTypeEnum bloodType, RHFactorEnum rhFactor)
        {
            FullName = fullName;
            Email = email;
            DateBirth = dateBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateBirth { get; private set; }
        public char Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public RHFactorEnum RhFactor { get; private set; }
        public Address Address { get; private set; }
        public List<Donation> Donations { get; private set; } = new List<Donation>();
    }
}
