using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface IRegister<TEntity, TKey> where TEntity : class
	{
		Task<ActionResult<UserDetails>> CreateAsync(TEntity item);
		bool UserExists(TEntity item);
	}
}
