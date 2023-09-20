using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace OnDemandcarWashSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly CarWashContext _context;
		public UserController(CarWashContext context)
		{
			_context = context;

		}

		[Authorize(Roles = "Admin")]
		[HttpPut("{id}")]
		public IActionResult ChangeUserStatus(int id, string UserStatus)
		{
			(from p in _context.Users
			 where p.UserId == id
			 select p).ToList()
					.ForEach(x => x.UserStatus = UserStatus);

			_context.SaveChanges();
			return Ok();
		}
	}
}
