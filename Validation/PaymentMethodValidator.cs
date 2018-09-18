using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class PaymentMethodValidator : AbstractValidator<Models.PaymentMethod>
    {
		public PaymentMethodValidator()
        {
            RuleFor(method => method.Name).NotEmpty();

            RuleFor(method => method.Code)
				.Must(BeValidPaymentMethod).When(method => method.Code != null);
        }

		private static bool BeValidPaymentMethod(string challenge)
        {
            if (challenge == string.Empty) return true;

            foreach (var method in PaymentHelpers.PaymentMethods)
            {
                if (method.Code == challenge) return true;
            }
            return false;
        }
    }
}
