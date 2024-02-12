using API.Models;
using System.Text.Json.Serialization;

namespace API.DTOs
{
	public class IngredientBaseDTO
	{
		public string Name { get; set; }
		public string Type { get; set; }
		[JsonIgnore]
		public List<Ingredient>? Ingredients { get; set; }
	}
}