using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class FeeValidation
    {
        private FeeValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new FeeValidator();
        }

		[Test]
		public void Name()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Name, null as string);

            validator.ShouldNotHaveValidationErrorFor(c => c.Name, "name");
        }
		[Test]
		public void Vat()
        {
            validator.ShouldHaveChildValidator(c => c.Vat, typeof(VatValidator));
        }


    }
}
