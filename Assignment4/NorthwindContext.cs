using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        // You'll add other DbSets later for Products, Orders, etc.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // PostgreSQL connection string
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=postgres;Username=postgres;Password=2834");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .HasColumnName("categoryid")
                    .ValueGeneratedOnAdd(); // This tells EF that the DB generates the value

                entity.Property(c => c.Name)
                    .HasColumnName("categoryname")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .HasColumnName("productid")
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Name)
                    .HasColumnName("productname")
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.UnitPrice)
                    .HasColumnName("unitprice")
                    .HasColumnType("decimal(18,2)");

                entity.Property(p => p.UnitsInStock)
                    .HasColumnName("unitsinstock");

                entity.Property(p => p.QuantityPerUnit)
                    .HasColumnName("quantityperunit");

                // Use the explicit CategoryId property
                entity.Property(p => p.CategoryId)
                    .HasColumnName("categoryid");

                // Define foreign key relationship using the property
                entity.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)  // Use the property, not string
                    .HasConstraintName("fk_products_categories");
            });

        }
    }
}