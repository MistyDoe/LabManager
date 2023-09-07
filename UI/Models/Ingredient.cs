using System.ComponentModel;

namespace UI.Models
{
	internal class Ingredient
	{

		int _name;
		public int Name
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

		int _type;
		public int Type
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

		int _measurementType;
		public int MeasurementType
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

		int _quantity;
		public int Quantity
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

		public event PropertyChangedEventHandler PropertyChanged;

	}
}
