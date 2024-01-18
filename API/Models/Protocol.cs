using System.Text.Json.Serialization;

namespace API.Models
{
	public class Protocol
	{
		public int Id { get; set; }
		public List<Media>? Media { get; set; }
		public string Resource { get; set; }
		public int? PlantId { get; set; }
		public string PlantPart { get; set; }
		public int MyProperty { get; set; }
		public string Description { get; set; }
		[JsonIgnore]
		public Plant? Plant { get; set; }

	}
}
