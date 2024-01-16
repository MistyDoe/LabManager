using UI.Models;

namespace UI.DataServices
{
	public interface IMediaRestDataService
	{
		Task<List<Media>> GetAllMediaAsync();
		Task AddMediaAsync(Media media);
		Task RemoveMediaAsync(int id);
		Task UpdateMediaAsync(Protocol protocol);
		Task DeleteMediaAsync(int id);
	}
}

