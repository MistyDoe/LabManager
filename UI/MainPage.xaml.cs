using System.Diagnostics;
using UI.DataServices;

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
	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Debug.WriteLine("Plant changed clicked");
	}
}

