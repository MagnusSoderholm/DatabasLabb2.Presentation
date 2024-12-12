using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class BuikerEntityTypeConfiguration : IEntityTypeConfiguration<Butiker>
{
    public void Configure(EntityTypeBuilder<Butiker> builder)
    {
        {
            builder.ToTable("Butiker");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            builder.Property(e => e.Namn).HasMaxLength(50);
            builder.Property(e => e.Postnummer).HasMaxLength(6);
            builder.Property(e => e.Stad).HasMaxLength(50);
        };
    }
}



