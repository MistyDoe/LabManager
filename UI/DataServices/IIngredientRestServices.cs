using UI.Models;

namespace UI.DataServices
{
	internal interface IIngredientRestServices
	{
		Task<List<Ingredient>> GetAllIngredientsAsync();
		Task AddIngredientAsync(Ingredient ingredient);

		Task UpdateIngredientAsync(Ingredient ingredient);
	}
}
