﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogsWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorId = x.AuthorId,
				AuthorName = x.Author.Name,
				BlogId = x.BlogId,
				CategoryId = x.CategoryId,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				Description = x.Description,
				AuthorDescription=x.Author.Description,
				AuthorImageUrl=x.Author.ImageUrl,
				CategoryName=x.Category.Name
			}).ToList();
		}
	}
}
