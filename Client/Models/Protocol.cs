using System.ComponentModel;

namespace Client.Models
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

		public string? _resource;
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

		public string? _plantPart;
		public string PlantPart
		{
			get => _plantPart;
			set
			{
				if (_plantPart == value)
					return;
				_plantPart = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlantPart)));
			}
		}

		public string? _description;
		public string Description
		{
			get => _description;
			set
			{
				if (_description == value)
					return;
				_description = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
			}
		}

		List<Media>? _media;

		public List<Media> Media
		{
			get => _media;
			set
			{
				if (_media == value)
					return;
				_media = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Media)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
