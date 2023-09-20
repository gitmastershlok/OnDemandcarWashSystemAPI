using Microsoft.EntityFrameworkCore;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class UserRepository : IRepository<UserDetails, int>
	{
		CarWashContext context;
		public UserRepository(CarWashContext context) => this.context = context;
		public async Task<int> CreateAsync(UserDetails userDetails)
		{

			context.Users.Add(userDetails);
			await context.SaveChangesAsync();
			var response = StatusCodes.Status201Created;
			return response;

		}

		public async Task<int> DeleteAsync(UserDetails userDetails)
		{
			context.Users.Remove(userDetails);
			await context.SaveChangesAsync();
			var response = StatusCodes.Status200OK;
			return response;
		}

		public bool Exists(int id)
		{
			return (context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
		}

		public async Task<IEnumerable<UserDetails>> GetAsync()
		{
			return await context.Users.AsNoTracking().ToListAsync();
		}

		public async Task<UserDetails> GetIdAsync(int id) => 
			await context.Users.AsNoTracking().FirstOrDefaultAsync(c => c.UserId == id);

		public async Task<int> UpdateAsync(UserDetails item)
		{
			context.Entry(item).State = EntityState.Modified;
			await context.SaveChangesAsync();
			var response = StatusCodes.Status200OK;
			return response;
		}
	}
}
