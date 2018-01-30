using Amica.Models;
using Amica.Models.ItalianPA;
using FluentValidation;

namespace Amica.Validation
{
    public class FeeValidator : AbstractValidator<Fee>
    {
		public FeeValidator()
        {
            RuleFor(charge => charge.Name).NotEmpty();
            RuleFor(charge => charge.Vat).SetValidator(new VatValidator());
        }

		private static bool BeValidModalitaPagamentoPA(Models.ItalianPA.PaymentMethod challenge)
        {
            return challenge.Code != null && ItalianPAHelpers.PaymentMethod.ContainsKey(challenge.Code);
        }
    }
}
