using Client.Models;

namespace Client.Services;

public interface IIngredientRestServices
{
	Task<List<IngredientDTO>> GetAllIngredientsAsync();
	Task AddIngedientAsync(IngredientDTO ingredient);
	Task UpdateIngedientAsync(IngredientDTO ingredient);
	Task RemoveIngredientAsyc(int id);
}
