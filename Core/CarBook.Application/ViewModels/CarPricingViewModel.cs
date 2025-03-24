using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
	public class CarPricingViewModel
	{
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public string Brand { get; set; }
		public decimal DailyPrice { get; set; }
		public decimal WeeklyPrice { get; set; }
		public decimal MonthlyPrice { get; set; }
	}
}
