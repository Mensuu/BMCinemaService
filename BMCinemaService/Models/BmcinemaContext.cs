using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BMCinemaService.Models;

public partial class BmcinemaContext : DbContext
{
    public BmcinemaContext()
    {
    }

    public BmcinemaContext(DbContextOptions<BmcinemaContext> options)
        : base(options)
    {
    }
    public virtual DbSet<BiletAlParam> BiletAlParams { get; set; }
    public virtual DbSet<BiletAl> BiletAls { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Sean> Seans { get; set; }

    public virtual DbSet<VbiletAl> VbiletAls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\Mensu;Database=BMCinema;User Id=sa; Password=123;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BiletAlParam>(entity =>
        {
            entity.HasNoKey();

        });
        modelBuilder.Entity<BiletAl>(entity =>
        {
            entity.ToTable("BiletAl");

            entity.Property(e => e.BiletAlId).HasColumnName("BiletAlID");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Gsm)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("GSM");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeansId).HasColumnName("SeansID");
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tarih).HasColumnType("date");

            entity.HasOne(d => d.Film).WithMany(p => p.BiletAls)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BiletAl_Film");

            entity.HasOne(d => d.Seans).WithMany(p => p.BiletAls)
                .HasForeignKey(d => d.SeansId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BiletAl_Seans");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("PK_Filmler");

            entity.ToTable("Film");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Film1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Film");
        });

        modelBuilder.Entity<Sean>(entity =>
        {
            entity.HasKey(e => e.SeansId);

            entity.Property(e => e.SeansId).HasColumnName("SeansID");
        });

        modelBuilder.Entity<VbiletAl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VBiletAl");

            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BiletAlId).HasColumnName("BiletAlID");
            entity.Property(e => e.Film)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tarih).HasColumnType("date");
            entity.Property(e => e.Telefon).HasColumnType("numeric(10, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
