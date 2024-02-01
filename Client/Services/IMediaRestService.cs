using Client.Models;

namespace Client.Services;

public interface IMediaRestService
{
	Task<List<Media>> GetAllMediaAsync();
	Task AddMediaAsync(Media media);
	Task RemoveMediaAsync(int id);
	Task UpdateMediaAsync(Media media);
}

