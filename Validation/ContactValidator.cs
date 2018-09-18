using System;
using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.Name).NotEmpty();

            RuleFor(contact => contact.VatIdentificationNumber)
                .Must(ValidatorHelpers.BeValidVatNumber)
                .WithMessage(ErrorMessages.VatIdentificationNumber)
                .When(contact => contact.VatIdentificationNumber != null);
            RuleFor(contact => contact.TaxIdentificationNumber)
                .Must(ValidatorHelpers.BeValidTaxIdNumber)
                .WithMessage(ErrorMessages.TaxIdentificationNumber)
                .When(c => c.TaxIdentificationNumber != null);

            RuleFor(contact => contact.EinvoiceId).MinimumLength(6).MaximumLength(7).When(contact => contact.EinvoiceId!=null);

            // TODO WithMessage, localized
            RuleFor(contact => contact.Relationship).Must(BeValidRelationship);

            RuleFor(contact => contact.Address).SetValidator(new AddressExValidator());

            RuleFor(contact => contact.OtherAddresses).
                SetCollectionValidator(new ShippingAddressValidator());
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
