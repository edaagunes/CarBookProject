using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetFooterAddressQueryResult
			{
				Address = x.Address,
				Description = x.Description,
				Email = x.Email,
				FooterAddressId = x.FooterAddressId,
				PhoneNumber = x.PhoneNumber,
			}).ToList();
		}
	}
}
