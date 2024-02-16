using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

[QueryProperty(nameof(Plant), "Plant")]
public partial class ManagePlantPage : ContentPage
{
	private IPlantRestDataServices _plantService;
	Plant _plant;
	bool _isNew;
	public Plant Plant
	{
		get => _plant;
		set
		{
			_isNew = IsNew(value);
			_plant = value;
			OnPropertyChanged();
		}
	}
	public ManagePlantPage(IPlantRestDataServices plantService)
	{
		InitializeComponent();
		_plantService = plantService;
		BindingContext = this;

	}

	bool IsNew(Plant plant)
	{
		if (plant.Id == 0)
			return true;
		return false;
	}

	void OnSaleChecked(object sender, ToggledEventArgs e)
	{
		Debug.WriteLine(e.Value);
		Plant.ForSale = e.Value;
	}
	void OnTSChecked(object sender, ToggledEventArgs e)
	{
		Plant.InTS = e.Value;
	}

	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("Add new item");
			await _plantService.AddPlantAsync(Plant);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _plantService.UpdatePlantAsync(Plant);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _plantService.RemovePlantAsync(Plant.Id);
		await Shell.Current.GoToAsync("..");
	}
	async void OnCancelButtonClicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}