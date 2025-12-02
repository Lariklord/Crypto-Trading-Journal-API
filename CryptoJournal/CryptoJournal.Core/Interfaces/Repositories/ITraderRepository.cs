using CryptoJournal.Core.Models;

namespace CryptoJournal.Core.Interfaces.Repositories
{
    public interface ITraderRepository
    {
        Task<Trader> GetByIdAsync(int id);
        Task<Trader> AddAsync(Trader trader);
        Task<IEnumerable<Trader>> GetAllAsync();
        Task<bool> ExistsAsync(string username);
        Task<bool> ExistsAsync(int id);
        Task<Trader> UpdateAsync(int id, Trader trader);
        Task<bool> DeleteAsync(int id);
    }
}
