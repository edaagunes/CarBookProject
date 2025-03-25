using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Statistics/AllStatistics");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<AllStatisticDto>(jsonData);

				ViewBag.carCount = values.CarCount;
				ViewBag.locationCount = values.LocationCount;
				ViewBag.brandCount = values.BrandCount;
				ViewBag.carCountByFuelElectric = values.CarCountByFuelElectric;

				return View(values);
			}
			return View();
		}
	}
}
