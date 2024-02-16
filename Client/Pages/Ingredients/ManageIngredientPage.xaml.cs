using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;
[QueryProperty(nameof(Ingredient), "Ingredient")]
public partial class ManageIngredientPage : ContentPage
{
	private IIngredientRestServices _service;
	Ingredient ingredient;
	bool _isNew;
	public Ingredient Ingredient
	{
		get => ingredient;
		set
		{
			_isNew = IsNew(value);
			ingredient = value;
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
	public ManageIngredientPage(IIngredientRestServices service)
	{
		InitializeComponent();

		_service = service;
		BindingContext = this;
		if (_isNew = true)
		{
			picker.SelectedIndex = -1;
		}
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