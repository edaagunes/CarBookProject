﻿using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FooterAddressesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FooterAddressList()
		{
			var values = await _mediator.Send(new GetFooterAddressQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterAddress(int id)
		{
			var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveFooterAddress(int id)
		{
			await _mediator.Send(new RemoveFooterAddressCommand(id));
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
	}
}
