using API.Models;

namespace API.DTOs
{
	public class ProtocolDTO
	{

		public List<Media>? Media { get; set; }
		public string? Resource { get; set; }
		public int? PlantId { get; set; }
		public string PlantPart { get; set; }
		public string Description { get; set; }

	}
}
