using AutoMapper;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Models;

namespace OnDemandcarWashSystemAPI.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<CreateUserDto, UserDetails>().ReverseMap();
		}
	}
}
