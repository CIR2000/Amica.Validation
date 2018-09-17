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
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationCode, "A");
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationCode, new string('A', length + 1));
            validator.ShouldHaveValidationErrorFor(c => c.PublicAdministrationCode, new string('A', length - 1));

            validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationCode, value: null);
            validator.ShouldNotHaveValidationErrorFor(c => c.PublicAdministrationCode, new string('A', length));
        }

        [TestMethod]
        public void ContactIsMustBeValid()
        {
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsActive = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsAgent = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsAreaManager = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsClient = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsCompany = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsCourier = true });
            validator.ShouldNotHaveValidationErrorFor(c => c.Relationship, new Relationship { IsVendor = true });
            validator.ShouldHaveValidationErrorFor(c => c.Relationship, new Relationship() { IsActive = false, IsClient = false, IsCompany = false });
        }

        [TestMethod]
        public void AddressHasChildValidator()
        {
            validator.ShouldHaveChildValidator(c => c.Address, typeof(AddressExValidator));
        }

        [TestMethod]
        public void OtherAddressesHasChildValidator()
        {
            validator.ShouldHaveChildValidator(c => c.OtherAddresses, typeof(ShippingAddressValidator));
        }
    }
}
