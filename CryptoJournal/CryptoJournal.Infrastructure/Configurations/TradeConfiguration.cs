using CryptoJournal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoJournal.Infrastructure.Configurations
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {

            builder.HasKey(t => t.Id);

            builder.HasOne(x => x.Trader)
                .WithMany(c => c.Trades)
                .HasForeignKey(k => k.TraderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Quantity).HasPrecision(18, 8);
            builder.Property(x => x.Fees).HasPrecision(18, 8);
            builder.Property(x => x.EntryPrice).HasPrecision(18, 8);
            builder.Property(x => x.ExitPrice).HasPrecision(18, 8);

            builder.HasIndex(t => new { t.TraderId, t.EntryDate });
        }
    }
}
