using System.ComponentModel;

namespace UI.Models
{
	public class Protocol : INotifyPropertyChanged
	{
		int _id;
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

		public string _resource;
		public string Resource
		{
			get => _resource;
			set
			{
				if (_resource == value)
					return;
				_resource = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resource)));
			}
		}

		public int _plantId;
		public int PlantId
		{
			get => _plantId;
			set
			{
				if (_plantId == value)
					return;
				_plantId = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlantId)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
