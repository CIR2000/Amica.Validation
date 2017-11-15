using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
		public CompanyValidator()
        {
            RuleFor(company => company.Name).NotEmpty();
        }

    }
}
