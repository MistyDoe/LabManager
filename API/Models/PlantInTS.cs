namespace API.Models
{
	public class PlantInTS
	{
		public Protocol Protocol { get; set; }
		public Plant Plant { get; set; }
		public int Quantity { get; set; }
		public Stage Stage { get; set; }
		public DateTime Date { get; set; }
		public bool Contaminated { get; set; }
		public DateTime ContamDate { get; set; }
	}
}
