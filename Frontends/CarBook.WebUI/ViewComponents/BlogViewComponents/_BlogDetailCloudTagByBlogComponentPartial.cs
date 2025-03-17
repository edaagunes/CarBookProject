using CarBook.Dto.BlogDtos;
using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogDetailCloudTagByBlogComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7053/api/TagClouds/GetTagCloudByBlogId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultGetByBlogIdTagCloudDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
