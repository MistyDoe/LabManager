using UI.DataServices;

namespace UI.Pages;

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
}