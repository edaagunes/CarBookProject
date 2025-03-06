using CarBook.Dto.CarDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Cars/GetLast5CarsWithBrand");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast5CarWithBrandsDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
