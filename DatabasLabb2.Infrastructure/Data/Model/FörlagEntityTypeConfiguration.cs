using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class FörlagEntityTypeConfiguration : IEntityTypeConfiguration<Förlag>
{
    public void Configure(EntityTypeBuilder<Förlag> builder)
    {
        {
            builder.HasKey(e => e.FörlagsId).HasName("PK__Förlag__8CF7C87112B01366");

            builder.ToTable("Förlag");

            builder.Property(e => e.FörlagsId).HasColumnName("FörlagsID");
            builder.Property(e => e.Postnummer).HasMaxLength(50);
            builder.Property(e => e.Stad).HasMaxLength(50);
            builder.Property(e => e.Telefonnummer).HasMaxLength(50);
        });
    }
}



