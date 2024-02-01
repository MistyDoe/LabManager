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

		List<Ingredient>? _ingredients;
		public List<Ingredient> Ingredients
		{
			get => _ingredients;
			set
			{
				if (_ingredients == value)
					return;
				_ingredients = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredient)));
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


		public int _protocolId;
		public int ProtocolId
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
