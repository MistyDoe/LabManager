using API.Models;

namespace API.DTOs
{
	public class MediaDTO
	{

		public string Stage { get; set; }
		public List<Ingredient>? Ingredients { get; set; }
		public float Ph { get; set; }
		public int? ProtocolId { get; set; }
	}
}
