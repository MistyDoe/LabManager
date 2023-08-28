using UI.Models;

namespace UI.DataServices
{
	public interface IPlantRestDataServices
	{
		Task<List<Plant>> GetAllPlantsAsync();
		Task AddPlantAsync(Plant plant);
		Task RemovePlantAsync(int id);
		Task UpdatePlantAsync(Plant plant);
	}
}
