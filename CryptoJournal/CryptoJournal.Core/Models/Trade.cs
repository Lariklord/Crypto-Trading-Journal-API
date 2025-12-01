using CryptoJournal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoJournal.Core.Models
{
    internal class Trade
    {
        public int Id { get; set; }

        public string CurrencyPair { get; set; }

        public TradeDirection Direction { get; set; }

        public decimal EntryPrice { get; set; }

        public decimal ExitPrice { get; set; }

        public decimal Quantity { get; set; }

        public OrderType OrderType { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public decimal Fees { get; set; }

        public string Notes { get; set; }

        public int Laverage { get; set; }

        public decimal PnL {  get; set; }

    }
}
