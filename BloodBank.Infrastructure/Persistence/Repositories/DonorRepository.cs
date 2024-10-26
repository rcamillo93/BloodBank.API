using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _dbContext;

        public DonorRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
