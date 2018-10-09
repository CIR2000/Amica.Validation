using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class BillingAddressValidator : AbstractValidator<BillingAddress>
    {
		public BillingAddressValidator() 
        {
            RuleFor(address => address.Name).NotEmpty();
            RuleFor(address => address.VatIdentificationNumber)
                .Must(ValidatorHelpers.BeValidVatNumber)
                .WithMessage(ErrorMessages.VatIdentificationNumberError)
                .When(address=> address.VatIdentificationNumber != null);
            RuleFor(address => address.TaxIdentificationNumber)
                .Must(ValidatorHelpers.BeValidTaxIdNumber)
                .WithMessage(ErrorMessages.TaxIdentificationNumberError)
                .When(address=> address.TaxIdentificationNumber != null);
        }
    }
}
