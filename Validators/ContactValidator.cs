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
                .When(contact => contact.VatIdentificationNumber != null);
		    RuleFor(contact => contact.TaxIdentificationNumber)
                .Must(ValidatorHelpers.BeValidTaxIdNumber)
                .When(c => c.TaxIdentificationNumber != null);

            RuleFor(contact => contact.PublicAdministrationIndex).Length(6);

            // TODO WithMessage, localized
            RuleFor(contact => contact.Is).Must(BeValidContactKind);

            RuleFor(contact => contact.Address).SetValidator(new AddressExValidator());
            RuleFor(contact => contact.Bank).SetValidator(new BankValidator());

            RuleFor(contact => contact.OtherAddresses).
                SetCollectionValidator(new AddressExValidator());
        }

		private static bool BeValidContactKind(ContactIs contactIs)
        {
            return !(
                contactIs.Client == false && 
				contactIs.Vendor == false &&
				contactIs.Courier == false &&
				contactIs.Agent == false &&
				contactIs.AreaManager == false
				);
        }

    }
}
