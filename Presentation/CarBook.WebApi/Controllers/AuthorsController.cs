﻿using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthorsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> AuthorList()
		{
			var values = await _mediator.Send(new GetAuthorQuery());
			return Ok(values);
		}

		[HttpGet("GetBlogsByAuthorId")]
		public async Task<IActionResult> GetBlogsByAuthorIdList(int id)
		{
			var values = await _mediator.Send(new GetBlogsByAuthorIdQuery(id));
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAuthor(int id)
		{
			var value = await _mediator.Send(new GetAuthorByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAuthor(int id)
		{
			await _mediator.Send(new RemoveAuthorCommand(id));
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
	}
}
