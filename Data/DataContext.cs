using DotAgroAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotAgroAPI.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Headquarter> Headquarters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable(nameof(Salary));

                entity.HasKey(e => e.Id).HasName("Salary_PK");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FirstName).HasColumnName("firstname");
                entity.Property(e => e.LastName).HasColumnName("lastname");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Mail).HasColumnName("mail");
                entity.Property(e => e.Image).HasColumnName("image");
                entity.Property(e => e.IdService).HasColumnName("id_service");
                entity.Property(e => e.IdHeadquarter).HasColumnName("id_headquarter");
                entity.HasOne(n => n.IdServiceNavigation).WithMany(o => o.Salaries)
                .HasForeignKey(k => k.IdService)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Salary_ServiceFK");
                entity.HasOne(n => n.IdHeadquarterNavigation).WithMany(o => o.Salaries)
                .HasForeignKey(k => k.IdHeadquarter)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Salary_HeadquarterFK");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable(nameof(Service));

                entity.HasKey(e => e.Id).HasName("Service_PK");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Headquarter>(entity =>
            {
                entity.ToTable(nameof(Headquarter));

                entity.HasKey(e => e.Id).HasName("Headquarter_PK");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.City).HasColumnName("city");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
