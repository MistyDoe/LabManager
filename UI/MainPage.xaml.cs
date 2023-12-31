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
		Debug.WriteLine("Add button clicked");

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Plant), new Plant() }
		};

		await Shell.Current.GoToAsync(nameof(ManagePlantPage), navigationParameter);
	}

	async void OnAddIngredientClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	async void OnAddProtocolClicked(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Debug.WriteLine("Plant changed clicked");

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Plant), e.CurrentSelection.FirstOrDefault() as Plant }
		};

		await Shell.Current.GoToAsync(nameof(ManagePlantPage), navigationParameter);
	}


}

