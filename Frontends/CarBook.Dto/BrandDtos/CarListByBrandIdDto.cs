using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BrandDtos
{
	public class CarListByBrandIdDto
	{
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		public int CarId { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
