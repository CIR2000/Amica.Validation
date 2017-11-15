using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class ShippingTermValidator : AbstractValidator<ShippingTerm>
    { 
		public ShippingTermValidator()
        {
            RuleFor(status => status.Code).NotEmpty();
            RuleFor(status => status.Description).NotEmpty();
        }
    }
}
