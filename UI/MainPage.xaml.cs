using UI.ViewModel;

namespace UI
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}
		public MainPage(PlantViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}