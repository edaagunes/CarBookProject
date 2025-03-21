using CarBook.Application.Interfaces.StatisticsInterfaces;
using Infrastructure.CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
	public class StatisticRepository : IStatisticRepository
	{
		private readonly CarBookContext _context;

		public StatisticRepository(CarBookContext context)
		{
			_context = context;
		}

		public string GetBlogTitleByMaxBlogComment()
		{
			var values = _context.Comments.GroupBy(x => x.BlogId).Select(y => new { BlogId = y.Key, Count = y.Count() })
									.OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
			string blogName = _context.Blogs.Where(x => x.BlogId == values.BlogId).Select(y => y.Title).FirstOrDefault();
			return blogName;
		}

		public string GetBrandNameByMaxCar()
		{
			var values = _context.Cars.GroupBy(x => x.BrandId).Select(y => new { BrandId = y.Key, Count = y.Count() })
									.OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
			string brandName=_context.Brands.Where(x=>x.BrandId==values.BrandId).Select(y=>y.Name).FirstOrDefault();
			return brandName;
		}

		public int GetAuthorCount()
		{
			var value = _context.Authors.Count();
			return value;
		}

		public decimal GetAvgRentPriceForDaily()
		{
			int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
			var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
			return value;
		}

		public decimal GetAvgRentPriceForMonthly()
		{
			int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault();
			var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
			return value;
		}

		public decimal GetAvgRentPriceForWeekly()
		{
			int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault();
			var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
			return value;
		}

		public int GetBlogCount()
		{
			var value = _context.Blogs.Count();
			return value;
		}

		public int GetBrandCount()
		{
			var value = _context.Brands.Count();
			return value;
		}

		public string GetCarBrandAndModelByRentPriceDailyMax()
		{
			int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
			decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Max(x => x.Amount);
			int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
			string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
			return brandModel;
		}

		public string GetCarBrandAndModelByRentPriceDailyMin()
		{
			int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
			decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Min(x => x.Amount);
			int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
			string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
			return brandModel;
		}

		public int GetCarCount()
		{
			var value = _context.Cars.Count();
			return value;
		}

		public int GetCarCountByFuelElectric()
		{
			var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
			return value;
		}

		public int GetCarCountByFuelGasolineOrDiesel()
		{
			var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
			return value;
		}

		public int GetCarCountByKmSmallerThan1000()
		{
			var value = _context.Cars.Count(x => x.Km < 1000);
			return value;
		}

		public int GetCarCountByTransmissionIsAuto()
		{
			var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
			return value;
		}

		public int GetLocationCount()
		{
			var value = _context.Locations.Count();
			return value;
		}
	}
}
