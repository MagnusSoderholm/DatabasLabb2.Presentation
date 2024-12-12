using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DatabasLabb2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DatabasLabb2.Infrastructure.Data.Model;

public partial class BokhandelContext : DbContext
{
    public BokhandelContext()
    {
    }

    public BokhandelContext(DbContextOptions<BokhandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<Leverantörer> Leverantörers { get; set; }

    public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       var config = new ConfigurationBuilder().AddUserSecrets<BokhandelContext>().Build();
        var connectionString = config["ConnectionString"];
       optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Butiker>(entity =>
        //{
        //    entity.ToTable("Butiker");

        //    entity.Property(e => e.Id)
        //        .ValueGeneratedNever()
        //        .HasColumnName("ID");
        //    entity.Property(e => e.Namn).HasMaxLength(50);
        //    entity.Property(e => e.Postnummer).HasMaxLength(6);
        //    entity.Property(e => e.Stad).HasMaxLength(50);
        //});

        //modelBuilder.Entity<Böcker>(entity =>
        //{
        //    entity.HasKey(e => e.Isbn13);

        //    entity.ToTable("Böcker");

        //    entity.Property(e => e.Isbn13)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("ISBN13");
        //    entity.Property(e => e.Format).HasMaxLength(50);
        //    entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");
        //    entity.Property(e => e.FörlagsId).HasColumnName("FörlagsID");
        //    entity.Property(e => e.Genre).HasMaxLength(50);
        //    entity.Property(e => e.LeverantörsId).HasColumnName("LeverantörsID");
        //    entity.Property(e => e.Pris).HasColumnType("decimal(5, 2)");

        //    entity.HasOne(d => d.Författare).WithMany(p => p.Böckers)
        //        .HasForeignKey(d => d.FörfattareId)
        //        .HasConstraintName("fk_författare");

        //    entity.HasOne(d => d.Förlags).WithMany(p => p.Böckers)
        //        .HasForeignKey(d => d.FörlagsId)
        //        .HasConstraintName("FK_Böcker_Förlag");

        //    entity.HasOne(d => d.Leverantörs).WithMany(p => p.Böckers)
        //        .HasForeignKey(d => d.LeverantörsId)
        //        .HasConstraintName("FK_Böcker_Leverantörer");
        //});

        //modelBuilder.Entity<Författare>(entity =>
        //{
        //    entity.ToTable("Författare");

        //    entity.Property(e => e.Id)
        //        .ValueGeneratedNever()
        //        .HasColumnName("ID");
        //});

        //modelBuilder.Entity<Förlag>(entity =>
        //{
        //    entity.HasKey(e => e.FörlagsId).HasName("PK__Förlag__8CF7C87112B01366");

        //    entity.ToTable("Förlag");

        //    entity.Property(e => e.FörlagsId).HasColumnName("FörlagsID");
        //    entity.Property(e => e.Postnummer).HasMaxLength(50);
        //    entity.Property(e => e.Stad).HasMaxLength(50);
        //    entity.Property(e => e.Telefonnummer).HasMaxLength(50);
        //});

        //modelBuilder.Entity<LagerSaldo>(entity =>
        //{
        //    entity.HasKey(e => new { e.ButikId, e.Isbn });

        //    entity.ToTable("LagerSaldo");

        //    entity.Property(e => e.ButikId).HasColumnName("ButikID");
        //    entity.Property(e => e.Isbn)
        //        .HasMaxLength(50)
        //        .IsUnicode(false)
        //        .HasColumnName("ISBN");

        //    entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
        //        .HasForeignKey(d => d.ButikId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_LagerSaldo_Butik");

        //    entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
        //        .HasForeignKey(d => d.Isbn)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_LagerSaldo_ISBN");
        //});

        //modelBuilder.Entity<Leverantörer>(entity =>
        //{
        //    entity.HasKey(e => e.LeverantörsId).HasName("PK__Leverant__B1DAE34212A174D7");

        //    entity.ToTable("Leverantörer");

        //    entity.Property(e => e.LeverantörsId).HasColumnName("LeverantörsID");
        //    entity.Property(e => e.Epostadress).HasMaxLength(255);
        //    entity.Property(e => e.Kontaktperson).HasMaxLength(255);
        //    entity.Property(e => e.Namn).HasMaxLength(255);
        //    entity.Property(e => e.Postnummer).HasMaxLength(50);
        //    entity.Property(e => e.Stad).HasMaxLength(50);
        //    entity.Property(e => e.Telefonnummer).HasMaxLength(20);
        //});

        //modelBuilder.Entity<TitlarPerFörfattare>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToView("TitlarPerFörfattare");

        //    entity.Property(e => e.Lagervärde)
        //        .HasMaxLength(26)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Ålder)
        //        .HasMaxLength(25)
        //        .IsUnicode(false);
        //});
        
        new BuikerEntityTypeConfiguration().Configure(modelBuilder.Entity<Butiker>());
        new BöckerEntityTypeConfiguration().Configure(modelBuilder.Entity<Böcker>());
        new FörfatareEntityTypeConfiguration().Configure(modelBuilder.Entity<Författare>());
        new FörlagEntityTypeConfiguration().Configure(modelBuilder.Entity<Förlag>());
        new LagerSaldoEntityTypeConfiguration().Configure(modelBuilder.Entity<LagerSaldo>());
        new LeverantörerEntityTypeConfiguration().Configure(modelBuilder.Entity<Leverantörer>());
        new TitlarPerFörfattareEntityTypeConfiguration().Configure(modelBuilder.Entity<TitlarPerFörfattare>());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}



