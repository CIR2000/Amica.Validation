using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentNumberValidation : BaseTestClass<DocumentNumber, DocumentNumberValidator>
    {
		[Test]
		public void NumericIsRequired()
        {
            AssertRequired(n => n.Numeric);
        }
    }
}
