using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class ShippingValidator : AbstractValidator<Shipping>
    {
		public ShippingValidator()
        {
            RuleFor(dp => dp.Courier).SetValidator(new ContactDetailsExValidator());
        }
    }
}
