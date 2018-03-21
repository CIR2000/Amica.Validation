using Amica.Models.Company;
using FluentValidation;

namespace Amica.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
		public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.FiscalProfile).SetValidator(new FiscalProfileValidator());
        }
    }
}
