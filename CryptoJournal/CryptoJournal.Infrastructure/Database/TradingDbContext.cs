using CryptoJournal.Core.Models;
using CryptoJournal.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CryptoJournal.Infrastructure.Database
{
    public class TradingDbContext : DbContext
    {
        public DbSet<Trader> Traders { get; set; }

        public DbSet<Trade> Trades { get; set; }

        public TradingDbContext (DbContextOptions<TradingDbContext> options)
            : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TradeConfiguration());
            modelBuilder.ApplyConfiguration(new  TraderConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
