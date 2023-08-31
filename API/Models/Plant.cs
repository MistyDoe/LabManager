using System.ComponentModel.DataAnnotations;

namespace API.Models
{
	public class Plant
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int NoMotherPlants { get; set; }
		public int Total { get; set; }
		public bool ForSale { get; set; }
		public int ForSaleQt { get; set; }
		public bool InTS { get; set; }
		public int InTSQt { get; set; }
		public List<Protocol>? Protocols { get; set; }
	}


}
