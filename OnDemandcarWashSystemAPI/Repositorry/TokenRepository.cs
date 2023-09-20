using Microsoft.IdentityModel.Tokens;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class TokenRepository : IToken
	{
		CarWashContext _context;
		private readonly IConfiguration configuration;

		public TokenRepository(CarWashContext context, IConfiguration config)
		{
			_context = context;
			configuration = config;
		}

		public string CreateToken(Login login)
		{
			try
			{
				List<Claim> claims = new List<Claim>
				{
				 new Claim(ClaimTypes.Email, login.Email),
				new Claim(ClaimTypes.Role, login.Role)
				 };

				var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
					configuration.GetSection("AppSettings:Token").Value));

				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

				var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: creds);

				var jwt = new JwtSecurityTokenHandler().WriteToken(token);

				return jwt;
			}
			catch (Exception)
			{
				throw;
			}
			finally { }
		}
	}
}
