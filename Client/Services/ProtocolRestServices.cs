using Client.DTOs;
using Client.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.Services;

class ProtocolRestServices : IProtocolRestService
{
	private readonly HttpClient _httpClient;
	private readonly string _baseAddress;
	private readonly string _url;
	private readonly JsonSerializerOptions _jsonSerializerOptions;

	public ProtocolRestServices()
	{
		_httpClient = new HttpClient();
		_baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5229/" : "http://localhost:5229/";
		_url = $"{_baseAddress}api";
		_jsonSerializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

	}

	public async Task AddProtocolAsync(ProtocolDTO protocolDTO)
	{
		try
		{
			string jsonPlants = JsonSerializer.Serialize<ProtocolDTO>(protocolDTO, _jsonSerializerOptions);
			StringContent content = new StringContent(jsonPlants, Encoding.UTF8, "application/Json");
			HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Protocols/", content);

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

	public async Task<List<Protocol>> GetAllProtcolsAsync()
	{
		List<Protocol> protocols = new List<Protocol>();

		try
		{
			HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Protocols");
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				protocols = JsonSerializer.Deserialize<List<Protocol>>(content, _jsonSerializerOptions);
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
		return protocols;
	}

	public async Task RemoveProtocolAsync(int id)
	{
		try
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Protocols/{id}");
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

	public async Task UpdateProtocolAsync(Protocol protocol)
	{
		try
		{
			string jsonProtocol = JsonSerializer.Serialize<Protocol>(protocol, _jsonSerializerOptions);
			StringContent content = new StringContent(jsonProtocol, Encoding.UTF8, "application/Json");
			HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Protocols/{protocol.Id}", content);

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

	public async Task<List<Protocol>> GetProtocolsForPlant(int id)
	{
		List<Protocol> protocols = new List<Protocol>();

		try
		{
			HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Protocols/ForPlant{id}");
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				protocols = JsonSerializer.Deserialize<List<Protocol>>(content, _jsonSerializerOptions);
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
		return protocols;
	}
}


