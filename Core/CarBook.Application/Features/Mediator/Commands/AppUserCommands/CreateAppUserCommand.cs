using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.RegisterCommands
{
	public class CreateAppUserCommand : IRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
