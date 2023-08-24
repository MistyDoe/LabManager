using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using System.Diagnostics;
using UI.Model;
using UI.Services;

namespace UI.ViewModel
{
	public partial class PlantViewModel : BaseViewModel
	{
		public ObservableCollection<Plant> Plants { get; } = new();
		PlantService plantService;
		public PlantViewModel(PlantService plantService)
		{
			Title = "Plant Search";
			this.plantService = plantService;
		}
		[RelayCommand]
		async Task GetPlantsAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				var plants = await plantService.GetPlants();

				if (Plants.Count != 0)
					Plants.Clear();
				foreach (var plant in plants)
					Plants.Add(plant);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Unable to get Plants: {ex.Message}");
				await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
