﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetAllBlogsWithAuthorQueryResult
	{
		public int BlogId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string AuthorName { get; set; }
		public string AuthorDescription { get; set; }
		public string AuthorImageUrl { get; set; }
		public object CategoryName { get; set; }
		public int AuthorId { get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CategoryId { get; set; }
	}
}
