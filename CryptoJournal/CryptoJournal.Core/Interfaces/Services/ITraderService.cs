using CryptoJournal.Core.DTO;
using CryptoJournal.Core.Models;

namespace CryptoJournal.Core.Interfaces.Services
{
    public interface ITraderService
    {
        Task<Trader> CreateTraderAsync(TraderRegisterDTO traderRegisterDTO);
        Task<IEnumerable<Trader>> GetAllTradersAsync();
        Task<Trader> GetTraderByIdAsync(int id);
        Task<Trader> UpdatePasswordAsync(int id, TraderUpdateDTO traderUpdateDTO);
        Task<bool> DeleteTraderAsync(int id);
    }
}
