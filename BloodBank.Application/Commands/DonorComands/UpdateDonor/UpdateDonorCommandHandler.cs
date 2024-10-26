using BloodBank.Application.Models;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonorComands.UpdateDonor
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _donorRepository;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);

            if (donor == null)
                return ResultViewModel.Error("Doador não encontrado");

            donor.Update(request.FullName, request.Email, request.Weight, request.Address);
            await _donorRepository.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
