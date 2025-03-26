using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos
{
	public class ResultCarFeatureByCarIdDto
	{
		public int CarFeatureId { get; set; }
		public int FeatureId { get; set; }
		public string FeatureName { get; set; }
		public bool Available { get; set; }
	}
}
