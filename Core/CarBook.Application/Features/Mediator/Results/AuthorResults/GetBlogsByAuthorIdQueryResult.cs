using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.AuthorResults
{
	public class GetBlogsByAuthorIdQueryResult:IRequest
	{
		public int AuthorId { get; set; }
		public string Name { get; set; }
		public int BlogId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
