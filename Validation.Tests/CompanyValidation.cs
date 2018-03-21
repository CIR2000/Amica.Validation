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
		public void FiscalProfileHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.FiscalProfile, typeof(FiscalProfileValidator));
        }
    }
}
