using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class CurrencyValidation : BaseTestClass<Currency, CurrencyValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[TestMethod]
		public void CodeIsRequired()
        {
            AssertRequired(c => c.Code);
        }
		[TestMethod]
		public void SymbolIsRequired()
        {
            AssertRequired(c => c.Symbol);
        }
    }
}
