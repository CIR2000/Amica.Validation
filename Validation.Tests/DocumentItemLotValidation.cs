using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentItemLotValidation : BaseTestClass<DocumentItemLot, DocumentItemLotValidator>
    {
		[TestMethod]
		public void NumberIsRequired()
        {
            AssertRequired(c => c.Number);
        }
    }
}
