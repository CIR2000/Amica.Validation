using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class VariationValidator : AbstractValidator<Variation>
    {
        public VariationValidator()
        {
            RuleFor(dp => dp.Category).SetValidator(new VariationCategoryValidator());
        }
    }
}
