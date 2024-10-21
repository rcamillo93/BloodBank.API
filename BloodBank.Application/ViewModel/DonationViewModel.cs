using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModel
{
    public class DonationViewModel
    {
        public DonationViewModel(int id, string fullName, char gender, double weight, BloodTypeEnum bloodType,
                                RHFactorEnum rhFactor, int quantityMl, DateTime donationDate)
        {
            Id = id;
            FullName = fullName;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
            DonationDate = donationDate;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RhFactor { get; set; }
        public int QuantityMl { get; private set; }
        public DateTime DonationDate { get; private set; }
    }
}
