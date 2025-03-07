using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetLast3BlogsWithAuthors();
			return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
			{
				AuthorId = x.AuthorId,
				AuthorName=x.Author.Name,
				BlogId = x.BlogId,
				CategoryId = x.CategoryId,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title
			}).ToList();
		}
	}
}
