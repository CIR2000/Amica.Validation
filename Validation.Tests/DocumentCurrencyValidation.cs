using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentCurrencyValidation : BaseTestClass<DocumentCurrency, DocumentCurrencyValidator>
    {
		[Test]
		public void ExchangeRateNotEqual0()
        {
            validator.ShouldHaveValidationErrorFor(c => c.ExchangeRate, new DocumentCurrency { ExchangeRate = 0 });
        }
		[Test]
		public void CurrentHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Current, typeof(CurrencyValidator));
        }
		[Test]
		public void CurrentIsRequired()
        {
            AssertRequired(c => c.Current);
        }
    }
}
