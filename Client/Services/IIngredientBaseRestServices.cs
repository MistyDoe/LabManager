using Client.Models;

namespace Client.Services;

public interface IIngredientBaseRestServices
{
	Task<List<IngredientBase>> GetAllIngredientsBaseAsync();
	Task AddIngedientBaseAsync(IngredientBase ingredientBase);
	Task UpdateIngedientBaseAsync(IngredientBase ingredientBase);
	Task RemoveIngredientBaseAsyc(int id);
}
