﻿using System.Diagnostics;
using UI.DataServices;
using UI.Models;
using UI.Pages;

namespace UI;

public partial class MainPage : ContentPage
{
	private readonly IPlantRestDataServices _plantService;

	public MainPage(IPlantRestDataServices plantService)
	{
		InitializeComponent();
		_plantService = plantService;
	}


	protected async override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource = await _plantService.GetAllPlantsAsync();

	}

	async void OnAddPlantClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("Add button clicked", sender);

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Plant), new Plant() }
		};

		await Shell.Current.GoToAsync(nameof(ManagePlantPage), navigationParameter);
	}

	async void OnIngredientListClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("Ingredient list clicked");
		await Shell.Current.GoToAsync(nameof(IngredientPage));
	}


	async void OnEditButtonClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("Plant changed clicked", e.ToString());

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Plant), new Plant() }
		};
		await Shell.Current.GoToAsync(nameof(ManagePlantPage), navigationParameter);
	}

	async void OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
	{
		Debug.WriteLine("protocol changed clicked");

		await Shell.Current.GoToAsync(nameof(ManagePlantPage));
	}


}

