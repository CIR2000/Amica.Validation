using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class ContactValidation
    {
        private ContactValidator _validator;

		[SetUp]
		public void Init()
        {
            _validator = new ContactValidator();
        }

		[Test]
		public void NameIsRequired() {
			_validator.ShouldHaveValidationErrorFor(c => c.Name, value:null); 
			_validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);

            _validator.ShouldNotHaveValidationErrorFor(c => c.Name, "A");
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
				_validator.ShouldHaveValidationErrorFor(c => c.TaxIdentificationNumber, idCode);


            var valid = new string[] {
                null,
                "RCCNCL70M27B519E", "grdsfn66d17h199k",
                "92078790398", "95052810132", "94078890541", "90029830669",
                "81004300067", "80064390372", "80028050583", "80007770102", "80003350891"
            };

			foreach(var idCode in valid)
				_validator.ShouldNotHaveValidationErrorFor(c => c.TaxIdentificationNumber, value:idCode);
        }

        [Test]
        public void VatIdntificationNumberMustBeValid() {
            var invalid = new string[] {string.Empty, "A", "01180680399", "UK01180680397", "IT01180680399"};
			foreach(var idCode in invalid)
				_validator.ShouldHaveValidationErrorFor(c => c.VatIdentificationNumber, idCode);

            var valid = new string[] {null, "01180680397", "IT01180680397", "02182030391", "IT02182030391", "92078790398"};
			foreach(var idCode in valid)
				_validator.ShouldNotHaveValidationErrorFor(c => c.VatIdentificationNumber, value:idCode);
        }

		[Test]
		public void PublicAdministrationIndexLength() {
            const int length = 6;
			_validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, string.Empty);
            _validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, "A");
            _validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length+1));
            _validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length-1));

            _validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationIndex, value:null);
            _validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationIndex, new string('A', length));
        }

        [Test]
        public void ContactIsMustBeValid() {
            _validator.ShouldHaveValidationErrorFor(c => c.Is, new ContactIs());

            _validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Client = true });
            _validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Vendor = true });
            _validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Courier = true });
            _validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { Agent = true });
            _validator.ShouldNotHaveValidationErrorFor(c => c.Is, new ContactIs { AreaManager = true });
        }

		[Test]
		public void AddressHasChildValidator() {
            _validator.ShouldHaveChildValidator(c => c.Address, typeof(AddressExValidator));
        }

		[Test]
		public void BankHasChildValidator() {
            _validator.ShouldHaveChildValidator(c => c.Bank, typeof(BankValidator));
        }
		[Test]
		public void OtherAddressesHasChildValidator() {
            _validator.ShouldHaveChildValidator(c => c.OtherAddresses, typeof(AddressExValidator));
        }
    }
}
