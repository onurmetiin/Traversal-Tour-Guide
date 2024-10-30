using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class GuideValidator : AbstractValidator<Guide>
	{

		public GuideValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehber adını giriniz!");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Rehber açıklamasını giriniz!");
			RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehber Resmini giriniz!");


        }
	}
}

