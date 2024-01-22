namespace API.Models
{
	public class PlantInTS
	{
		public int Id { get; set; }
		public Protocol? Protocol { get; set; }
		public int? ProtocolId { get; set; }
		public Plant? Plant { get; set; }
		public int? PlantId { get; set; }
		public int? Quantity { get; set; }
		public Media? Media { get; set; }
		public int? MediaId { get; set; }
		public List<Media>? FinnishedMedia { get; set; }
		public DateTime? Date { get; set; }
		public bool? Contaminated { get; set; }
		public DateTime? ContamDate { get; set; }
	}
}
