using API.Models;

namespace API.DTOs
{
	public class MediaDTO
	{
		public int Id { get; set; }
		public string Stage { get; set; }
		public List<Ingredient>? Ingredients { get; } = new();

		public int ProtocolId { get; set; }
	}
}
