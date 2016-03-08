using Amica.vNext.Models;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
		public CurrencyValidator()
        {
            RuleFor(currency => currency.Name).NotNull().Length(1, 40);
            RuleFor(currency => currency.Code).NotNull().Length(1, 3);
            RuleFor(currency => currency.Symbol).NotEmpty();
        }
    }
}
