using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<PlantDTO, Plant>();
			CreateMap<ProtocolDTO, Protocol>();
			CreateMap<MediaDTO, Media>();
		}

	}
}
