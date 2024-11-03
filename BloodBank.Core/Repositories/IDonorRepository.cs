using BloodBank.Core.DTO;
using BloodBank.Core.Entity;

namespace BloodBank.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAllAsync();
        Task<Donor?> GetByIdAsync(int id);
        Task<List<DonorDonationInfoDTO>> GetDonorLastDonationsInfoAsync(int idDonor);
        Task AddAsync(Donor donor);
        Task AddAddressAsync(Address address);
        Task SaveChangesAsync();
    }
}
