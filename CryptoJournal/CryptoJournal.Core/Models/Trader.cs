namespace CryptoJournal.Core.Models
{
    public class Trader
    {
        public int Id { get; set; }

        public required string Username { get; set; }

        public required string HashPassword { get; set; }

        public DateTime RegistrationDate { get; set; }

        public List<Trade>? Trades { get; set; }

    }
}
