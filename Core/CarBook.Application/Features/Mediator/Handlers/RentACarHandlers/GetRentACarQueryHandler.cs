﻿using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
			return values.Select(x => new GetRentACarQueryResult
			{
				CarId = x.CarId,
				Brand=x.Car.Brand.Name,
				Model=x.Car.Model,
				CoverImageUrl=x.Car.CoverImageUrl,
				Amount=x.Car.CarPricings.Where(cp=>cp.CarId==x.CarId).Select(cp=>cp.Amount).FirstOrDefault()
			}).ToList();
		}
	}
}
