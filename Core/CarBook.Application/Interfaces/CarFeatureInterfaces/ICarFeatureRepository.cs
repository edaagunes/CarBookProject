using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
	public interface ICarFeatureRepository
	{
		List<CarFeature> GetCarFeaturesByCarId(int id);
		void ChangeCarFeatureAvailableToFalse(int id);
		void ChangeCarFeatureAvailableToTrue(int id);
		void CreateCarFeatureByCar(CarFeature carFeature);
	}
}
