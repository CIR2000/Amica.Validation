using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class OrderReferenceValidator : AbstractValidator<OrderReference>
    {
		public OrderReferenceValidator()
        {
            RuleFor(fee => fee.Number).SetValidator(new DocumentNumberValidator());
            RuleFor(fee => fee.ItemId).NotEmpty();
        }
    }
}
