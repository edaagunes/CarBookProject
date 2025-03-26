using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
	public class _AdminDashboardStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			Random random = new Random();

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Statistics/AllStatistics");
			if (responseMessage.IsSuccessStatusCode)
			{
				ViewBag.carCountRandom = random.Next(0, 101);
				ViewBag.brandCountRandom = random.Next(0, 101);
				ViewBag.locationCountRandom = random.Next(0, 101);
				ViewBag.avgRentPriceForDailyRandom = random.Next(0, 101);

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<AllStatisticDto>(jsonData);

				ViewBag.carCount = values.CarCount;
				ViewBag.brandCount = values.BrandCount;
				ViewBag.locationCount = values.LocationCount;
				ViewBag.avgRentPriceForDaily = values.AvgRentPriceForDaily.ToString("0.00");
				return View(values);
			}
			return View();
		}
	}
}
