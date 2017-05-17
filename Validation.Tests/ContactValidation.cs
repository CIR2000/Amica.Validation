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
		public void TaxIdentificationNumberMustBeValid()
        {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }
        [Test]
        public void VatIdentificationNumberMustBeValid()
        {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }

		[Test]
		public void PublicAdministrationIndexLength()
        {
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
