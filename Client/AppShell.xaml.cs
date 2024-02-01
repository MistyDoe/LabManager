using Client.Pages;
using Client.Pages.Medias;


namespace Client;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManagePlantPage), typeof(ManagePlantPage));
		Routing.RegisterRoute(nameof(ManageIngredientPage), typeof(ManageIngredientPage));
		Routing.RegisterRoute(nameof(IngredientPage), typeof(IngredientPage));
		Routing.RegisterRoute(nameof(ManageProtocolPage), typeof(ManageProtocolPage));
		Routing.RegisterRoute(nameof(ProtocolPage), typeof(ProtocolPage));
		Routing.RegisterRoute(nameof(MediaPage), typeof(MediaPage));

	}
}
