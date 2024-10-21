using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DonationComands
{
    public class CreateDonationCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonationCommand(int donorId, int quantityMl)
        {
            DonorId = donorId;
            QuantityMl = quantityMl;
        }

        public int DonorId { get; private set; }
        public int QuantityMl { get; private set; }
    }
}
