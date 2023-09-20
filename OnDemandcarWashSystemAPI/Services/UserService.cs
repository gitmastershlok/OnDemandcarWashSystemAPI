using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Interfaces;


namespace OnDemandcarWashSystemAPI.Services
{
	public class UserService
	{
		IRepository<UserDetails, int> _repository;


		public UserService(IRepository<UserDetails, int> repository)
		{
			_repository = repository;
		}


		public async Task<IEnumerable<UserDetails>> GetUser()
		{
			return await _repository.GetAsync();
		}

		public async Task<UserDetails> GetUserById(int id)
		{
			return await _repository.GetIdAsync(id);
		}
		public Task<int> CreateUser(UserDetails userDetails)
		{
			return _repository.CreateAsync(userDetails);
		}
		public Task<int> UpdateUser(UserDetails userDetails)
		{
			return _repository.UpdateAsync(userDetails);
		}
		public bool UserExists(int id)
		{
			return _repository.Exists(id);
		}
		public Task<int> DeleteUser(UserDetails userDetails)
		{
			return _repository.DeleteAsync(userDetails);
		}
	}
}
