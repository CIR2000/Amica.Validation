using System;
using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
		public PaymentValidator()
        {
            RuleFor(payment => payment.Name).NotEmpty();

            RuleFor(payment => payment.FirstPaymentOption)
				.Must(BeValidFirstPaymentOption).When(payment => payment.FirstPaymentOption != null)
				.NotNull();

            RuleFor(payment => payment.FirstPaymentDate)
				.Must(BeValidFirstPaymentDate).When(payment => payment.FirstPaymentDate != null)
				.NotNull();

			RuleFor(payment => payment.PaymentMethod).SetValidator(new PaymentMethodValidator());
            RuleFor(payment => payment.BankId).Matches(ValidatorHelpers.ValidObjectId);
            RuleFor(payment => payment.FeeId).Matches(ValidatorHelpers.ValidObjectId);
        }
		private static bool BeValidFirstPaymentOption(FirstPaymentOption challenge)
        {
            return PaymentHelpers.FirstPaymentOptions.ContainsKey(challenge.Option);
        }

		private static bool BeValidFirstPaymentDate(FirstPaymentDate challenge)
        {
            return PaymentHelpers.FirstPaymentDates.ContainsKey(challenge.Option);
        }

    }
}
