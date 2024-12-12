using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DatabasLabb2.Infrastructure.Data.Model;

public class LagerSaldoEntityTypeConfiguration : IEntityTypeConfiguration<LagerSaldo>
{
    public void Configure(EntityTypeBuilder<LagerSaldo> builder)
    {
        {
            builder.HasKey(e => new { e.ButikId, e.Isbn });

            builder.ToTable("LagerSaldo");

            builder.Property(e => e.ButikId).HasColumnName("ButikID");
            builder.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISBN");

            builder.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LagerSaldo_Butik");

            builder.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LagerSaldo_ISBN");
        };
    }
}



