using Client.DTOs;
using Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.Services
{
	class MediaRestServices : IMediaRestService
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseAddress;
		private readonly string _url;
		private readonly JsonSerializerOptions _jsonSerializerOptions;

		public MediaRestServices()
		{
			_httpClient = new HttpClient();
			_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5229/" : "http://localhost:5229/";
			_url = $"{_baseAddress}api";
			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		}
		public async Task<List<Media>> GetAllMediaAsync()
		{
			List<Media> media = new List<Media>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Media");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					media = JsonSerializer.Deserialize<List<Media>>(content, _jsonSerializerOptions);
				}
				else
				{
					Debug.WriteLine(" Non http 2xx responce");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return media;
		}

		public async Task AddMediaAsync(Media media)
		{
			var mediaDTO = new MediaDTO();
			mediaDTO.Stage = media.Stage;
			mediaDTO.Ingredients = media.Ingredients;
			mediaDTO.PH = media.PH;
			try
			{
				string jsonMedia = JsonSerializer.Serialize<MediaDTO>(mediaDTO, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonMedia, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Media/", content);

				if (response.IsSuccessStatusCode)
				{
					Debug.Write("Successfully created plant");
				}
				else
				{
					Debug.WriteLine("Non Http 2xx response");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return;
		}

		public async Task UpdateMediaAsync(Media media)
		{
			try
			{
				string jsonMedia = JsonSerializer.Serialize<Media>(media, _jsonSerializerOptions);
				StringContent content = new StringContent(jsonMedia, Encoding.UTF8, "application/Json");
				HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Media/{media.Id}", content);

				if (response.IsSuccessStatusCode)
				{
					Debug.Write("Successfully created plant");
				}
				else
				{
					Debug.WriteLine("Non Http 2xx response");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}

		public async Task RemoveMediaAsync(int id)
		{
			try
			{
				HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Madia/{id}");
				if (response.IsSuccessStatusCode)
				{
					Debug.Write("Successfully created plant");
				}
				else
				{
					Debug.WriteLine("Non Http 2xx response");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}
}
