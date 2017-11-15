using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class SocialSecurityCategoryValidator : AbstractValidator<SocialSecurityCategory>
    {
		public SocialSecurityCategoryValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
