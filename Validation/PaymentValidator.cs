using System;
using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(payment => payment.Name)
                .NotEmpty();

            RuleFor(payment => payment.FirstPaymentOption)
                .NotNull();

            RuleFor(payment => payment.FirstPaymentDate)
                .NotNull();

            RuleFor(payment => payment.PaymentMethod)
                .NotNull()
                .SetValidator(new PaymentMethodValidator());
            RuleFor(payment => payment.BankId)
                .Matches(ValidatorHelpers.ValidObjectId);
            RuleFor(payment => payment.FeeId)
                .Matches(ValidatorHelpers.ValidObjectId);
        }
    }
}