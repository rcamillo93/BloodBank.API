using BloodBank.Core.Entity;

namespace BloodBank.Core.Repositories
{
    public interface ICityRepository
    {
        Task<int> GetByCodIbgeAsync(int codIbge);
        Task<int> GetByNameAsync(string name);
    }
}
