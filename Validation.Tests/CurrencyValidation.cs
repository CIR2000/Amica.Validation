using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class CurrencyValidation : BaseTestClass<Currency, CurrencyValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void CodeIsRequired()
        {
            AssertRequired(c => c.Code);
        }
		[Test]
		public void SymbolIsRequired()
        {
            AssertRequired(c => c.Symbol);
        }
    }
}
