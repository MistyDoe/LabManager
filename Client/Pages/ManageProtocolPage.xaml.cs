using Client.DTOs;
using Client.Models;
using Client.Services;
using System.Diagnostics;


namespace Client.Pages;

[QueryProperty(nameof(Protocol), "Protocol")]
public partial class ManageProtocolPage : ContentPage
{
	private IProtocolRestService _protocolService;
	private IPlantRestDataServices _plantRestDataServices;
	Protocol _protocol;
	bool _isNew;
	public List<string> plants { get; set; }

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
	public ManageProtocolPage(IProtocolRestService protocolRestService, IPlantRestDataServices plantRestDataServices)
	{
		InitializeComponent();
		_protocolService = protocolRestService;
		_plantRestDataServices = plantRestDataServices;
		var plantsList = new List<string>();
		plantsList.Add("Alocasia");
		plantsList.Add("Philodendron");
		plants = plantsList;
		this.BindingContext = this;

	}

	private async void PopulatePlants()
	{
		throw new NotImplementedException();
	}

	protected async override void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			//plantPicker.SetBinding(Picker.ItemsSourceProperty, "Plants");
			//plantPicker.BindingContext = plants;
			//plantPicker.ItemDisplayBinding = new Binding("Name");

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}
	bool IsNew(Protocol protocol)
	{
		if (protocol.Id == 0)
			return true;
		return false;
	}

	void OnPlantPickerChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		Debug.WriteLine(selectedIndex);
	}
	void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		Debug.WriteLine(selectedIndex);
	}

	async void OnAddNewMediaClicled(Object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			ProtocolDTO protocolDTO = new ProtocolDTO();
			protocolDTO.Description = Protocol.Description;
			protocolDTO.Resource = Protocol.Resource;
			protocolDTO.PlantId = Protocol.PlantId;
			protocolDTO.PlantPart = Protocol.PlantPart;
			protocolDTO.Media = Protocol.Media;
			Debug.WriteLine("Add new item");
			await _protocolService.AddProtocolAsync(protocolDTO);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _protocolService.UpdateProtocolAsync(Protocol);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _protocolService.RemoveProtocolAsync(Protocol.Id);
		await Shell.Current.GoToAsync("..");
	}
	async void OnCancelButtonClicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}