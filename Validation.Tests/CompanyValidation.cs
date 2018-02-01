using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Company;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class CompanyValidation : BaseTestClass<Company, CompanyValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
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
		[Test]
		public void FiscalProfileHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.FiscalProfile, typeof(FiscalProfileValidator));
        }
    }
}
