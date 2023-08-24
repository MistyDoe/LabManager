using System.Text.Json.Serialization;

namespace UI.Model
{
	public class Plant
	{
		public string Name { get; set; }
	}

	[JsonSerializable(typeof(List<Plant>))]
	internal sealed partial class PlantContext : JsonSerializerContext
	{
	}
}