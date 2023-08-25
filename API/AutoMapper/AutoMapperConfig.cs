using API.DTOs;
using API.Models;
using AutoMapper;


namespace API.AutoMapper;

public class MapperConfig
{
	public static Mapper InitializeAutomapper()
	{
		var config = new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<Plant, PlantDTO>();
		});
		var mapper = new Mapper(config);
		return mapper;
	}
}