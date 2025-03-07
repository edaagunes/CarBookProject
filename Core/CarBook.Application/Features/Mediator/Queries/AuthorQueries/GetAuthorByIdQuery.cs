using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;


namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
	public class GetAuthorByIdQuery:IRequest<GetAuthorByIdQueryResult>
	{
		public int Id { get; set; }

		public GetAuthorByIdQuery(int id)
		{
			Id = id;
		}
	}
}
