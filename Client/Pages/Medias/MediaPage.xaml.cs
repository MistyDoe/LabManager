using Client.Services;
using System.Diagnostics;

namespace Client.Pages.Medias;

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
}