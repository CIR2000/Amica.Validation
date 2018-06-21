using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class VariationValidation : BaseTestClass<Variation, VariationValidator>
    {
		[TestMethod]
		public void CategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Category, typeof(VariationCategoryValidator));
        }
    }
}
