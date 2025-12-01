using CryptoJournal.Core.Enums;

namespace CryptoJournal.Core.Models
{
    public class Trade
    {
        public int Id { get; set; }

        public required string CurrencyPair { get; set; }

        public TradeDirection Direction { get; set; }

        public decimal EntryPrice { get; set; }

        public decimal ExitPrice { get; set; }

        public decimal Quantity { get; set; }

        public OrderType OrderType { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public decimal Fees { get; set; }

        public string? Notes { get; set; }

        public int Laverage { get; set; }

        public decimal PnL {  get; set; }

        public required Trader Trader { get; set; }
        public int TraderId { get; set; }

    }
}
