using API.Models;

namespace API.DTOs
{
	public class IngredientDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string MeasurementType { get; set; }
		public int Quantity { get; set; }
		public List<Media>? ListOfMedias { get; } = new();



	}
}
