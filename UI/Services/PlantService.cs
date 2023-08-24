using System.Text.Json;
using UI.Model;

namespace UI.Services
{
	public class PlantService
	{
		List<Plant> plantList = new();
		public async Task<List<Plant>> GetPlants()
		{
			if (plantList?.Count > 0)
				return plantList;
			using var stream = await FileSystem.OpenAppPackageFileAsync("Plant.json");
			using var reader = new StreamReader(stream);
			var contents = await reader.ReadToEndAsync();
			plantList = JsonSerializer.Deserialize(contents, PlantContext.Default.ListPlant);
			return plantList;
		}
	}
}
