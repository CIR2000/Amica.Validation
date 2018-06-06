using FluentValidation;
using Amica.Models.Company;

namespace Amica.Validation
{
    public class FiscalProfileValidator : AbstractValidator<FiscalProfile>
    {
		public FiscalProfileValidator() 
        {
            RuleFor(address => address.VatIdentificationNumber)
                .Must(ValidatorHelpers.BeValidVatNumber)
                .WithMessage(ErrorMessages.VatIdentificationNumber)
                .When(address => address.VatIdentificationNumber != null);
            RuleFor(address => address.TaxIdentificationNumber)
                .Must(ValidatorHelpers.BeValidTaxIdNumber)
                .WithMessage(ErrorMessages.TaxIdentificationNumber)
                .When(address=> address.TaxIdentificationNumber != null);
            RuleFor(x => x.REACode).Length(9).When(x=>x.REACode != null);
            RuleFor(x => x.SIACode).Length(5).When(x=>x.SIACode != null);
            RuleFor(x => x.VatId).Matches(ValidatorHelpers.ValidObjectId);
        }
    }
}
