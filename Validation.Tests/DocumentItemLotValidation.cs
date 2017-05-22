using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentItemLotValidation : BaseTestClass<DocumentItemLot, DocumentItemLotValidator>
    {
		[Test]
		public void NumberIsRequired()
        {
            AssertRequired(c => c.Number);
        }
    }
}
