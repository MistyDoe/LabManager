using Client.Models;

namespace Client.Services;

public interface IPlantRestDataServices
{
	Task<List<Plant>> GetAllPlantsAsync();
	Task AddPlantAsync(Plant plant);
	Task RemovePlantAsync(int id);
	Task UpdatePlantAsync(Plant plant);
}

