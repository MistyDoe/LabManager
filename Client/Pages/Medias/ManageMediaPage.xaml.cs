using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;
[QueryProperty(nameof(Media), "Media")]
public partial class ManageMediaPage : ContentPage
{
	private IMediaRestService _service;
	Media media;
	bool _isNew;
	public Media Media
	{
		get => media;
		set
		{
			_isNew = IsNew(value);
			media = value;
			OnPropertyChanged();
		}
	}
	protected async override void OnAppearing()
	{
		try
		{
			base.OnAppearing();

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}
	public ManageMediaPage(IMediaRestService service)
	{
		InitializeComponent();

		_service = service;
		BindingContext = this;

	}

	bool IsNew(Media media)
	{
		if (media.Id == 0)
			return true;
		return false;
	}

	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("Add new item");
			await _service.AddMediaAsync(Media);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _service.UpdateMediaAsync(Media);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _service.RemoveMediaAsync(Media.Id);
		await Shell.Current.GoToAsync("..");
	}
	async void OnCancelButtonClicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}