﻿using Client.Models;

namespace Client.Services;

public interface IIngredientRestServices
{
	Task<List<Ingredient>> GetAllIngredientsAsync();
	Task<string> AddIngedientAsync(Ingredient ingredient);
	Task UpdateIngedientAsync(Ingredient ingredient);
	Task RemoveIngredientAsyc(int id);
}
