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
		public void NameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Name, value:null);

            validator.ShouldNotHaveValidationErrorFor(c => c.Name, "name");
        }
		[Test]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(c => c.Vat, typeof(VatValidator));
        }


    }
}
