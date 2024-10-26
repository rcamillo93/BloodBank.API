using BloodBank.Application.Models;
using BloodBank.Core.Entity;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.CreateDonor
{
    public class CreateDonorCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonorCommand(string fullName, string email, DateTime dateBirth, char gender, 
                                double weight, BloodTypeEnum bloodType, RHFactorEnum rhFactor, AddressCommand address)
        {
            FullName = fullName;
            Email = email;
            DateBirth = dateBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;           
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateBirth { get; private set; }
        public char Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypeEnum BloodType { get; private set; }
        public RHFactorEnum RhFactor { get; private set; }
        public AddressCommand Address { get; private set; }
    }  
}
