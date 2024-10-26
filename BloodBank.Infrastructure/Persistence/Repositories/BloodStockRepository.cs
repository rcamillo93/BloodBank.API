using BloodBank.Core.Entity;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankDbContext _dbContext;

        public BloodStockRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(BloodStock stockBlood)
        {
            await _dbContext.AddAsync(stockBlood);
        }

        public async Task<List<BloodStock>> GetAllAsync()
        {
            return await _dbContext.BloodStock.ToListAsync();
        }

        public async Task<BloodStock> GetAllByType(BloodTypeEnum bloodType)
        {
            return await _dbContext.BloodStock
                                .SingleOrDefaultAsync(sb => sb.BloodType == bloodType);             
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
