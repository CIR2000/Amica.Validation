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
		public void PredefinizioniVatNameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Preferences.Vat.Name, challenge);
            challenge.Preferences.Vat.Name = "name";
            validator.ShouldNotHaveValidationErrorFor(c => c.Preferences.Vat.Name, challenge);
        }
		[Test]
		public void PredefinizioniVatCodeIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Preferences.Vat.Code, challenge);
            challenge.Preferences.Vat.Code = "code";
            validator.ShouldNotHaveValidationErrorFor(c => c.Preferences.Vat.Code, challenge);
        }
    }
}
