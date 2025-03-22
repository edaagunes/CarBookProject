using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Locations");

			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.LocationName,
												Value = x.LocationId.ToString()
											}).ToList();
			ViewBag.v = values2;
			return View();
		}
		[HttpPost]
		public IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationId)
		{
			TempData["book_pick_date"] = book_pick_date;
			TempData["book_off_date"] = book_off_date;
			TempData["time_pick"] = time_pick;
			TempData["time_off"] = time_off;
			TempData["locationId"]=locationId;

			return RedirectToAction("Index","RentACarList");
		}
	}
}
