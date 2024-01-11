using System.Diagnostics;
using UI.DataServices;
using UI.Models;

namespace UI.Pages;
[QueryProperty(nameof(Ingredient), "Ingredient")]
public partial class ManageIngredientPage : ContentPage
{
	private IIngredientRestServices _service;
	Ingredient _ingredient;
	bool _isNew;
	public Ingredient Ingredient
	{
		get => _ingredient;
		set
		{
			_isNew = IsNew(value);
			_ingredient = value;
			OnPropertyChanged();
		}
	}
	public ManageIngredientPage(IIngredientRestServices service)
	{
		InitializeComponent();

		_service = service;
		BindingContext = this;
	}

	bool IsNew(Ingredient ingredient)
	{
		if (ingredient.Id == 0)
			return true;
		return false;
	}

	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("Add new item");
			await _service.AddIngedientAsync(Ingredient);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _service.UpdateIngedientAsync(Ingredient);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _service.RemoveIngredientAsyc(Ingredient.Id);
		await Shell.Current.GoToAsync("..");
	}
	async void OnCancelButtonClicked(Object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			Ingredient.MeasurementType = picker.Items[selectedIndex];
		}
	}
}