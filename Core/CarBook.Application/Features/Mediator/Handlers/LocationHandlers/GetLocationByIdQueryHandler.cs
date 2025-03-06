using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationByIdQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetLocationByIdQueryResult
			{
				Id = value.LocationId,
				Name=value.LocationName
			};
		}
	}
}
