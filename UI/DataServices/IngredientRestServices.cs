using System.Text.Json;
using UI.Models;

namespace UI.DataServices
{
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
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		}

		public async Task AddIngedientAsync(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Plant>> GetAllIngredientsAsync()
		{


			throw new NotImplementedException();
		}


		public async Task UpdateIngedientAsync(Plant plant)
		{
			throw new NotImplementedException();

		}
	}
}
