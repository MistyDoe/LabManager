using System.Diagnostics;
using System.Text.Json;
using UI.Models;

namespace UI.DataServices
{
	internal class PantTestDataServices : IPlantRestDataServices
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseAddress;
		private readonly string _url;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public PantTestDataServices()
		{
			_httpClient = new HttpClient();
			_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5229" : "http://localhost:5229/";
			_url = $"{_baseAddress}/api";
			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		}

		public Task AddTodoAsyn(Plant plant)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Plant>> GetAllPlanbtsAsync()
		{
			List<Plant> plants = new List<Plant>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/LabManager");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					plants = JsonSerializer.Deserialize<List<Plant>>(content, _jsonSerializerOptions);
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
			return plants;
		}

		public Task RemoveTodoAsyn(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdatePlantAsync(Plant plant)
		{
			throw new NotImplementedException();
		}
	}
}
