
using CryptoJournal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoJournal.Infrastructure.Configurations
{
    public class TraderConfiguration : IEntityTypeConfiguration<Trader>
    {
        public void Configure(EntityTypeBuilder<Trader> builder)
        {

            builder.HasKey(t => t.Id);

            builder.HasAlternateKey(k => k.Username);
            builder.Property(k => k.Username).HasMaxLength(20);



        }
    }
}
