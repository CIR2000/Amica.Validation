using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class SalesSettingsValidation : BaseTestClass<SalesSettings, SalesSettingsValidator>
    {
        [TestMethod]
        public void EinvoiceIdLength()
        {
            AssertMinMaxLength(c => c.EinvoiceId, 6, 7);
        }
    }
}
