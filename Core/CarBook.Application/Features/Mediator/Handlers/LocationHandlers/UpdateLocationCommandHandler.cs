using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public UpdateLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.Id);
			values.LocationName = request.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
