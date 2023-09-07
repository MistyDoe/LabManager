namespace API.Models
{
	public class Media
	{
		public int Id { get; set; }
		public Stage Stage { get; set; }
		public List<IngredientsForMedia>? Ingredients { get; } = new();

	}
}