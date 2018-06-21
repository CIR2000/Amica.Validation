using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentStatusValidation : BaseTestClass<Status, DocumentStatusValidator>
    {
		[TestMethod]
		public void CodeIsRequired()
        {
            AssertRequired(s => s.Code);
        }
		[TestMethod]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
