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
	public Ingredient selectedIngredient { get; set; } = new Ingredient();
	public List<int> IngredientIdList { get; } = new List<int>();
	public List<IngredientBase> ingredientsBase { get; set; }
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
	void OnIngredientPickerChanged(object sender, EventArgs e)
	{

		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		if (selectedIndex != -1)
		{
			string ingredientName = picker.Items[selectedIndex];
			selectedIngredient.Name = ingredientName;
		}
	}

	void OnTypeChanged(object sender, EventArgs e)
	{
		selectedIngredient.Type = ((Entry)sender).Text;
	}
	void OnQunatityChanged(object sender, EventArgs e)
	{
		selectedIngredient.Quantity = float.Parse(((Entry)sender).Text);
	}
	void OnIngredientMeasurPickerChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;
		if (selectedIndex != -1)
		{
			selectedIngredient.MeasurementType = picker.Items[selectedIndex];
		}
	}
	async void OnAddIngredientClicked(Object sender, EventArgs e)
	{
		Ingredient NewIngredientCheck = ingredients.Where(x => x.Name == selectedIngredient.Name &&
														 x.MeasurementType == selectedIngredient.MeasurementType &&
														 x.Type == selectedIngredient.Type &&
														 x.Quantity == selectedIngredient.Quantity)
														 .FirstOrDefault();
		if (NewIngredientCheck != null)
		{
			IngredientIdList.Add(NewIngredientCheck.Id);
		}
		else
		{
			var newID = await _ingredientRestService.AddIngedientAsync(selectedIngredient);

			IngredientIdList.Add(Int32.Parse(newID));
		}
		selectedIngredient = new Ingredient();
		ingredientPicker.SelectedIndex = -1;
		ingredientMeasurPicker.SelectedIndex = -1;
	}
	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		Media.IngredientID = IngredientIdList;
		if (_isNew)
		{
			Debug.WriteLine("Add item");
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