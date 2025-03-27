using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = _reviewRepository.GetReviewsByCarId(request.Id);
			return value.Select(x => new GetReviewByCarIdQueryResult
			{
				CarId = x.CarId,
				Comment = x.Comment,
				CustomerImage = x.CustomerImage,
				CustomerName = x.CustomerName,
				RatingValue = x.RatingValue,
				ReviewDate = x.ReviewDate,
				ReviewId = x.ReviewId
			}).ToList();
		}
	}
}
