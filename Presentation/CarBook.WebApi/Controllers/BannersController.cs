using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

		public BannersController(RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler)
		{
			_removeBannerCommandHandler = removeBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
			_createBannerCommandHandler = createBannerCommandHandler;
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBannerCommandHandler.Handle(command);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);
			return Ok();
		}
	}
}
