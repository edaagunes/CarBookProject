﻿using CarBook.Application.Interfaces.CarPricingInterfaces;
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
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(y => y.Pricing).Where(x=>x.PricingId==2).ToList();
			return values;
		}
	}
}
