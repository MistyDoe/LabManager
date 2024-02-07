using System.ComponentModel;

namespace Client.Models
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


		public event PropertyChangedEventHandler PropertyChanged;

	}
}
