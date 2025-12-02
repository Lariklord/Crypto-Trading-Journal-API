using CryptoJournal.Core.Interfaces.Repositories;
using CryptoJournal.Core.Models;
using CryptoJournal.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CryptoJournal.Infrastructure.Repositories
{
    public class TraderRepository : ITraderRepository
    {
        readonly TradingDbContext _context;

        public TraderRepository(TradingDbContext tradingDbContext) {
            _context = tradingDbContext;
        }
        public async Task<Trader> AddAsync(Trader trader)
        {
            trader.RegistrationDate = DateTime.UtcNow;

            await  _context.Traders.AddAsync(trader);

            await _context.SaveChangesAsync();

            return trader;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if(user == null)
                return false;

            _context.Traders.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _context.Traders.AnyAsync(x => x.Username == username);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Traders.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Trader>> GetAllAsync()
        {
            return await _context.Traders.ToListAsync();
        }

        public async Task<Trader> GetByIdAsync(int id)
        {
            return await _context.Traders.FirstAsync(x => x.Id == id);
        }

        public async Task<Trader> UpdateAsync(int id, Trader trader)
        {
            if (trader == null)
                throw new ArgumentNullException(nameof(trader));
            _context.Traders.Update(trader);
            await _context.SaveChangesAsync();

            return trader;
        }
    }
}
