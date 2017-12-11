using Amica.Models.Company;
using FluentValidation;

namespace Amica.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
		public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CodiceRea).Length(9);
            RuleFor(x => x.CodiceSia).Length(5);
            RuleFor(x => x.Predefinizioni.Vat.Name).NotEmpty();
            RuleFor(x => x.Predefinizioni.Vat.Code).NotEmpty();
        }
    }
}
