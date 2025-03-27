using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adı giriniz");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri giriniz");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değeri giriniz");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum giriniz");
			RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Lütfen en az 20 karakter yorum giriniz");
			RuleFor(x => x.Comment).MinimumLength(500).WithMessage("Lütfen en fazla 500 karakter yorum giriniz");
			RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görseli ekleyiniz");
		}
	}
}
