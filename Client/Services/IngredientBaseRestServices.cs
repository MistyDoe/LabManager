using Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.Services
{
	class IngredientBaseRestServices : IIngredientBaseRestServices
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseAddress;
		private readonly string _url;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public IngredientBaseRestServices()
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
		public async Task<string> AddIngedientBaseAsync(IngredientBase ingredientBase)
		{
			string json = "";
			try
			{
				string jsonPlants = JsonSerializer.Serialize<IngredientBase>(ingredientBase, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/IngredientBses/", content);

				if (response.IsSuccessStatusCode)
				{
					json = await response.Content.ReadAsStringAsync();
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
			return json;
		}

		public async Task<List<IngredientBase>> GetAllIngredientsBaseAsync()
		{
			List<IngredientBase> ingredientsBase = new List<IngredientBase>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/IngredientBases");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					ingredientsBase = JsonSerializer.Deserialize<List<IngredientBase>>(content, _jsonSerializerOptions);

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
			return ingredientsBase;
		}

		public async Task RemoveIngredientBaseAsyc(int id)
		{
			try
			{
				HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/IngredientBases/{id}");
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

		public async Task UpdateIngedientBaseAsync(IngredientBase ingredientBase)
		{
			try
			{
				string jsonIngredients = JsonSerializer.Serialize<IngredientBase>(ingredientBase, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonIngredients, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/IngredientBases/{ingredientBase.Id}", content);

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
}
