using BloodBank.Core.Entity;
using BloodBank.Core.Enums;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankDbContext _dbContext;
        private readonly string _connectionString;

        public BloodStockRepository(BloodBankDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BloodBank");
        }

        public async Task AddAsync(BloodStock stockBlood)
        {
            await _dbContext.AddAsync(stockBlood);
        }

        public async Task<List<BloodStock>> GetAllAsync()
        {
            return await _dbContext.BloodStock.ToListAsync();
        }

        public async Task<List<BloodStock>> GetAllByType(BloodTypeEnum bloodType)
        {
            return await _dbContext.BloodStock
                                .AsNoTracking()
                                .Where(sb => sb.BloodType == bloodType)
                                .ToListAsync();      
        }

        public async Task<BloodStock?> GetStockBloodBy(BloodTypeEnum bloodType, RHFactorEnum rHFactor)
        {
            return await _dbContext.BloodStock                            
                           .SingleOrDefaultAsync(b => b.BloodType == bloodType && b.RhFactor == rHFactor);
        }

        public async Task<List<StockReportModel>> GetStockReportAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT bs.BloodType, bs.RhFactor, count(da.id) as qtddoacoes, " +
                            " bs.QuantityMl FROM Donors D " +                     
                            " INNER JOIN Donations da ON d.id = da.DonorId " +
                            " LEFT JOIN BloodStock bs ON d.BloodType=bs.BloodType " +
                            " GROUP BY bs.BloodType, bs.RhFactor, bs.QuantityMl ";

                var stock = await sqlConnection.QueryAsync<StockReportModel>(sql);

                return stock.ToList();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
