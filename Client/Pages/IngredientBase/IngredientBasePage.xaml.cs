using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

public partial class IngredientBasePage : ContentPage
{
	private IIngredientBaseRestServices _service;
	public IngredientBasePage(IIngredientBaseRestServices service)
	{
		InitializeComponent();
		_service = service;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource = await _service.GetAllIngredientsBaseAsync();
	}
	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{

		var navigationParameter = new Dictionary<string, object> {
			{nameof(IngredientBase), e.CurrentSelection.FirstOrDefault() as IngredientBase }
		};

		await Shell.Current.GoToAsync(nameof(ManageIngredientPage), navigationParameter);
	}

	async void OnAddNewIngredient(object sender, EventArgs e)
	{
		Debug.WriteLine("Add button clicked");

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Ingredient), new Ingredient() }
		};

		await Shell.Current.GoToAsync(nameof(ManageIngredientPage), navigationParameter);
	}

}