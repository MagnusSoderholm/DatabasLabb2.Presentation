using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class LeverantörerEntityTypeConfiguration : IEntityTypeConfiguration<Leverantörer>
{
    public void Configure(EntityTypeBuilder<Leverantörer> builder)
    {
        {
            builder.HasKey(e => e.LeverantörsId).HasName("PK__Leverant__B1DAE34212A174D7");

            builder.ToTable("Leverantörer");

            builder.Property(e => e.LeverantörsId).HasColumnName("LeverantörsID");
            builder.Property(e => e.Epostadress).HasMaxLength(255);
            builder.Property(e => e.Kontaktperson).HasMaxLength(255);
            builder.Property(e => e.Namn).HasMaxLength(255);
            builder.Property(e => e.Postnummer).HasMaxLength(50);
            builder.Property(e => e.Stad).HasMaxLength(50);
            builder.Property(e => e.Telefonnummer).HasMaxLength(20);
        };
    }
}



