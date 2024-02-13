using Client.Models;
using Client.Services;
using System.Diagnostics;

namespace Client.Pages;
public partial class ManageIngredientBasePage : ContentPage
{
	private IIngredientBaseRestServices _service;
	IngredientBase ingredientBase;
	bool _isNew;
	public IngredientBase IngredientBase
	{
		get => ingredientBase;
		set
		{
			_isNew = IsNew(value);
			ingredientBase = value;
			OnPropertyChanged();
		}
	}

	protected async override void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			picker.SelectedIndex = picker.Items.IndexOf(ingredientBase.Type);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}

	}
	public ManageIngredientBasePage(IIngredientBaseRestServices service)
	{
		InitializeComponent();

		_service = service;
		BindingContext = this;
		if (_isNew = true)
		{
			picker.SelectedIndex = -1;
		}
	}

	bool IsNew(IngredientBase ingredientBase)
	{
		if (ingredientBase.Id == 0)
			return true;
		return false;
	}

	async void OnSaveButtonClicked(Object sender, EventArgs e)
	{
		if (_isNew)
		{
			Debug.WriteLine("Add new item");
			await _service.AddIngedientBaseAsync(IngredientBase);
		}
		else
		{
			Debug.WriteLine("Update an item");
			await _service.UpdateIngedientBaseAsync(IngredientBase);
		}

		await Shell.Current.GoToAsync("..");
	}
	async void OnDeleteButtonClicked(Object sender, EventArgs e)
	{
		await _service.RemoveIngredientBaseAsyc(IngredientBase.Id);
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
			IngredientBase.Type = picker.Items[selectedIndex];
		}

	}
}