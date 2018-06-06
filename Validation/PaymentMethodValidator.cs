using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class PaymentMethodValidator : AbstractValidator<Models.PaymentMethod>
    {
		public PaymentMethodValidator()
        {
            RuleFor(method => method.Name).NotEmpty();

            RuleFor(method => method.PublicAdministrationCode)
				.Must(BeValidPaymentMethod).When(method => method.PublicAdministrationCode != null);
        }

		private static bool BeValidPaymentMethod(string challenge)
        {
            if (challenge == string.Empty) return true;

            foreach (var method in PaymentHelpers.PaymentMethods)
            {
                if (method.PublicAdministrationCode == challenge) return true;
            }
            return false;
        }
    }
}
