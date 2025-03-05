using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{
		private readonly IRepository<Pricing> _repository;

		public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetPricingByIdQueryResult
			{
				PricingId = value.PricingId,
				Name=value.Name
			};
		}
	}
}
