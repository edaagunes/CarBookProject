using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class AdminStatisticController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminStatisticController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			Random random= new Random();

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Statistics/AllStatistics");
			if (responseMessage.IsSuccessStatusCode)
			{
				ViewBag.carCountRandom = random.Next(0, 101);
				ViewBag.brandCountRandom = random.Next(0, 101);
				ViewBag.authorCountRandom = random.Next(0, 101);
				ViewBag.blogCountRandom = random.Next(0, 101);
				ViewBag.locationCountRandom = random.Next(0, 101);
				ViewBag.avgRentPriceForDailyRandom = random.Next(0, 101);
				ViewBag.avgRentPriceForWeeklyRandom = random.Next(0, 101);
				ViewBag.avgRentPriceForMonthlyRandom = random.Next(0, 101);
				ViewBag.carCountByTransmissionIsAutoRandom = random.Next(0, 101);
				ViewBag.carCountByKmSmallerThan1000Random = random.Next(0, 101);
				ViewBag.carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
				ViewBag.carCountByFuelElectricRandom = random.Next(0, 101);
				ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
				ViewBag.carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
				ViewBag.brandNameByMaxCarRandom = random.Next(0, 101);
				ViewBag.blogTitleByMaxBlogCommentRandom = random.Next(0, 101);

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<AllStatisticDto>(jsonData);

				ViewBag.carCount = values.CarCount;
				ViewBag.brandCount = values.BrandCount;
				ViewBag.authorCount=values.AuthorCount;
				ViewBag.blogCount=values.BlogCount;
				ViewBag.locationCount=values.LocationCount;
				ViewBag.avgRentPriceForDaily=values.AvgRentPriceForDaily.ToString("0.00");
				ViewBag.avgRentPriceForWeekly=values.AvgRentPriceForWeekly.ToString("0.00");
				ViewBag.avgRentPriceForMonthly=values.AvgRentPriceForMonthly.ToString("0.00");
				ViewBag.carCountByTransmissionIsAuto=values.CarCountByTransmissionIsAuto;
				ViewBag.carCountByKmSmallerThan1000 = values.CarCountByKmSmallerThan1000;
				ViewBag.carCountByFuelGasolineOrDiesel = values.CarCountByFuelGasolineOrDiesel;
				ViewBag.carCountByFuelElectric = values.CarCountByFuelElectric;
				ViewBag.carBrandAndModelByRentPriceDailyMax = values.CarBrandAndModelByRentPriceDailyMax;
				ViewBag.carBrandAndModelByRentPriceDailyMin = values.CarBrandAndModelByRentPriceDailyMin;
				ViewBag.brandNameByMaxCar= values.BrandNameByMaxCar;
				ViewBag.blogTitleByMaxBlogComment = values.BlogTitleByMaxBlogComment;

				return View(values);
			}
			return View();
		}
	}
}
