using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries
{
	public class GetCarListByBrandIdQuery
	{
		public int Id { get; set; }

		public GetCarListByBrandIdQuery(int id)
		{
			Id = id;
		}
	}
}
