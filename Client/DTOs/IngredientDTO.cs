using Client.Models;

namespace Client.DTOs
{
	public class IngredientsDTO
	{
		public string? Name { get; set; }
		public string Type { get; set; }
		public string MeasurementType { get; set; }
		public float Quantity { get; set; }
		public List<Media>? Medias { get; set; }

	}
}
