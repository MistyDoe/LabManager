using Client.Models;


namespace Client.Pages;

[QueryProperty(nameof(Protocol), "Protocol")]
public partial class ManageProtocolPage : ContentPage
{

	public ManageProtocolPage()
	{
		InitializeComponent();

	}
}