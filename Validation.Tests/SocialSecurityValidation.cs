using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class SocialSecurityValidation : BaseTestClass<SocialSecurity, SocialSecurityValidator>
    {
		[TestMethod]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Vat, typeof(VatValidator));
        }
		[TestMethod]
		public void SocialSecurityCategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Category, typeof(SocialSecurityCategoryValidator));
        }
    }
}
