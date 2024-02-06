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
	Ingredient selectedIngredient { get; } = new Ingredient();
	public List<Ingredient> IngredientList { get; } = new List<Ingredient>();
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
			selectedIngredient.Id = GenerateIdForIngredient();
			IngredientList.Add(selectedIngredient);
		}
		else
		{
			await _ingredientRestService.AddIngedientAsync(selectedIngredient);
			selectedIngredient.Id = GenerateIdForIngredient();
			IngredientList.Add(selectedIngredient);
		}
	}
	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		Media.Ingredients = IngredientList;
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

	int GenerateIdForIngredient()
	{
		id = new Random().Next().Next();
		List<Ingredient> selectedId = ingredients.Where(p => p.Id == id)
												 .ToList();
		List<Ingredient> selectedId2 = IngredientList.Where(p => p.Id == id)
													 .ToList();
		if (selectedId != null || selectedId2 != null)
		{
			id = new Random().Next();
		}
		return id;
	}
}