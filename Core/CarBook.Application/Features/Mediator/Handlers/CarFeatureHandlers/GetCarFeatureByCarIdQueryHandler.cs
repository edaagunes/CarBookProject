using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
	public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
	{
		private readonly ICarFeatureRepository _repository;

		public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarFeaturesByCarId(request.Id);
			return value.Select(x => new GetCarFeatureByCarIdQueryResult
			{
				CarFeatureId = x.CarFeatureId,
				Available=x.Available,
				FeatureId=x.FeatureId,
				FeatureName=x.Feature.Name
			}).ToList();
		}
	}
}
