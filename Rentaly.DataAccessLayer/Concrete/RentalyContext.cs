using Microsoft.EntityFrameworkCore;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.DataAccessLayer.Concrete
{
    public class RentalyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0SC4E7S\\SQLEXPRESS;Database=RentalyDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
