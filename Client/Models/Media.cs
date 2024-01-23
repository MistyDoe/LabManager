using System.ComponentModel;

namespace Client.Models
{
	public class Media : INotifyPropertyChanged
	{
		int? _id;
		public int? Id
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


		public event PropertyChangedEventHandler PropertyChanged;
	}
}
