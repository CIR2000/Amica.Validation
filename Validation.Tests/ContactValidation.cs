using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class ContactValidation : BaseTestClass<Contact, ContactValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
			AssertRequired(c => c.Name); 
        }
		[TestMethod]
		public void TaxIdentificationNumberMustBeValid()
        {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }
        [TestMethod]
        public void VatIdentificationNumberMustBeValid()
        {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }

		[TestMethod]
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

        [TestMethod]
        public void ContactIsMustBeValid() {
            validator.ShouldHaveValidationErrorFor(c => c.Relationship, new Relationship());

            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsClient = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsVendor = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsCourier = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsAgent = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsAreaManager = true });
        }

		[TestMethod]
		public void AddressHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Address, typeof(AddressExValidator));
        }

        [TestMethod]
		public void OtherAddressesHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.OtherAddresses, typeof(ShippingAddressValidator));
        }
    }
}
