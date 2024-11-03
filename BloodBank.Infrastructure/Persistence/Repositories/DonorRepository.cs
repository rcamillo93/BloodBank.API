using BloodBank.Core.DTO;
using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _dbContext;
        private readonly string _connectionString;

        public DonorRepository(BloodBankDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BloodBank");
        }

        public async Task AddAddressAsync(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
        }

        public async Task AddAsync(Donor donor)
        {
            await _dbContext.AddAsync(donor);           
        }

        public async Task<List<Donor>> GetAllAsync()
        {
            return await _dbContext.Donors
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            return await _dbContext.Donors
                    .Include(d => d.Address)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DonorDonationInfoDTO>> GetDonorLastDonationsInfoAsync(int idDonor)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT D.ID, D.FULLNAME, D.DateBirth AS BIRTHDATE," +
                            " D.GENDER, D.WEIGHT, " +
                            " DA.DONATIONDATE FROM DONORS D " +
                            " LEFT JOIN DONATIONS DA ON D.ID=DA.DONORID " +
                            $" WHERE D.ID={idDonor}" +
                            $" ORDER BY DONATIONDATE DESC";

                var donors = await sqlConnection.QueryAsync<DonorDonationInfoDTO>(sql);

                return donors.ToList();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
