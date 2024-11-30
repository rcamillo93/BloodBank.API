using BloodBank.Core.Entity;
using BloodBank.Core.Models;
using BloodBank.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _dbContext;
        private readonly string _connectionString;

        public DonationRepository(BloodBankDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BloodBank");
        }

        public async Task AddAsync(Donation donation)
        {
            await _dbContext.AddAsync(donation);
        }

        public async Task<List<Donation>> GetAllByPeriod(DateTime initialDate, DateTime finishDate)
        {
            return await _dbContext.Donations
                        .Include(d => d.Donor)
                        .Where(d => d.DonationDate.Day >= initialDate.Day && d.DonationDate.Day <= finishDate.Day)
                        .OrderBy(d => d.Donor.BloodType)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<List<Donation>> GetAllDonationByDonor(int idDonor)
        {
            return await _dbContext.Donations
                          .Include(d => d.Donor)
                          .Where(d => d.DonorId == idDonor)
                          .AsNoTracking()
                          .OrderByDescending(d => d.DonationDate)
                          .ToListAsync();
        }

        public async Task<Donation?> GetById(int id)
        {
            return await _dbContext.Donations
                .Include(d => d.Donor)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == id);
           
        }

        public async Task<List<DonationsReportModel>> GettDonationsReport(DateTime initialDate, DateTime finishDate)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT bs.BloodType, bs.RhFactor, count(da.id) as qtddoacoes, " +
                            " bs.QuantityMl FROM Donors D " +
                            " INNER JOIN Donations da ON d.id = da.DonorId " +
                            " LEFT JOIN BloodStock bs ON d.BloodType=bs.BloodType " +
                            " GROUP BY bs.BloodType, bs.RhFactor, bs.QuantityMl ";

                var stock = await sqlConnection.QueryAsync<DonationsReportModel>(sql);

                return stock.ToList();
            }

        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
