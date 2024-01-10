using System.ComponentModel;

namespace UI.Models
{
	public class Ingredient
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
		string _name;
		public string Name
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


		string _type;
		public string Type
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

		//TODO : Fix the empty list issue
		List<Media>? _listOfMedias;

		public List<Media>? ListOfMedias
		{
			get => _listOfMedias;
			set
			{
				if (_listOfMedias == value)
					return;
				_listOfMedias = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOfMedias)));
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

	}
}
