using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnDemandcarWashSystemAPI.Models
{
	public class UserDetails
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		public string? UserName { get; set; } = null!;
		public string? UserPhnumber { get; set; } = null!;
		public string? UserEmail { get; set; } = null!;
		public string? UserPassword { get; set; } = null!;
		public byte[]? UserPasswordHash { get; set; }
		public byte[] UserPasswordSalt { get; set; } = null!;
		public string? UserStatus { get; set; } = null;
		public string? Role { get; set; }
	}
}
