using BloodBank.Application.Models;
using BloodBank.Core.Entity;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<ResultViewModel>
    {
        public UpdateDonorCommand(int id, string fullName, string email, double weight, 
                                  BloodTypeEnum bloodType, RHFactorEnum rhFactor, Address address)
        {
            Id = id;
            FullName = fullName;
            Email = email;        
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }        
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public RHFactorEnum RhFactor { get; private set; }
        public Address Address { get; private set; }
    }
}
