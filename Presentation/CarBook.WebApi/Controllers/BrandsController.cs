using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
		private readonly GetBrandQueryHandler _getBrandQueryHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
		private readonly GetCarListByBrandIdQueryHandler _getCarListByBrandIdQueryHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetCarListByBrandIdQueryHandler getCarListByBrandIdQueryHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
			_getBrandQueryHandler = getBrandQueryHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
			_getCarListByBrandIdQueryHandler = getCarListByBrandIdQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _getBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("GetCarListByBrandId")]
		public async Task<IActionResult> GetCarListByBrandId(int id)
		{
			var values = await _getCarListByBrandIdQueryHandler.Handle(new GetCarListByBrandIdQuery(id));
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			await _createBrandCommandHandler.Handle(command);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await _updateBrandCommandHandler.Handle(command);
			return Ok();
		}
	}
}
