using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Company;

namespace Validation.Tests
{
    [TestFixture]
    public class FiscalProfileValidation : BaseTestClass<FiscalProfile, FiscalProfileValidator>
    {
		[Test]
		public void TaxIdentificationNumberMustBeValid() {
            AssertValidTaxIdentificationNumber(c => c.TaxIdentificationNumber);
        }

        [Test]
        public void VatIdntificationNumberMustBeValid() {
            AssertValidVatIdentificationNumber(c => c.VatIdentificationNumber);
        }
        [Test]
        public void CodiceReaLength()
        {
            AssertLength(c => c.REACode, 9);
        }
        [Test]
        public void CodiceSiaLength()
        {
            AssertLength(c => c.SIACode, 5);
        }
    }
}
