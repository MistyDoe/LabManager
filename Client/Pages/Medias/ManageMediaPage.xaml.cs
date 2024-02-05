using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;
[QueryProperty(nameof(Media), "Media")]
public partial class ManageMediaPage : ContentPage
{
	private IMediaRestService _service;
	private IIngredientRestServices _ingredientRestService;
	Media media;
	public List<Ingredient> ingredients { get; set; }
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
			ingredients = await _ingredientRestService.GetAllIngredientsAsync();
			ingredientPicker.SetBinding(Picker.ItemsSourceProperty, "ingredients");
			ingredientPicker.ItemDisplayBinding = new Binding("Name");
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}
	public ManageMediaPage(IMediaRestService service, IIngredientRestServices ingredientRestServices)
	{
		InitializeComponent();

		_service = service;
		_ingredientRestService = ingredientRestServices;
		BindingContext = this;

	}

	bool IsNew(Media media)
	{
		if (media.Id == 0)
			return true;
		return false;
	}
	void OnIngredientPickerChanged(object sender, EventArgs e)
	{
		Media.Ingredients = new List<Ingredient>();
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		if (selectedIndex != -1)
		{
			string ingredientName = picker.Items[selectedIndex];
			Ingredient selectedingredient = ingredients
				.FirstOrDefault(p => p.Name == ingredientName);
			Media.Ingredients.Add(selectedingredient);
		}
	}
	void OnSagePickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		if (selectedIndex != -1)
		{
			string stage = picker.Items[selectedIndex];
			Media.Stage = stage;
		}
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