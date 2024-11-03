using BloodBank.Application.Models;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands
{
    public class OutputBloodStockCommand : IRequest<ResultViewModel<int>>
    {
        public OutputBloodStockCommand(BloodTypeEnum bloodType, RHFactorEnum rHFactor, int quantity)
        {
            BloodType = bloodType;
            RHFactor = rHFactor;
            Quantity = quantity;
        }

        public BloodTypeEnum BloodType { get; set; }
        public RHFactorEnum RHFactor { get; set; }
        public int Quantity { get; set; }
    }
}
