using System.ComponentModel;

namespace Client.Models
{
	public class Media : INotifyPropertyChanged
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

		string? _stage;
		public string Stage
		{
			get => _stage;
			set
			{
				if (_stage == value)
					return;
				_stage = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Stage)));
			}
		}

		public int? _ingredientId;
		public int? IngredientID
		{
			get => _protocolId;
			set
			{
				if (_protocolId == value)
					return;
				_protocolId = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProtocolId)));
			}
		}

		float _ph;
		public float PH
		{
			get => _ph;
			set
			{
				if (_ph == value)
					return;
				_ph = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PH)));
			}
		}

		public int? _protocolId;
		public int? ProtocolId
		{
			get => _protocolId;
			set
			{
				if (_protocolId == value)
					return;
				_protocolId = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProtocolId)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
