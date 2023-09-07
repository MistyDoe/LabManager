using UI.Models;

namespace UI.Pages
{
	[QueryProperty(nameof(Ingredient), "Ingredient")]
	public class IngredientPage : ContentPage
	{

		private IIngredientRestService _service;
		Plant _ingredient;
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
		public IngredientPage(IIngredientRestService service)
		{
			InitializeComponent();

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
				await _service.AddPlantAsync(Ingredient);
			}
			else
			{
				Debug.WriteLine("Update an item");
				await _plantService.UpdatePlantAsync(Plant);
			}

			await Shell.Current.GoToAsync("..");
		}
		async void OnDeleteButtonClicked(Object sender, EventArgs e)
		{
			await _plantService.RemovePlantAsync(Plant.Id);
			await Shell.Current.GoToAsync("..");
		}
		async void OnCancelButtonClicked(Object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("..");
		}
	}

}
}
