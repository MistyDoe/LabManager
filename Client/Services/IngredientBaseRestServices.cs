﻿using Client.Models;
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
		async Task<string> IIngredientBaseRestServices.AddIngedientBaseAsync(IngredientBase ingredientBase)
		{
			string json = "";
			try
			{
				string jsonPlants = JsonSerializer.Serialize<IngredientBase>(ingredientBase, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Ingredients/", content);

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

		async Task<List<IngredientBase>> IIngredientBaseRestServices.GetAllIngredientsBaseAsync()
		{
			List<IngredientBase> ingredientsBase = new List<IngredientBase>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/IngredientsBase");
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

		async Task IIngredientBaseRestServices.RemoveIngredientBaseAsyc(int id)
		{
			try
			{
				HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/IngredientsBase/{id}");
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

		async Task IIngredientBaseRestServices.UpdateIngedientBaseAsync(IngredientBase ingredientBase)
		{
			try
			{
				string jsonIngredients = JsonSerializer.Serialize<IngredientBase>(ingredientBase, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonIngredients, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/IngredientsBase/{ingredientBase.Id}", content);

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