using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace OnDemandcarWashSystemAPI.Repositorry
{
	public class RegisterRepository : IRegister<CreateUserDto, UserDetails>
	{
		CarWashContext context;
		public RegisterRepository(CarWashContext context) => this.context = context;

		#region RegisterUser
		/// <summary>
		/// this method is used to register User
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ActionResult<UserDetails>> CreateAsync(CreateUserDto userProfileDto)
		{
			try
			{

				using var hmac = new HMACSHA512();
				var user = new UserDetails
				{
					UserName = userProfileDto.UserName,
					UserEmail = userProfileDto.UserEmail,
					UserPhnumber = userProfileDto.UserPhnumber,
					Role = userProfileDto.Role,
					UserStatus = userProfileDto.UserStatus,
					UserPassword = userProfileDto.UserPassword,
					UserPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userProfileDto.UserPassword)),
					UserPasswordSalt = hmac.Key
				};

				context.Users.Add(user);
				await context.SaveChangesAsync();
				return user;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}

		}

		public bool UserExists(CreateUserDto item)
		{
			return (context.Users?.Any(e => e.UserEmail == item.UserEmail)).GetValueOrDefault();
		}
		#endregion
	}
}
