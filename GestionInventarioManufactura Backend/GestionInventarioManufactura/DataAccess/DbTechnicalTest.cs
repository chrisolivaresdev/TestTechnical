using GestionInventarioManufactura.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionInventarioManufactura.DataAccess
{
    public class DbTechnicalTest : DbContext
    {
        public DbTechnicalTest(DbContextOptions<DbTechnicalTest> options): base(options)
        {
            
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Name).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
                tb.Property(col => col.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<User>().ToTable("Users");


            modelBuilder.Entity<Product>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Name).HasMaxLength(50);
                tb.Property(col => col.TypeElaboration).HasMaxLength(50);
                tb.Property(col => col.Status).HasMaxLength(50);
              
            });

            modelBuilder.Entity<Product>().ToTable("Products");

        }
    }

 }



