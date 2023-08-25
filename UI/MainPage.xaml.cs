namespace UI;

public partial class MainPage : ContentPage
{
	public MainPage(PlantViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}