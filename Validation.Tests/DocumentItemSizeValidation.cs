using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentItemSizeValidation : BaseTestClass<DocumentItemSize, DocumentItemSizeValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void NumberIsRequired()
        {
            AssertRequired(c => c.Number);
        }
    }
}
