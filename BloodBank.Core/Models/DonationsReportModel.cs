namespace BloodBank.Core.Models
{
    public class DonationsReportModel
    {
        public DonationsReportModel(string bloodType, int totalDonations, int quantityMl, double averageAge, DateTime lastDonationDate)
        {
            BloodType = bloodType;
            TotalDonations = totalDonations;
            QuantityMl = quantityMl;
            AverageAge = averageAge;
            LastDonationDate = lastDonationDate;
        }

        public string BloodType { get; set; }
        public int TotalDonations { get; set; }
        public int QuantityMl { get; set; }
        public double AverageAge { get; set; }
        public DateTime LastDonationDate { get; set; }
    }
}
