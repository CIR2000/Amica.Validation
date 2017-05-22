using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class SocialSecurityValidation : BaseTestClass<SocialSecurity, SocialSecurityValidator>
    {
		[Test]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Vat, typeof(VatValidator));
        }
		[Test]
		public void SocialSecurityCategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Category, typeof(SocialSecurityCategoryValidator));
        }
    }
}
