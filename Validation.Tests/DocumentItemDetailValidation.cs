using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentItemDetailValidation : BaseTestClass<DocumentItemDetail, DocumentItemDetailValidator>
    {
		[TestMethod]
		public void DescriptionIsRequired()
        {
            AssertRequired(d => d.Description);
        }
		[TestMethod]
		public void SizeHasChildValidator() {
            validator.ShouldHaveChildValidator(d => d.Size, typeof(DocumentItemSizeValidator));
        }
		[TestMethod]
		public void LotHasChildValidator() {
            validator.ShouldHaveChildValidator(d => d.Lot, typeof(DocumentItemLotValidator));
        }
    }
}
