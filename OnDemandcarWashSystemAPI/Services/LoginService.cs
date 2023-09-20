using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;


namespace OnDemandcarWashSystemAPI.Services
{
	public class LoginService
	{
		ILogin<Login, int> _repository;
		public LoginService(ILogin<Login, int> repository)
		{
			_repository = repository;
		}

		public async Task<int> Login(Login login)
		{
			return await _repository.Login(login);
		}
	}
}
