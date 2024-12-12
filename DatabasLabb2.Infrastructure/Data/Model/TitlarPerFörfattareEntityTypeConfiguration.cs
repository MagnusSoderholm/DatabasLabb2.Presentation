using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class TitlarPerFörfattareEntityTypeConfiguration : IEntityTypeConfiguration<TitlarPerFörfattare>
{

    public void Configure(EntityTypeBuilder<TitlarPerFörfattare> builder)
    {
        {
            builder
                .HasNoKey()
                .ToView("TitlarPerFörfattare");

            builder.Property(e => e.Lagervärde)
                .HasMaxLength(26)
                .IsUnicode(false);
            builder.Property(e => e.Ålder)
                .HasMaxLength(25)
                .IsUnicode(false);
        });
    }
}



