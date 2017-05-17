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
                .Must(BeValidVatNumber)
                .When(contact => contact.VatIdentificationNumber != null);
		    RuleFor(contact => contact.TaxIdentificationNumber)
                .Must(BeValidTaxIdNumber)
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

        #region TAX IDENTIFICATION NUMBER
        private static bool BeValidTaxIdNumber(string taxIdCode)
        {
			// we only support Italian fiscal codes for the time being.
            return IsItalianTaxIdNumber(taxIdCode);
        }

		private static bool IsItalianTaxIdNumber(string taxIdCode)
        { 
            if (string.IsNullOrEmpty(taxIdCode))
                return false;

            if (taxIdCode.Length == 11 && (taxIdCode.StartsWith("9") || taxIdCode.StartsWith("8"))) 
				return IsItalianVatNumber(taxIdCode);

            if (taxIdCode.Length != 16)
                return false;

            var idCode = taxIdCode.ToUpper();

            const string set1 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string set2 = "ABCDEFGHIJABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string even = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string odd = "BAKPLCQDREVOSFTGUHMINJWZYX";

            var s = 0;
            for (var i = 1; i <= 13; i += 2)
                s += even.IndexOf(set2.ToCharArray()[set1.IndexOf(idCode.ToCharArray()[i])]);

            for (var i = 0; i <= 14; i += 2)
                s += odd.IndexOf(set2.ToCharArray()[set1.IndexOf(idCode.ToCharArray()[i])]);

            return (s % 26 == idCode.ToCharArray()[15] - 65);
        }
        #endregion

        #region  VAT VALIDATION
        private static bool BeValidVatNumber(string vat)
        {
			vat = vat.Trim().ToUpper();

            // if country code is missing, assume Italian VAT
            if (vat.StartsWith("IT") || vat.Length == 11)
                return IsItalianVatNumber(vat);

			// add more VAT checks for other countries here

            return false;
        }

		private static bool IsItalianVatNumber(string vat)
        {
			vat = vat.TrimStart("IT".ToCharArray());

			try
			{
			    if (vat.Length != 11) return false;
			    var odd = 0;
					
			    for(var i = 0; i < 10; i += 2)
			        odd += int.Parse(vat.Substring(i, 1));
					
			    for(var i = 1; i < 10; i += 2)
			    {
			        var tot = (int.Parse(vat.Substring(i, 1))) * 2;
			        tot = (tot / 10) + (tot % 10);
			        odd += tot;
			    }
							
			    var checksum = int.Parse(vat.Substring(10, 1));
								
			    return ((odd % 10) == 0 && (checksum == 0)) || ((10 - (odd % 10)) == checksum);
			}
			catch (Exception)
            {
			  return false;
			}

        }
        #endregion
    }
}
