using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Data
{
	public class CarWashContext : DbContext
	{
		public CarWashContext() { }
		public CarWashContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Package> Packages { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<UserDetails> Users { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.Property(o => o.TotalCost)
				.HasColumnType("decimal(18,2)"); // Adjust the precision and scale as needed

			modelBuilder.Entity<Package>()
				.Property(p => p.Price)
				.HasColumnType("decimal(18,2)");

			// Other entity configurations...

			base.OnModelCreating(modelBuilder);
		}
	}
}
