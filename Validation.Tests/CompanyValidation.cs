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
            AssertLength(c => c.CodiceRea, 9);
        }
        [Test]
        public void CodiceSiaLength()
        {
            AssertLength(c => c.CodiceSia, 5);
        }
		[Test]
		public void PredefinizioniVatNameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Predefinizioni.Vat.Name, challenge);
            challenge.Predefinizioni.Vat.Name = "name";
            validator.ShouldNotHaveValidationErrorFor(c => c.Predefinizioni.Vat.Name, challenge);
        }
		[Test]
		public void PredefinizioniVatCodeIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Predefinizioni.Vat.Code, challenge);
            challenge.Predefinizioni.Vat.Code = "code";
            validator.ShouldNotHaveValidationErrorFor(c => c.Predefinizioni.Vat.Code, challenge);
        }
    }
}
