using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class ShippingValidator : AbstractValidator<Shipping>
    {
        public ShippingValidator()
        {
            RuleFor(dp => dp.Courier).SetValidator(new ContactDetailsExValidator());
            RuleFor(dp => dp.Courier)
                .NotNull()
                .When(dp => dp.TransportMode.Code == DocumentTransportMode.Courier);
            RuleFor(dp => dp.Terms).SetValidator(new ShippingTermValidator());
        }
    }
}
