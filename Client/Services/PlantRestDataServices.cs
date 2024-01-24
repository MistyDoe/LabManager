
using Client.DTOs;
using Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.Services
{
	internal class PlantRestDataServices : IPlantRestDataServices
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseAddress;
		private readonly string _url;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public PlantRestDataServices()
		{

			_httpClient = new HttpClient();
			_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5229/" : "http://localhost:5229/";
			_url = $"{_baseAddress}api";
			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		}

		public async Task AddPlantAsync(Plant plant)
		{
			try
			{
				string jsonPlants = JsonSerializer.Serialize<Plant>(plant, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Plants/", content);

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

		public async Task<List<Plant>> GetAllPlantsAsync()
		{
			List<Plant> plants = new List<Plant>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Plants");
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

		public async Task RemovePlantAsync(int id)
		{
			try
			{
				HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Plants/{id}");
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

		public async Task UpdatePlantAsync(Plant plant)
		{
			PlantDTO plantDTO = new PlantDTO();
			plantDTO.Id = plant.Id;
			plantDTO.Name = plant.Name;
			plantDTO.MotherPlantsQt = plant.MotherPlantsQt;
			plantDTO.ForSale = plant.ForSale;
			plantDTO.ForSaleQt = plant.ForSaleQt;
			plantDTO.InTS = plant.InTS;
			plantDTO.InTSQt = plant.InTSQt;
			plantDTO.Protocols = plant.Protocols;

			try
			{
				string jsonPlants = JsonSerializer.Serialize(plantDTO, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PatchAsync($"{_url}/Plants/{plantDTO.Id}", content);

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
