using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentNumberValidation : BaseTestClass<DocumentNumber, DocumentNumberValidator>
    {
		[TestMethod]
		public void NumericIsRequired()
        {
            AssertRequired(n => n.Numeric);
        }
    }
}
