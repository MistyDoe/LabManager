using UI.Models;

namespace UI.DataServices;

public interface IProtocolRestService
{
	Task<List<Protocol>> GetAllProtcolsAsync();
	Task<List<Protocol>> GetProtocolsForPlant(int id);
	Task AddProtocolAsync(Protocol protocol);
	Task RemoveProtocolAsync(int id);
	Task UpdateProtocolAsync(Protocol protocol);

}

