using Microsoft.EntityFrameworkCore;
using HC_Automapper_Issue.Domains.Models;

#nullable disable

namespace HC_Automapper_Issue.DbContext
{
    public partial class CustomerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasIndex(e => e.Guid, "UX_Address_Guid")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Unit");
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.ToTable("Employment");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employment_Position");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("Person");

                entity.Property(e => e.UnitId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Other).HasColumnType("text");

                entity.HasOne(d => d.Unit)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Unit");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.OtherField).HasColumnType("text");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.HasIndex(e => e.Guid, "UNIQUE_Unit_Guid")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
