using BloodBank.Core.Entity;
using BloodBank.Core.Enums;

namespace BloodBank.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task AddAsync(BloodStock stockBlood);        
        Task<List<BloodStock>> GetAllAsync();
        Task<List<BloodStock>> GetAllByType(BloodTypeEnum bloodType);
        Task<BloodStock?> GetStockBloodBy(BloodTypeEnum bloodType, RHFactorEnum rHFactor);
        Task SaveChangesAsync();
    }
}
