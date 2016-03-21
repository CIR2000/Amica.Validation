using NUnit.Framework;
using Amica.vNext.Validation;
using Amica.vNext.Models.ItalianPA;
using FluentValidation.TestHelper;
using Amica.vNext.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class ChargeValidation
    {
        private ChargeValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new ChargeValidator();
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
