﻿using Client.Models;

namespace Client.DTOs
{
	public class PlantDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Genus { get; set; }
		public int? MotherPlantsQt { get; set; }
		public bool ForSale { get; set; }
		public int? ForSaleQt { get; set; }
		public bool InTS { get; set; }
		public int? InTSQt { get; set; }
		public List<Protocol>? Protocols { get; set; }
	}
}
