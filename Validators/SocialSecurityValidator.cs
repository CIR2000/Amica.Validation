using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class SocialSecurityValidator : AbstractValidator<SocialSecurity>
    {
        public SocialSecurityValidator()
        {
            RuleFor(dp => dp.Vat).SetValidator(new VatValidator());
            RuleFor(dp => dp.Category).SetValidator(new SocialSecurityCategoryValidator());
        }
    }
}
