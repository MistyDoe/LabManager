using System.Text.Json.Serialization;

namespace API.Models
{
	public class Media
	{
		public int Id { get; set; }
		public string Stage { get; set; }
		public List<Ingredient>? Ingredients { get; } = new();
		[JsonIgnore]
		public Protocol? Protocol { get; set; }
		public int ProtocolId { get; set; }

	}
}