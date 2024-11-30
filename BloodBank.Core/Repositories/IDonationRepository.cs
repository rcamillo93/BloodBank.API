using BloodBank.Core.Entity;
using BloodBank.Core.Models;

namespace BloodBank.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAllByPeriod(DateTime initialDate, DateTime finishDate);
        Task<List<Donation>> GetAllDonationByDonor(int idDonor);
        Task<Donation?> GetById(int id);    
        Task AddAsync(Donation donation);        
        Task SaveChangesAsync();
    }
}
