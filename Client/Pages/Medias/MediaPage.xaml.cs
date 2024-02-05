using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

public partial class MediaPage : ContentPage
{
	private readonly IMediaRestService _mediaRestService;
	public MediaPage(IMediaRestService mediaRestService)
	{
		InitializeComponent();
		_mediaRestService = mediaRestService;
	}

	protected async override void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			collectionView.ItemsSource = await _mediaRestService.GetAllMediaAsync();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
	}

	async void OnAddMediaClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("Add button clicked", sender);

		var navigationParameter = new Dictionary<string, object> {
			{nameof(Media), new Media() }
		};

		await Shell.Current.GoToAsync(nameof(ManageMediaPage), navigationParameter);
	}
}