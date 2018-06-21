using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class BillingAddressValidation : BaseTestClass<BillingAddress, BillingAddressValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
			AssertRequired(c => c.Name); 
        }
		[TestMethod]
		public void TaxIdentificationNumberMustBeValid() {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }

        [TestMethod]
        public void VatIdntificationNumberMustBeValid() {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }
    }
}
