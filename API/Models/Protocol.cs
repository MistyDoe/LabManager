namespace API.Models
{
	public class Protocol
	{
		public int Id { get; set; }
		public List<Media>? Media { get; set; }
		public string Resource { get; set; }
		public int? PlantId { get; set; }
		public Plant? Plant { get; set; }
	}
}
