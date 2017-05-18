using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentStatusValidation : BaseTestClass<Status, DocumentStatusValidator>
    {
		[Test]
		public void CodeIsRequired()
        {
            AssertRequired(s => s.Code);
        }
		[Test]
		public void DescriptionIsRequired()
        {
            AssertRequired(s => s.Description);
        }
    }
}
