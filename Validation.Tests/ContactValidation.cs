using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class ContactValidation : BaseTestClass<Contact, ContactValidator>
    {
		[Test]
		public void NameIsRequired()
        {
			AssertRequired(c => c.Name); 
        }
		[Test]
		public void TaxIdentificationNumberMustBeValid() {
            var invalid = new string[]
            {
                string.Empty,
				// last char is wrong
                "RCCNCL70M27B519Z",
				// too short
				"8012345678", "9012345678",
				// too long
				"801234567890", "901234567890",
				// not valid
				"80123456789", "90123456789"
            };
			foreach(var idCode in invalid)
				validator.ShouldHaveValidationErrorFor(c => c.TaxIdentificationNumber, idCode);


            var valid = new string[] {
                null,
                "RCCNCL70M27B519E", "grdsfn66d17h199k",
                "92078790398", "95052810132", "94078890541", "90029830669",
                "81004300067", "80064390372", "80028050583", "80007770102", "80003350891"
            };
			foreach(var idCode in valid)
				validator.ShouldNotHaveValidationErrorFor(c => c.TaxIdentificationNumber, value:idCode);
        }

        [Test]
        public void VatIdntificationNumberMustBeValid() {
            var invalid = new string[] {string.Empty, "A", "01180680399", "UK01180680397", "IT01180680399"};
			foreach(var idCode in invalid)
				validator.ShouldHaveValidationErrorFor(c => c.VatIdentificationNumber, idCode);

            var valid = new string[] {null, "01180680397", "IT01180680397", "02182030391", "IT02182030391", "92078790398"};
			foreach(var idCode in valid)
				validator.ShouldNotHaveValidationErrorFor(c => c.VatIdentificationNumber, value:idCode);
        }

		[Test]
		public void PublicAdministrationIndexLength() {
            const int length = 6;
			validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, "A");
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length+1));
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length-1));

            validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationIndex, value:null);
            validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length));
        }

        [Test]
        public void ContactIsMustBeValid() {
            validator.ShouldHaveValidationErrorFor(c => c.Is, new ContactIs());

            validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Client = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Vendor = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Courier = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Agent = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { AreaManager = true });
        }

		[Test]
		public void AddressHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Address, typeof(AddressExValidator));
        }

		[Test]
		public void BankHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Bank, typeof(BankValidator));
        }
		[Test]
		public void OtherAddressesHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.OtherAddresses, typeof(AddressExValidator));
        }
    }
}
