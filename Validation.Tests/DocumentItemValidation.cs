using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentItemValidation : BaseTestClass<DocumentItem, DocumentItemValidator>
    {
		[TestMethod]
		public void GuidIsRequired()
        {
			AssertRequired(x => x.Guid); 
        }
		[TestMethod]
		public void DetailHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Detail, typeof(DocumentItemDetailValidator));
        }

		[TestMethod]
		public void OrderHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Order, typeof(OrderReferenceValidator));
        }
		[TestMethod]
		public void VatHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Vat, typeof(VatValidator));
        }
		[TestMethod]
		public void WarehouseHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.Warehouse, typeof(WarehouseValidator));
        }
		[TestMethod]
		public void VariationHasChildValidator() {
            validator.ShouldHaveChildValidator(x => x.VariationCollection, typeof(VariationValidator));
        }
    }
}
