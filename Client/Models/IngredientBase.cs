using System.ComponentModel;

namespace Client.Models
{
	public class IngredientBase : INotifyPropertyChanged
	{
		public int _id;
		public int Id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
			}
		}

		public string? Name
		{
			get => _name;
			set
			{
				if (_name == value)
					return;
				_name = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}
		string? _name;


		public string? Type
		{
			get => _type;
			set
			{
				if (_type == value)
					return;
				_type = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
			}
		}
		string? _type;

		List<Ingredient>? _ingredients;

		public List<Ingredient>? Ingredients
		{
			get => _ingredients;
			set
			{
				if (_ingredients == value)
					return;
				_ingredients = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredient)));
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;


	}
}