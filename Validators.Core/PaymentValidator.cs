using System;
using Amica.vNext.Models;
using FluentValidation;

namespace Amica.vNext.Validation
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

            RuleFor(payment => payment.Fee).SetValidator(new FeeValidator());
            RuleFor(payment => payment.Bank).SetValidator(new BankValidator());
			RuleFor(payment => payment.PaymentMethod).SetValidator(new PaymentMethodValidator());
        }
		private static bool BeValidFirstPaymentOption(FirstPaymentOption challenge)
        {
            return PaymentHelpers.FirstPaymentOptions.ContainsKey(challenge.Code);
        }

		private static bool BeValidFirstPaymentDate(FirstPaymentDate challenge)
        {
            return PaymentHelpers.FirstPaymentDates.ContainsKey(challenge.Code);
        }

    }
}
