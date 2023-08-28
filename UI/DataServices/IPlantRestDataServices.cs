using UI.Models;

namespace UI.DataServices
{
	public interface IPlantRestDataServices
	{
		Task<List<Plant>> GetAllPlanbtsAsync();
		Task AddTodoAsyn(Plant plant);
		Task RemoveTodoAsyn(int id);
		Task UpdatePlantAsync(Plant plant);
	}
}
