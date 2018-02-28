using Amica.Models.Company;
using FluentValidation;

namespace Amica.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
		public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.REACode).Length(9).When(x=>x.REACode != null);
            RuleFor(x => x.SIACode).Length(5).When(x=>x.SIACode != null);
            RuleFor(x => x.FiscalProfile).SetValidator(new FiscalProfileValidator());
        }
    }
}
