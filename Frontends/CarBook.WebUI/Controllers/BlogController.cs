﻿using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Yazarlarımızın Blogları";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Blogs/GetAllBlogsWithAuthorList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> BlogDetail(int id)
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Blog Detayı ve Yorumlar";
			ViewBag.blogid = id;
			return View();
		}

		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7053/api/Comments/CreateCommentWithMediator", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("BlogDetail", new { id = createCommentDto.BlogId });
			}
			return View();
		}
	}
}
