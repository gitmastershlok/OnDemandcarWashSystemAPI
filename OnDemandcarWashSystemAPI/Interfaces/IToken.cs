using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Interfaces
{
	public interface IToken
	{
		public string CreateToken(Login login);
	}
}
