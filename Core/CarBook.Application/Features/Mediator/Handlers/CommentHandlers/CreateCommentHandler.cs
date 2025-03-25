using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
	public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly IRepository<Comment> _repository;

		public CreateCommentHandler(IRepository<Comment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Comment
			{
				Name = request.Name,
				BlogId = request.BlogId,
				CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
				Description = request.Description,
				Email = request.Email
			});
		}
	}
}
