using Client.Models;

namespace Client.DTOs;

public class ProtocolDTO
{
	public string? Description { get; set; }
	public string? Resource { get; set; }
	public int PlantId { get; set; }
	public string? PlantPart { get; set; }
	public List<Media>? Media { get; set; }
}

