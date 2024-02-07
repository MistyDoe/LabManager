using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

public partial class IngredientPage : ContentPage
{
	private IIngredientRestServices _service;
	public IngredientPage(IIngredientRestServices service)
	{
		InitializeComponent();
		_service = service;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource = await _service.GetAllIngredientsAsync();
	}
	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{

		var navigationParameter = new Dictionary<string, object> {
			{nameof(IngredientDTO), e.CurrentSelection.FirstOrDefault() as IngredientDTO }
		};

		await Shell.Current.GoToAsync(nameof(ManageIngredientPage), navigationParameter);
	}

	async void OnAddNewIngredient(object sender, EventArgs e)
	{
		Debug.WriteLine("Add button clicked");

		var navigationParameter = new Dictionary<string, object> {
			{nameof(IngredientDTO), new IngredientDTO() }
		};

		await Shell.Current.GoToAsync(nameof(ManageIngredientPage), navigationParameter);
	}

}