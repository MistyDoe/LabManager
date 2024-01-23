using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;

[QueryProperty(nameof(Protocol), "Protocol")]
public partial class ManageProtocolPage : ContentPage
{
	private IProtocolRestService _service;
	Protocol _protocol;
	bool _isNew;
	public Protocol Protocol
	{
		get => _protocol;
		set
		{
			_isNew = IsNew(value);
			_protocol = value;
			OnPropertyChanged();
		}
	}
	public ManageProtocolPage(IProtocolRestService service)
	{
		InitializeComponent();
		_service = service;
		BindingContext = this;
	}

	bool IsNew(Protocol protocol)
	{
		if (protocol.Id == 0)
			return true;
		return false;
	}


	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("Add new item");
			await _service.AddProtocolAsync(Protocol);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _service.UpdateProtocolAsync(Protocol);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _service.RemoveProtocolAsync(Protocol.Id);
		await Shell.Current.GoToAsync("..");
	}
	async void OnCancelButtonClicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}