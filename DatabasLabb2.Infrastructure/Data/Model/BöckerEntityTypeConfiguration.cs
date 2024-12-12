using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class BöckerEntityTypeConfiguration : IEntityTypeConfiguration<Böcker>
{
    public void Configure(EntityTypeBuilder<Böcker> builder)
    {
        {
            builder.HasKey(e => e.Isbn13);

            builder.ToTable("Böcker");

            builder.Property(e => e.Isbn13)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISBN13");
            builder.Property(e => e.Format).HasMaxLength(50);
            builder.Property(e => e.FörfattareId).HasColumnName("FörfattareID");
            builder.Property(e => e.FörlagsId).HasColumnName("FörlagsID");
            builder.Property(e => e.Genre).HasMaxLength(50);
            builder.Property(e => e.LeverantörsId).HasColumnName("LeverantörsID");
            builder.Property(e => e.Pris).HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.Författare).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattareId)
                .HasConstraintName("fk_författare");

            builder.HasOne(d => d.Förlags).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörlagsId)
                .HasConstraintName("FK_Böcker_Förlag");

            builder.HasOne(d => d.Leverantörs).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.LeverantörsId)
                .HasConstraintName("FK_Böcker_Leverantörer");
        };
    }
}



