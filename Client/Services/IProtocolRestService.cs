using Client.Models;

namespace Client.Services;

public interface IProtocolRestService
{
	Task<List<Protocol>> GetAllProtcolsAsync();
	Task<List<Protocol>> GetProtocolsForPlant(int id);
	Task AddProtocolAsync(Protocol protocol);
	Task RemoveProtocolAsync(int id);
	Task UpdateProtocolAsync(Protocol protocol);

}

