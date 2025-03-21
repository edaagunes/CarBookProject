using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StatisticsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetCarCount")]
		public async Task<IActionResult> GetCarCount()
		{
			var values = await _mediator.Send(new GetCarCountQuery());
			return Ok(values);
		}

		[HttpGet("AllStatistics")]
		public async Task<IActionResult> AllStatistics()
		{
			var values=await _mediator.Send(new GetAllStatisticQuery());
			return Ok(values);
		}
	}
}
