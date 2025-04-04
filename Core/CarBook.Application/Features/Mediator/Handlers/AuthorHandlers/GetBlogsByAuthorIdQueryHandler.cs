using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AuthorInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
	public class GetBlogsByAuthorIdQueryHandler : IRequestHandler<GetBlogsByAuthorIdQuery, List<GetBlogsByAuthorIdQueryResult>>
	{
		private readonly IAuthorRepository _authorRepository;

		public GetBlogsByAuthorIdQueryHandler(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<List<GetBlogsByAuthorIdQueryResult>> Handle(GetBlogsByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var value = _authorRepository.GetBlogsByAuthorId(request.Id);
			return value.Select(x => new GetBlogsByAuthorIdQueryResult
			{
				AuthorId = x.AuthorId,				
				BlogId = x.BlogId,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Description = x.Description,
				Name=x.Author.Name,
				Title=x.Title
			}).ToList();
		}
	}
}
