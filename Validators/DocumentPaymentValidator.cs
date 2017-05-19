using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class DocumentPaymentValidator : AbstractValidator<DocumentPayment>
    {
		public DocumentPaymentValidator()
        {
            RuleFor(dp => dp.Current)
                .NotNull() 
                .SetValidator(new PaymentValidator());
        }
    }
}
