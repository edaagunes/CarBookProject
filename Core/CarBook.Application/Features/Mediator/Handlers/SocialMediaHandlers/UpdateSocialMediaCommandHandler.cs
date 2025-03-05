using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var values=await _repository.GetByIdAsync(request.SocialMediaId);
			values.Url = request.Url;
			values.Name = request.Name;
			values.Icon= request.Icon;
			values.SocialMediaId = request.SocialMediaId;
			await _repository.UpdateAsync(values);
		}
	}
}
