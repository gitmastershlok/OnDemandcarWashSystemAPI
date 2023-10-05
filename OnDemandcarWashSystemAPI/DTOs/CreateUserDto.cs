﻿using System.ComponentModel.DataAnnotations;

namespace OnDemandcarWashSystemAPI.DTOs
{
	public class CreateUserdto
	{
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? Address { get; set; }
		public string? Role { get; set; }
	}
}
