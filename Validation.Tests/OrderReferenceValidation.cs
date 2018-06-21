using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class OrderReferenceValidation : BaseTestClass<OrderReference, OrderReferenceValidator>
    {
		[TestMethod]
		public void ItemIdIsRequired()
        {
            AssertRequired(x => x.ItemId);
        }
		[TestMethod]
		public void NumberHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Number, typeof(DocumentNumberValidator));
        }
    }
}
