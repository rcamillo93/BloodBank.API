using BloodBank.Core.Entity;
using BloodBank.Core.Enums;
using BloodBank.Core.Models;

namespace BloodBank.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task AddAsync(BloodStock stockBlood);        
        Task<List<BloodStock>> GetAllAsync();
        Task<List<BloodStock>> GetAllByType(BloodTypeEnum bloodType);
        Task<BloodStock?> GetStockBloodBy(BloodTypeEnum bloodType, RHFactorEnum rHFactor);
        Task SaveChangesAsync();
        Task<List<StockReportModel>> GetStockReportAsync();
    }
}
