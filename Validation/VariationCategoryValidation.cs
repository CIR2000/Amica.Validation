using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class VariationCategoryValidator : AbstractValidator<VariationCategory>
    {
		public VariationCategoryValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
