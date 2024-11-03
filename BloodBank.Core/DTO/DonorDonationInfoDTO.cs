using BloodBank.Core.Helpers;

namespace BloodBank.Core.DTO
{
    public class DonorDonationInfoDTO
    {
        public DonorDonationInfoDTO(int donorId, string fullName, DateTime birthDate,
                            char gender, double weight, DateTime? donationDate)
        {
            DonorId = donorId;
            FullName = fullName;   
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            DonationDate = donationDate;
        }

        public int DonorId { get; set; }
        public string FullName { get; set; }
        public int Age => BirthDate.GetCurrentAge(); // Usando o método de extensão aqui
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public double Weight { get; set; }
        public DateTime? DonationDate { get; set; }

        public DonorDonationInfoDTO()
        {                
        }
    }
}
