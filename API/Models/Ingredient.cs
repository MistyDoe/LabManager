using System.Text.Json.Serialization;

namespace API.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string MeasurementType { get; set; }
		public float Quantity { get; set; }
		[JsonIgnore]
		public List<Media>? Media { get; } = [];

	}
}