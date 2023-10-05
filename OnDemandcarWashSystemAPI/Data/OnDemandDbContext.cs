using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Data
{
	public class OnDemandDbContext : DbContext
	{
		public OnDemandDbContext(DbContextOptions dbcontextOptions) : base(dbcontextOptions)
		{
		}
		public DbSet<User> Users { set; get; }
	}
}
