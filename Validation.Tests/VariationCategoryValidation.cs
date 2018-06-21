using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class VariationCategoryValidation : BaseTestClass<VariationCategory, VariationCategoryValidator>
    {
		[TestMethod]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
