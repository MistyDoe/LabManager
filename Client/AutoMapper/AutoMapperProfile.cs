using AutoMapper;
using Client.DTOs;
using Client.Models;

namespace Client.AutoMapper
{
	internal class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<PlantDTO, Plant>();

		}

	}
}
