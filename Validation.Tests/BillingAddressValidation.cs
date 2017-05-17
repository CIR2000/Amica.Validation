using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class BillingAddressValidation : BaseTestClass<BillingAddress, BillingAddressValidator>
    {
		[Test]
		public void NameIsRequired()
        {
			AssertRequired(c => c.Name); 
        }
		[Test]
		public void TaxIdentificationNumberMustBeValid() {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }

        [Test]
        public void VatIdntificationNumberMustBeValid() {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }
    }
}
