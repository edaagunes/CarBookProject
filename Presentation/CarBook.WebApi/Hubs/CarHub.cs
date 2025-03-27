using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CarBook.WebApi.Hubs
{
	public class CarHub : Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendCarCount()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Statistics/AllStatistics");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<AllStatisticDto>(jsonData);
			await Clients.All.SendAsync("ReceiveCarCount",values.CarCount);
		}
	}
}
