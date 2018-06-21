using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentCurrencyValidation : BaseTestClass<DocumentCurrency, DocumentCurrencyValidator>
    {
		[TestMethod]
		public void ExchangeRateNotEqual0()
        {
            validator.ShouldHaveValidationErrorFor(c => c.ExchangeRate, new DocumentCurrency { ExchangeRate = 0 });
        }
		[TestMethod]
		public void CurrentHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Current, typeof(CurrencyValidator));
        }
		[TestMethod]
		public void CurrentIsRequired()
        {
            AssertRequired(c => c.Current);
        }
    }
}
