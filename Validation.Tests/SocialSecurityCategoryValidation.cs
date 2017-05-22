using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class SocialSecurityCategoryValidation : BaseTestClass<SocialSecurityCategory, SocialSecurityCategoryValidator>
    {
		[Test]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
