using CarBook.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LoginController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Login(GetCheckAppUserQuery query)
		{
			var values = await _mediator.Send(query);

			if (values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalı");
			}
		}
	}
}
