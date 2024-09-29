namespace BloodBank.Core.Entity
{
    public class Donation : BaseEntity
    {
        public Donation(int donorId, int quantityMl)
        {
            DonorId = donorId;
            QuantityMl = quantityMl;
            DonationDate = DateTime.Now;
        }

        public int DonorId { get; private set; }        
        public int QuantityMl { get; private set; }
        public DateTime DonationDate { get; private set; }
        public Donor Donor { get; private set; }
        
    }
}
