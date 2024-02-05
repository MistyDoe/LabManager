using Client.DTOs;
using Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.Services;

internal class IngredientRestServices : IIngredientRestServices

{
	private readonly HttpClient _httpClient;
	private readonly string _baseAddress;
	private readonly string _url;
	private readonly JsonSerializerOptions _jsonSerializerOptions;

	public IngredientRestServices()
	{
		_httpClient = new HttpClient();
		_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5229/" : "http://localhost:5229/";
		_url = $"{_baseAddress}api";
		_jsonSerializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault

		};

	}

	public async Task<List<Ingredient>> GetAllIngredientsAsync()
	{
		List<Ingredient> ingredients = new List<Ingredient>();

		try
		{
			HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Ingredients");
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				ingredients = JsonSerializer.Deserialize<List<Ingredient>>(content, _jsonSerializerOptions);

			}
			else
			{
				Debug.WriteLine(" Non http 2xx responce");
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return ingredients;
	}
	public async Task AddIngedientAsync(Ingredient ingredient)
	{
		var ingredientToAdd = new IngredientsDTO();
		ingredientToAdd.Name = ingredient.Name;
		ingredientToAdd.Type = ingredient.Type;
		ingredientToAdd.MeasurementType = ingredient.MeasurementType;
		ingredientToAdd.Quantity = ingredient.Quantity;
		try
		{
			string jsonPlants = JsonSerializer.Serialize<IngredientsDTO>(ingredientToAdd, _jsonSerializerOptions);
			StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
			HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Ingredients/", content);

			if (response.IsSuccessStatusCode)
			{
				Debug.Write("Successfully created plant");
			}
			else
			{
				Debug.WriteLine("Non Http 2xx response");
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return;
	}
	public async Task UpdateIngedientAsync(Ingredient ingredient)
	{


		try
		{
			string jsonIngredients = JsonSerializer.Serialize<Ingredient>(ingredient, _jsonSerializerOptions);
			StringContent content = new StringContent(jsonIngredients, Encoding.UTF8, "application/Json");
			HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Ingredients/{ingredient.Id}", content);

			if (response.IsSuccessStatusCode)
			{
				Debug.Write("Successfully created plant");
			}
			else
			{
				Debug.WriteLine("Non Http 2xx response");
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}

	public async Task RemoveIngredientAsyc(int id)
	{
		try
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Ingredients/{id}");
			if (response.IsSuccessStatusCode)
			{
				Debug.Write("Successfully created plant");
			}
			else
			{
				Debug.WriteLine("Non Http 2xx response");
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
	}
}
