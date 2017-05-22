using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class OrderReferenceValidation : BaseTestClass<OrderReference, OrderReferenceValidator>
    {
		[Test]
		public void ItemIdIsRequired()
        {
            AssertRequired(x => x.ItemId);
        }
		[Test]
		public void NumberHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Number, typeof(DocumentNumberValidator));
        }
    }
}
