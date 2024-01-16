using UI.Models;

namespace UI.Pages;

[QueryProperty(nameof(Protocol), "Protocol")]
public partial class ManageProtocolPage : ContentPage
{

	public ManageProtocolPage()
	{
		InitializeComponent();
	}
}