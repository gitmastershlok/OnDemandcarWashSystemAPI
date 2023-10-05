using AutoMapper;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<User, Userdto>();
			CreateMap<Userdto, User>();
		}
	}
}