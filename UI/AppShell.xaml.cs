using UI.Pages;

namespace UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ManagePlantPage), typeof(ManagePlantPage));
	}
}
