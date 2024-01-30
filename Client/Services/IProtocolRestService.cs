using Client.DTOs;
using Client.Models;

namespace Client.Services;

public interface IProtocolRestService
{
	Task<List<Protocol>> GetAllProtcolsAsync();
	Task<List<Protocol>> GetProtocolsForPlant(int id);
	Task AddProtocolAsync(ProtocolDTO protocolDTO);
	Task RemoveProtocolAsync(int id);
	Task UpdateProtocolAsync(Protocol protocol);

}

