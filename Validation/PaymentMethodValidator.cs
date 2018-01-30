using Amica.Models;
using Amica.Models.ItalianPA;
using FluentValidation;

namespace Amica.Validation
{
    public class PaymentMethodValidator : AbstractValidator<Models.PaymentMethod>
    {
		public PaymentMethodValidator()
        {
            RuleFor(method => method.Name).NotEmpty();

            RuleFor(method => method.PublicAdministrationPaymentMethod)
				.Must(BeValidModalitaPagamentoPA).When(method => method.PublicAdministrationPaymentMethod != null);
        }

		private static bool BeValidModalitaPagamentoPA(Models.ItalianPA.PaymentMethod challenge)
        {
            return (
                challenge.Code != null && ItalianPAHelpers.PaymentMethod.ContainsKey(challenge.Code) &&
                challenge.Description != null && ItalianPAHelpers.PaymentMethod[challenge.Code].Description == challenge.Description
                );
        }
    }
}
