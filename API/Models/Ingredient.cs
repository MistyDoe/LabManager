namespace API.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string MeasurementType { get; set; }
		public float Quantity { get; set; }
		public List<Media>? ListOfMedias { get; } = new();
	}
}