using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentItemValidation : BaseTestClass<DocumentItem, DocumentItemValidator>
    {
		[Test]
		public void GuidIsRequired()
        {
			AssertRequired(x => x.Guid); 
        }
		[Test]
		public void DetailHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Detail, typeof(DocumentItemDetailValidator));
        }

		[Test]
		public void OrderHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Order, typeof(OrderReferenceValidator));
        }
		[Test]
		public void VatHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Vat, typeof(VatValidator));
        }
		[Test]
		public void WarehouseHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Warehouse, typeof(WarehouseValidator));
        }
		[Test]
		public void VariationHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.VariationCollection, typeof(VariationValidator));
        }
    }
}
