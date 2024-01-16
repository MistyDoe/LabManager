using UI.Pages;

namespace UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManagePlantPage), typeof(ManagePlantPage));
		Routing.RegisterRoute(nameof(ManageIngredientPage), typeof(ManageIngredientPage));
		Routing.RegisterRoute(nameof(IngredientPage), typeof(IngredientPage));
		Routing.RegisterRoute(nameof(ManageProtocolPage), typeof(ManageProtocolPage));
	}
}
