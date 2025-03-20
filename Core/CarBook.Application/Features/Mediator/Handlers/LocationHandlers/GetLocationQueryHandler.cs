using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetLocationQueryResult
			{
				LocationName=x.LocationName,
				LocationId=x.LocationId
			}).ToList();
		}
	}
}
