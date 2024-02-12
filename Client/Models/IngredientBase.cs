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

		public event PropertyChangedEventHandler? PropertyChanged;

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

	}
}