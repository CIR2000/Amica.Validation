using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class VariationCategoryValidation : BaseTestClass<VariationCategory, VariationCategoryValidator>
    {
		[Test]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
