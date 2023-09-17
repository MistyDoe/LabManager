using System.Diagnostics;
using UI.DataServices;
using UI.Models;

namespace UI.Pages
{
	[QueryProperty(nameof(Ingredient), "Ingredient")]
	public class IngredientPage : ContentPage
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
		public IngredientPage(IIngredientRestServices service)
		{
			//InitializeComponent();

			_service = service;
			BindingContext = this;
		}

		bool IsNew(Ingredient ingredient)
		{
			if (ingredient.Name == 0)
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

		async void OnCancelButtonClicked(Object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("..");
		}
	}

}

