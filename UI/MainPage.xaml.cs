using System.Diagnostics;
using UI.DataServices;

namespace UI;

public partial class MainPage : ContentPage
{
	private readonly IPlantRestDataServices _platService;

	public MainPage(IPlantRestDataServices plantService)
	{
		InitializeComponent();
		_platService = plantService;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource = await _platService.GetAllPlantsAsync();
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

