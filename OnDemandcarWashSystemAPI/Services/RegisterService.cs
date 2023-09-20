using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Interfaces;


namespace OnDemandcarWashSystemAPI.Services
{
	public class RegisterService
	{
		IRegister<CreateUserDto, UserDetails> _repository;
		public RegisterService(IRegister<CreateUserDto, UserDetails> repository)
		{
			_repository = repository;
		}

		public async Task<ActionResult<UserDetails>> RegisterUser(CreateUserDto userprofiledto)
		{
			return await _repository.CreateAsync(userprofiledto);
		}
		public bool UserExisits(CreateUserDto email)
		{
			return _repository.UserExists(email);
		}
	}
}
