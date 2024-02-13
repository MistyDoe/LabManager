using System.ComponentModel;

namespace Client.Models
{
	public class Ingredient : INotifyPropertyChanged
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

		string _measurementType;
		public string MeasurementType
		{
			get => _measurementType;
			set
			{
				if (_measurementType == value)
					return;
				_measurementType = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MeasurementType)));
			}
		}

		float _quantity;
		public float Quantity
		{
			get => _quantity;
			set
			{
				if (_quantity == value)
					return;
				_quantity = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
			}
		}

		int? _mediaId;

		public int? MediaId
		{
			get => _mediaId;
			set
			{
				if (_mediaId == value)
					return;
				_mediaId = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MediaId)));
			}
		}

		int? _ingredientBaseId;

		public int? IngredientBaseId
		{
			get => _ingredientBaseId;
			set
			{
				if (_ingredientBaseId == value)
					return;
				_ingredientBaseId = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IngredientBaseId)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

	}
}
