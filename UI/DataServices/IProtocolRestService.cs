using UI.Models;

namespace UI.DataServices;

public interface IProtocolRestService
{
	Task<List<Protocol>> GetAllProtcolsAsync();
	Task AddProtocolAsync(Protocol protocol);
	Task RemoveProtocolAsync(int id);
	Task UpdateProtocolAsync(Protocol protocol);
	Task DeleteProtocolAsync(int id);

}

