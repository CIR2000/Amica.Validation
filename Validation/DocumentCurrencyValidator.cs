using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class DocumentCurrencyValidator : AbstractValidator<DocumentCurrency>
    {
		public DocumentCurrencyValidator()
        {
            RuleFor(currency => currency.Current)
                .NotNull() 
                .SetValidator(new CurrencyValidator());
            RuleFor(currency => currency.ExchangeRate).NotEqual(0);
        }
    }
}
