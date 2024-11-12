using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Models
{
    public class StockReportModel
    {
        public StockReportModel(BloodTypeEnum bloodType, RHFactorEnum rHFactor, int qtdDoacoes, decimal quantityMl)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            QtdDoacoes = qtdDoacoes;
            QuantityMl = quantityMl;
        }

        public StockReportModel()
        {                
        }

        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public int QtdDoacoes { get; set; }
        public decimal QuantityMl { get; set; }        
    }
}
