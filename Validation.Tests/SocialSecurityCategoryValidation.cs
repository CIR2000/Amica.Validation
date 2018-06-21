using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class SocialSecurityCategoryValidation : BaseTestClass<SocialSecurityCategory, SocialSecurityCategoryValidator>
    {
		[TestMethod]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
