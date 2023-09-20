using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Services;
using OnDemandcarWashSystemAPI.Interfaces;

namespace OnDemandcarWashSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly LoginService _Service;
		private IToken _token;

		public LoginController(LoginService service, IToken token)
		{

			_Service = service;
			_token = token;
		}

		[HttpPost("login")]

		public async Task<ActionResult<string>> Login(Login item)
		{


			var res = await _Service.Login(item);


			if (res == 200)
			{
				string token = _token.CreateToken(item);
				return token;


			}
			else if (res == 404)
			{
				return BadRequest("You are not registered");
			}
			else if (res == 401)
			{
				return Unauthorized("Password is wrong");
			}
			else
			{
				return Unauthorized("Your account is blocked,please contact Admininstrator");
			}
		}
	}
}
