using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogDetailMainComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.blogid = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7053/api/Blogs/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultGetBlogById>(jsonData);

				var commentCountResponse = await client.GetAsync($"https://localhost:7053/api/Comments/CommentCountByBlog?id=" + id);
				var jsonData2 = await commentCountResponse.Content.ReadAsStringAsync();
				ViewBag.commentCount = jsonData2;

				return View(values);
			}

			return View();
		}
	}
}
