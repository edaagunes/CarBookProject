using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
	public interface IStatisticRepository
	{
		int GetCarCount();
		int GetLocationCount();
		int GetAuthorCount();
		int GetBlogCount();
		int GetBrandCount();
		decimal GetAvgRentPriceForDaily();
		decimal GetAvgRentPriceForWeekly();
		decimal GetAvgRentPriceForMonthly();
		int GetCarCountByTransmissionIsAuto();
		string GetBrandNameByMaxCar();
		string GetBlogTitleByMaxBlogComment();
		int GetCarCountByKmSmallerThan1000();
		int GetCarCountByFuelGasolineOrDiesel();
		int GetCarCountByFuelElectric();
		string GetCarBrandAndModelByRentPriceDailyMax();
		string GetCarBrandAndModelByRentPriceDailyMin();
	}
}
