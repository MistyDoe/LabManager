using Client.Models;

namespace Client.DTOs
{
	public class MediaDTO
	{
		public string Stage { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public float PH { get; set; }

	}
}
