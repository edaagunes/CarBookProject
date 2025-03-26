using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class AdminCarFeatureDetailController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7053/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
		{
			foreach (var item in resultCarFeatureByCarIdDtos)
			{
				if (item.Available)
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync($"https://localhost:7053/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);
				}
				else
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync($"https://localhost:7053/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
				}
			}
			return RedirectToAction("Index", "AdminCar");
		}

		[HttpGet]
		public async Task<IActionResult> CreateFeatureByCarId()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
