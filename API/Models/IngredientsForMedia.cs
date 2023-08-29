namespace API.Models
{
	public class IngredientsForMedia
	{
		public int Id { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public string MeasurementType { get; set; }
		public float Quantity { get; set; }
	}
}