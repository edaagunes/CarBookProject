using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewId);
			values.CustomerName = request.CustomerName;
			values.CustomerImage = request.CustomerImage;
			values.ReviewDate = request.ReviewDate;
			values.CarId = request.CarId;
			values.Comment = request.Comment;
			values.RatingValue = request.RatingValue;
			await _repository.UpdateAsync(values);
		}
	}
}
