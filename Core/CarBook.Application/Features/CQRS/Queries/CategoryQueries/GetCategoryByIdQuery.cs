using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
	public class GetCategoryByIdQuery
	{
		public int CategoryId { get; set; }

		public GetCategoryByIdQuery(int categoryId)
		{
			CategoryId = categoryId;
		}
	}
}
