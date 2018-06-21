using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentItemSizeValidation : BaseTestClass<DocumentItemSize, DocumentItemSizeValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[TestMethod]
		public void NumberIsRequired()
        {
            AssertRequired(c => c.Number);
        }
    }
}
