using System;
using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class PriceListValidator : AbstractValidator<PriceList>
    {
        public PriceListValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.CurrencyCode)
                .NotEmpty()
                .Must(challenge => !string.IsNullOrEmpty(challenge) && CurrencyHelpers.Currencies.ContainsKey(challenge));
            RuleFor(x => x.PricesAreSet).IsInEnum();
        }
    }
}