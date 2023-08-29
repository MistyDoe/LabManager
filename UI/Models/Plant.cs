using System.ComponentModel;

namespace UI.Models
{
	public class Plant : INotifyPropertyChanged
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

		string? _name;

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

		int _storedQt;
		public int StoredQt
		{
			get => _storedQt;
			set
			{
				if (_storedQt == value)
					return;
				_storedQt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoredQt)));
			}
		}
		bool _forSale;

		public bool ForSale
		{
			get => _forSale;
			set
			{
				if (_forSale == value)
					return;
				_forSale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ForSale)));
			}
		}
		bool _inTS;
		bool InTS
		{
			get => _inTS;
			set
			{
				if (_inTS == value)
					return;
				_inTS = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InTS)));
			}
		}
		int? _qtInTS;
		public int? QtInTS
		{
			get => _qtInTS;
			set
			{
				if (_qtInTS == value)
					return;
				_qtInTS = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QtInTS)));
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
	}
}
