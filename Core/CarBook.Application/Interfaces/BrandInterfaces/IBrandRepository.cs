using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BrandInterfaces
{
	public interface IBrandRepository
	{
		List<Car> GetCarListByBrandId(int id);
	}
}
