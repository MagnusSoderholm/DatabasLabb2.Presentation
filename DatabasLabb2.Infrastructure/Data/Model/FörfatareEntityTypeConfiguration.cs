using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class FörfatareEntityTypeConfiguration : IEntityTypeConfiguration<Författare>
{
    public void Configure(EntityTypeBuilder<Författare> builder)
    {
        {
            builder.ToTable("Författare");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });
    }
}



