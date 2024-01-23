using Client.Models;

namespace Client.Services;

public interface IMediaRestDataService
{
	Task<List<Media>> GetAllMediaAsync();
	Task AddMediaAsync(Media media);
	Task RemoveMediaAsync(int id);
	Task UpdateMediaAsync(Protocol protocol);
	Task DeleteMediaAsync(int id);
}

