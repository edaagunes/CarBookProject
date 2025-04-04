using CarBook.Application.Interfaces.BrandInterfaces;
using CarBook.Domain.Entities;
using Infrastructure.CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BrandRepositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly CarBookContext _context;

		public BrandRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Car> GetCarListByBrandId(int id)
		{
			return _context.Cars.Include(y => y.Brand).Where(x=>x.BrandId == id).ToList();
		}
	}
}
