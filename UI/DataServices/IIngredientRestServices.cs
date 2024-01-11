using UI.Models;

namespace UI.DataServices
{
	public interface IIngredientRestServices
	{
		Task<List<Ingredient>> GetAllIngredientsAsync();
		Task AddIngedientAsync(Ingredient ingredient);
		Task UpdateIngedientAsync(Ingredient ingredient);
		Task RemoveIngredientAsyc(int id);
	}
}
