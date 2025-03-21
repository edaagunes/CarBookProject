using CarBook.Application.Features.Mediator.Results.StatisticResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
	public class GetAuthorCountQuery:IRequest<GetAuthorCountQueryResult>
	{
	}
}
