using Microsoft.EntityFrameworkCore;
using Tracker.Entity.Entities;

namespace Tracker.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bills> Billses { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills", "bills_tracker");
                
                entity.HasKey(b => b.Id);
                
                entity.Property(b => b.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();
                
                entity.Property(b => b.Price)
                    .HasColumnName("price")
                    .HasColumnType("float(10,2)");
                
                entity.Property(b => b.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)")
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", "bills_tracker");
                
                entity.HasKey(c => c.Id);
                
                entity.Property(c => c.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();
                
                entity.Property(c => c.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)")
                    .IsRequired();
            });
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Billses)
                .WithOne(b => b.Category)
                .HasForeignKey(c => c.CategoryId);


            base.OnModelCreating(modelBuilder);
        }
    }
}