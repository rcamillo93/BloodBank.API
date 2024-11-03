using BloodBank.Core.Enums;

namespace BloodBank.Core.Entity
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodTypeEnum bloodType, RHFactorEnum rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodTypeEnum BloodType { get; private set; }
        public RHFactorEnum RhFactor { get; private set; }
        public int QuantityMl { get; private set; }

        public void InputBloodStock(int quantity)
        {
            QuantityMl += quantity;
        }

        public void OutputBloodStock(int quantity)
        {
            QuantityMl -= quantity;
        }
    }
}
