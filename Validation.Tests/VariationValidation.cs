using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class VariationValidation : BaseTestClass<Variation, VariationValidator>
    {
		[Test]
		public void CategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Category, typeof(VariationCategoryValidator));
        }
    }
}
