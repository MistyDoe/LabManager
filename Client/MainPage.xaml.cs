using Client.Models;
using Client.Pages;
using Client.Services;
using System.Diagnostics;

namespace Client;

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
		try
		{
			base.OnAppearing();
			collectionView.ItemsSource = await _plantService.GetAllPlantsAsync();

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

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


	private void SelectionChanged(object sender, SelectionChangedEventArgs e)
	{

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Plant), e.CurrentSelection.FirstOrDefault() as Plant}
		};
		Shell.Current.GoToAsync(nameof(ManagePlantPage), navigationParameter);
	}
}

