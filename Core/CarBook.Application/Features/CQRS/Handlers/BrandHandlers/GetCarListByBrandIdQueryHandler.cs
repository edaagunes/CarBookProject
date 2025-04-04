using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BrandInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetCarListByBrandIdQueryHandler
	{
		private readonly IBrandRepository _brandRepository;

		public GetCarListByBrandIdQueryHandler(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<List<GetCarListByBrandIdQueryResult>> Handle(GetCarListByBrandIdQuery query)
		{
			var values = _brandRepository.GetCarListByBrandId(query.Id);
			return values.Select(x => new GetCarListByBrandIdQueryResult
			{
				BrandId = query.Id,
				CarId = values.First().CarId,
				CoverImageUrl = values.First().CoverImageUrl,
				Model = values.First().Model,
				BrandName=values.First().Brand.Name
			}).ToList();
		}
	}
}
