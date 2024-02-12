using System.Text.Json.Serialization;

namespace API.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		public IngredientBase? IngredientBase { get; set; }
		public int? IngredientBaseId { get; set; }
		public string MeasurementType { get; set; }
		public float Quantity { get; set; }
		[JsonIgnore]
		public List<Media>? Media { get; set; }

	}
}