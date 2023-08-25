namespace API.DTOs
{
	public class PlantDTO
	{
		public string? Name { get; set; }
		public int StoredQt { get; set; }
		public bool ForSale { get; set; }
		public bool InTS { get; set; }
		public int? QtInTS { get; set; }
	}
}
