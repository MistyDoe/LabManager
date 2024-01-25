using System.ComponentModel;

namespace Client.Models
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
		string? _genus;

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

		public string Genus
		{
			get => _genus;
			set
			{
				if (_genus == value)
					return;
				_genus = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}



		int _motherPlantsQt;
		public int MotherPlantsQt
		{
			get => _motherPlantsQt;
			set
			{
				if (_motherPlantsQt == value)
					return;
				_motherPlantsQt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_motherPlantsQt)));
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

		int _forSaleQt;
		public int ForSaleQt
		{
			get => _forSaleQt;
			set
			{
				if (_forSaleQt == value)
					return;
				_forSaleQt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_forSaleQt)));
			}
		}

		bool _inTS;
		public bool InTS
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
		int _InTSQt;
		public int InTSQt
		{
			get => _InTSQt;
			set
			{
				if (_InTSQt == value)
					return;
				_InTSQt = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InTSQt)));
			}
		}


		List<Protocol>? _protocols;

		public List<Protocol> Protocols
		{
			get => _protocols;
			set
			{
				if (_protocols == value)
					return;
				_protocols = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Protocols)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
