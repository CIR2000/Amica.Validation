using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
		public CurrencyValidator()
        {
            RuleFor(currency => currency.Name).NotEmpty();
            RuleFor(currency => currency.Code).NotEmpty();
            RuleFor(currency => currency.Symbol).NotEmpty();
        }
    }
}
