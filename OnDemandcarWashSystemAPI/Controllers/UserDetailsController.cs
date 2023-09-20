using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Services;

namespace OnDemandcarWashSystemAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserDetailsController : ControllerBase
	{
		private readonly UserService _Service;
		private readonly IMapper mapper;
		private readonly RegisterService _RegisterService;

		public UserDetailsController(IMapper mapper, UserService service, RegisterService registerService)
		{
			_Service = service;
			_RegisterService = registerService;
			this.mapper = mapper;
		}


		#region GetUserProfile
		/// <summary>
		/// this action is used to get all the users
		/// </summary>
		/// <returns></returns>
		// GET: api/UserProfiles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetails()
		{
			try
			{

				var users = await _Service.GetUser();
				return Ok(users);
			}
			catch (Exception)
			{
				throw;
			}

			finally
			{

			}


		}
		#endregion

		#region GetUserProfileById
		/// <summary>
		/// this action is used to get users by Id
		/// </summary>
		/// <returns></returns>

		// GET: api/UserProfiles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
		{
			try
			{

				var userProfile = await _Service.GetUserById(id);

				if (userProfile == null)
				{
					return NotFound();
				}
				return userProfile;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}
		}
		#endregion

		#region UpdateUserProfile
		/// <summary>
		/// this action is used to update user profile
		/// </summary>
		/// <returns></returns>

		// PUT: api/UserProfiles/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUserProfile(int id, UserDetails details)
		{
			try
			{
				if (id != details.UserId)
				{
					return BadRequest();

				}
				var userDetails = await _Service.GetUserById(id);
				if (userDetails == null)
				{
					return NotFound();
				}
				if (_Service == null)
				{
					return Problem("Entity set 'CarWashContext.UserDetails'  is null.");
				}

				var val = _Service.UpdateUser(userDetails);
				if (val == null)
				{
					return BadRequest();
				}
				return NoContent();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}
		}
		#endregion

		#region RegisterUserProfile
		/// <summary>
		/// this action is used to post the User
		/// </summary>
		/// <returns></returns>

		// POST: api/UserProfiles
		[HttpPost]
		public async Task<ActionResult<UserDetails>> PostUserProfile(CreateUserDto profileDto)
		{
			try
			{
				if (UserProfileExists(profileDto))
				{
					return BadRequest("User Already Exists");

				}

				if (_Service == null)
				{
					return Problem("Entity set 'CarWashContext.UserProfiles'  is null.");
				}
				var res = await _RegisterService.RegisterUser(profileDto);
				if (res == null)
				{
					return BadRequest();
				}

				return Ok(res);
			}
			catch (Exception)
			{
				throw;
			}
			finally { }
		}
		#endregion

		#region DeleteUser
		/// <summary>
		/// this action is used to deleta a user,
		/// </summary>
		/// <returns></returns>

		// DELETE: api/UserProfiles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserProfile(int id)
		{
			try
			{
				if (_Service == null)
				{
					return NotFound();
				}
				var userDetails = await _Service.GetUserById(id);
				if (userDetails == null)
				{
					return NotFound();
				}

				var result = _Service.DeleteUser(userDetails);
				if (result == null)
				{
					return BadRequest();
				}
				return Ok(result);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}
		}
		#endregion

		#region UserExists
		/// <summary>
		/// this action is used to check if the user exists
		/// </summary>
		/// <returns></returns>

		private bool UserProfileExists(CreateUserDto email)
		{
			try
			{
				return _RegisterService.UserExisits(email);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{

			}
		}
		#endregion
	}
}
