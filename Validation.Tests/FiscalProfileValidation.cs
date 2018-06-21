using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Company;

namespace Validation.Tests
{
    [TestClass]
    public class FiscalProfileValidation : BaseTestClass<FiscalProfile, FiscalProfileValidator>
    {
		[TestMethod]
		public void TaxIdentificationNumberMustBeValid() {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }

        [TestMethod]
        public void VatIdntificationNumberMustBeValid() {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }
        [TestMethod]
        public void CodiceReaLength()
        {
            AssertLength(c => c.REACode, 9);
        }
        [TestMethod]
        public void CodiceSiaLength()
        {
            AssertLength(c => c.SIACode, 5);
        }
		[TestMethod]
		public void VatIdIsValidObjectId()
        {
            AssertIsValidObjectId<FiscalProfile>(x => x.VatId);
        }
    }
}
