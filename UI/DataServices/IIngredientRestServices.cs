using UI.Models;

namespace UI.DataServices
{
	internal interface IIngredientRestServices
	{
		Task<List<Ingredient>> GetAllIngredientsAsync();
		Task AddIngedientAsync(Ingredient ingredient);
		Task UpdateIngedientAsync(Ingredient ingredient);
	}
}
