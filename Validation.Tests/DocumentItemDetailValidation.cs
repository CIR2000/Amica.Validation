using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentItemDetailValidation : BaseTestClass<DocumentItemDetail, DocumentItemDetailValidator>
    {
		[Test]
		public void DescriptionIsRequired()
        {
            AssertRequired(d => d.Description);
        }
		[Test]
		public void SizeHasChildValidator() {
            validator.ShouldHaveChildValidator(d => d.Size, typeof(DocumentItemSizeValidator));
        }
		[Test]
		public void LotHasChildValidator() {
            validator.ShouldHaveChildValidator(d => d.Lot, typeof(DocumentItemLotValidator));
        }
    }
}
