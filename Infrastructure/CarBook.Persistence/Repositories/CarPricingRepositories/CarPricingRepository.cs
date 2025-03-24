using CarBook.Application.Enums;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using Infrastructure.CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(y => y.Pricing).Where(x => x.PricingId == 2).ToList();
			return values;
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			var values = from cp in _context.CarPricings
						 join c in _context.Cars on cp.CarId equals c.CarId
						 join b in _context.Brands on c.BrandId equals b.BrandId
						 group cp by new { b.Name, c.Model, c.CoverImageUrl } into grouped
						 select new CarPricingViewModel
						 {
							 Model = grouped.Key.Name + " " + grouped.Key.Model,
							 CoverImageUrl = grouped.Key.CoverImageUrl,
							 DailyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Daily).Sum(x => x.Amount),
							 WeeklyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Weekly).Sum(x => x.Amount),
							 MonthlyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Monthly).Sum(x => x.Amount)
						 };

			return values.ToList();

		}
	}
}
