using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
	{
		public CreateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adı giriniz");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri giriniz");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değeri giriniz");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum giriniz");
			RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Lütfen en az 20 karakter yorum giriniz");
			RuleFor(x => x.Comment).MinimumLength(500).WithMessage("Lütfen en fazla 500 karakter yorum giriniz");
		}
	}
}
