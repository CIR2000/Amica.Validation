using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.Name).NotEmpty();
            RuleFor(contact => contact.IdCode).NotEmpty();

            RuleFor(contact => contact.VatIdentificationNumber)
                .Must(ValidatorHelpers.BeValidVatNumber)
                .WithMessage(ErrorMessages.VatIdentificationNumberError)
                .When(contact => contact.VatIdentificationNumber != null);
            RuleFor(contact => contact.TaxIdentificationNumber)
                .Must(ValidatorHelpers.BeValidTaxIdNumber)
                .WithMessage(ErrorMessages.TaxIdentificationNumberError)
                .When(c => c.TaxIdentificationNumber != null);


            // TODO WithMessage, localized
            RuleFor(contact => contact.Relationship).Must(BeValidRelationship);

            RuleFor(contact => contact.Address).SetValidator(new AddressExValidator());

            RuleForEach(contact => contact.OtherAddresses).
                SetValidator(new ShippingAddressValidator());
            RuleFor(contact => contact.SalesSettings).
                SetValidator(new SalesSettingsValidator());
        }

        private static bool BeValidRelationship(Relationship relationship)
        {
            return !(
                relationship.IsActive == false &&
                relationship.IsAgent == false &&
                relationship.IsAreaManager == false &&
                relationship.IsClient == false &&
                relationship.IsCompany == false &&
                relationship.IsCourier == false &&
                relationship.IsVendor == false
                );
        }

    }
}
