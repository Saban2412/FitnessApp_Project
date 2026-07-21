using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
namespace FitnessApp.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Trener> Treneri {get;set;} = null!;//
    public DbSet<Klijent> Klijenti {get;set;} = null!;//
    public DbSet<Trening> Treninzi {get;set;} = null!;//
    public DbSet<Vjezba> Vjezbe {get;set;} = null!;//
    public DbSet<Sablon> Sabloni {get;set;} = null!;//
    public DbSet<KlijentTrening> KlijentTreninzi {get;set;} = null!;
    public DbSet<Misic> Misici {get;set;} = null!;
    public DbSet<ProgressRecord> ProgressRecords {get;set;} = null!;
    public DbSet<SablonStavka> SablonStavke {get;set;} = null!;
    public DbSet<VjezbaDodjela> VjezbaDodjele {get;set;} = null!;
    public DbSet<VjezbaMisic> VjezbaMisici {get;set;} = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trener>(entity =>
        {
            entity.ToTable("Treneri");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Ime).IsRequired().HasMaxLength(50);
            entity.Property(e=>e.Prezime).IsRequired().HasMaxLength(50);
            entity.Property(e=>e.DatumRodjenja).IsRequired();
        });
        modelBuilder.Entity<Klijent>(entity =>
        {
            entity.ToTable("Klijenti");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Ime).IsRequired().HasMaxLength(50);
            entity.Property(e=>e.Prezime).IsRequired().HasMaxLength(50);
            entity.Property(e=>e.Cilj).IsRequired();

            entity.HasOne(e=>e.Trener)
            .WithMany(e=>e.Klijenti)
            .HasForeignKey(e=>e.TrenerId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Trening>(entity =>
        {
            entity.ToTable("Treninzi");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Naziv).IsRequired().HasMaxLength(100);
            entity.Property(e=>e.Opis).HasMaxLength(1000);

            entity.HasOne(e=>e.Trener)
            .WithMany(e=>e.Treninzi)
            .HasForeignKey(e=>e.TrenerId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Vjezba>(entity =>
        {
            entity.ToTable("Vjezbe");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Naziv).IsRequired().HasMaxLength(100);
            entity.Property(e=>e.Opis).HasMaxLength(1000);
            entity.Property(e=>e.Tezina).IsRequired();
            entity.Property(e=>e.Vrsta).IsRequired();
        });
        modelBuilder.Entity<Sablon>(entity =>
        {
            entity.ToTable("Sabloni");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Naziv).IsRequired().HasMaxLength(100);
            entity.Property(e=>e.Opis).HasMaxLength(1000);

            entity.HasOne(e=>e.Trener)
            .WithMany(e=>e.Sabloni)
            .HasForeignKey(e=>e.TrenerId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<KlijentTrening>(entity =>
        {
            entity.ToTable("KlijentTreninzi");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Status).IsRequired();

            entity.HasOne(e=>e.Klijent)
            .WithMany(e=>e.KlijentTreninzi)
            .HasForeignKey(e=>e.KlijentId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e=>e.Trening)
            .WithMany(e=>e.KlijentTreninzi)
            .HasForeignKey(e=>e.TreningId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Misic>(entity =>
        {
            entity.ToTable("Misici");
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Naziv).IsRequired().HasMaxLength(50);
            entity.Property(e=>e.Opis).HasMaxLength(500);
        });
        modelBuilder.Entity<ProgressRecord>(entity =>
        {
            entity.ToTable("ProgressRecords");
            entity.HasKey(e=>e.Id);

            entity.HasOne(e=>e.Klijent)
            .WithMany(e=>e.ProgressZapisi)
            .HasForeignKey(e=>e.KlijentId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<SablonStavka>(entity =>
        {
            entity.ToTable("SablonStavke");
            entity.HasKey(e=>e.Id);

            entity.HasOne(e=>e.Sablon)
            .WithMany(e=>e.SablonStavke)
            .HasForeignKey(e=>e.SablonId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e=>e.Vjezba)
            .WithMany(e=>e.SablonStavke)
            .HasForeignKey(e=>e.VjezbaId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<VjezbaDodjela>(entity =>
        {
            entity.ToTable("VjezbaDodjele");
            entity.HasKey(e=>e.Id);

            entity.HasOne(e=>e.Trening)
            .WithMany(e=>e.VjezbaDodjele)
            .HasForeignKey(e=>e.TreningId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e=>e.Vjezba)
            .WithMany(e=>e.VjezbaDodjele)
            .HasForeignKey(e=>e.VjezbaId)
            .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<VjezbaMisic>(entity =>
        {
            entity.HasKey(e => new { e.VjezbaId, e.MisicId });
            entity.HasOne(e=>e.Vjezba)
            .WithMany(e=>e.VjezbaMisici)
            .HasForeignKey(e=>e.VjezbaId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e=>e.Misic)
            .WithMany(e=>e.VjezbaMisici)
            .HasForeignKey(e=>e.MisicId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}