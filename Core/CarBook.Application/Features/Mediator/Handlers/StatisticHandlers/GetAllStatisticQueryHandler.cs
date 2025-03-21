using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResult;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetAllStatisticQueryHandler : IRequestHandler<GetAllStatisticQuery, GetAllStatisticQueryResult>
	{
		private readonly IStatisticRepository _repository;

		public GetAllStatisticQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAllStatisticQueryResult> Handle(GetAllStatisticQuery request, CancellationToken cancellationToken)
		{
			var carCount = _repository.GetCarCount();
			var blogCount = _repository.GetBlogCount();
			var authorCount = _repository.GetAuthorCount();
			var brandCount = _repository.GetBrandCount();
			var locationCount = _repository.GetLocationCount();
			var avgRentPriceForDaily = _repository.GetAvgRentPriceForDaily();
			var avgRentPriceForWeekly = _repository.GetAvgRentPriceForWeekly();
			var avgRentPriceForMonthly = _repository.GetAvgRentPriceForMonthly();
			var carCountByTransmissionIsAuto=_repository.GetCarCountByTransmissionIsAuto();
			var brandNameByMaxCar=_repository.GetBrandNameByMaxCar();
			var blogTitleByMaxBlogComment=_repository.GetBlogTitleByMaxBlogComment();
			var carCountByKmSmallerThan1000=_repository.GetCarCountByKmSmallerThan1000();
			var carCountByFuelGasolineOrDiesel=_repository.GetCarCountByFuelGasolineOrDiesel();
			var carCountByFuelElectric = _repository.GetCarCountByFuelElectric();
			var carBrandAndModelByRentPriceDailyMax=_repository.GetCarBrandAndModelByRentPriceDailyMax();
			var carBrandAndModelByRentPriceDailyMin=_repository.GetCarBrandAndModelByRentPriceDailyMin();

			return new GetAllStatisticQueryResult
			{
				CarCount = carCount,
				BlogCount = blogCount,
				AuthorCount = authorCount,
				BrandCount = brandCount,
				LocationCount = locationCount,
				AvgRentPriceForDaily = avgRentPriceForDaily,
				AvgRentPriceForWeekly = avgRentPriceForWeekly,
				AvgRentPriceForMonthly = avgRentPriceForMonthly,
				CarCountByTransmissionIsAuto = carCountByTransmissionIsAuto,
				BrandNameByMaxCar = brandNameByMaxCar,
				BlogTitleByMaxBlogComment = blogTitleByMaxBlogComment,
				CarCountByKmSmallerThan1000 = carCountByKmSmallerThan1000,
				CarCountByFuelGasolineOrDiesel = carCountByFuelGasolineOrDiesel,
				CarCountByFuelElectric = carCountByFuelElectric,
				CarBrandAndModelByRentPriceDailyMax = carBrandAndModelByRentPriceDailyMax,
				CarBrandAndModelByRentPriceDailyMin = carBrandAndModelByRentPriceDailyMin
			};
		}
	}
}
