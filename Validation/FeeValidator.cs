using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class FeeValidator : AbstractValidator<Fee>
    {
		public FeeValidator()
        {
            RuleFor(charge => charge.Name).NotEmpty();
            RuleFor(charge => charge.VatId).Matches(ValidatorHelpers.ValidObjectId);
        }
    }
}
