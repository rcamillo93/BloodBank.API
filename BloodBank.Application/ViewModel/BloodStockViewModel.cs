using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModel
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(BloodTypeEnum bloodType, RHFactorEnum rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodTypeEnum BloodType { get; private set; }
        public RHFactorEnum RhFactor { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
