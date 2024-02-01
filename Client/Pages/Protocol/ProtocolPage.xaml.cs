using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

public partial class ProtocolPage : ContentPage
{
	private readonly IProtocolRestService _service;
	public ProtocolPage(IProtocolRestService service)
	{
		InitializeComponent();
		_service = service;
	}

	protected async override void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			collectionView.ItemsSource = await _service.GetAllProtcolsAsync();

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}
	async void OnAddNewProtocolClicled(object sender, EventArgs e)
	{
		Debug.WriteLine("Add button clicked", sender);

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Protocol), new Protocol() }
		};

		await Shell.Current.GoToAsync(nameof(ManageProtocolPage), navigationParameter);
	}
	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Protocol), e.CurrentSelection.FirstOrDefault() as Protocol}
		};
		Shell.Current.GoToAsync(nameof(ManageProtocolPage), navigationParameter);
	}
}