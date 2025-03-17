using CarBook.Dto.AuthorDtos;
using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogDetailAuthorAboutComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7053/api/Blogs/GetBlogByAuthorId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultGetAuthorByBlogAuthorIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
