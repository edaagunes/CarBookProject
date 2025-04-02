using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ReservationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v1 = "Araç Kiralama";
			ViewBag.v2 = "Araç Rezervasyon Formu";
			ViewBag.carid = id;

			var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
			var client = _httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
		public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
		{
			// Lokasyon verilerini tekrar al
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Locations");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
				List<SelectListItem> values2 = (from x in values
												select new SelectListItem
												{
													Text = x.LocationName,
													Value = x.LocationId.ToString()
												}).ToList();
				ViewBag.v = values2;
			}

			var jsonDataToSend = JsonConvert.SerializeObject(createReservationDto);
			StringContent content = new StringContent(jsonDataToSend, Encoding.UTF8, "application/json");
			var postResponse = await client.PostAsync("https://localhost:7053/api/Reservations", content);

			if (postResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}

			return View(createReservationDto);
		}
	}
}
