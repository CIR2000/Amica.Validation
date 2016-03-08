using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class CurrencyValidation
    {
        private CurrencyValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new CurrencyValidator();
        }

		[Test]
		public void Name() {
            var length = 40;
			validator.ShouldHaveValidationErrorFor(c => c.Name, null as string); 
			validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Name, new string('A', length+1));

            validator.ShouldNotHaveValidationErrorFor(c => c.Name, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Name, new string('A', length));
        }

		[Test]
		public void Code() {
            var length = 3;
            validator.ShouldHaveValidationErrorFor(c => c.Code, null as string);
			validator.ShouldHaveValidationErrorFor(c => c.Code, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Code, new string('A', length+1));

            validator.ShouldNotHaveValidationErrorFor(c => c.Code, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Code, new string('A', length));
        }

		[Test]
		public void Symbol() {
			validator.ShouldHaveValidationErrorFor(c => c.Symbol, null as string);
			validator.ShouldHaveValidationErrorFor(c => c.Symbol, string.Empty);

            validator.ShouldNotHaveValidationErrorFor(c => c.Symbol, "A");
        }

    }
}
