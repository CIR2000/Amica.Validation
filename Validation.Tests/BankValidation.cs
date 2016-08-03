using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class BankValidation
    {
        private BankValidator _validator;

		[SetUp]
		public void Init()
        {
            _validator = new BankValidator();
        }

		[Test]
		public void Name() {
			_validator.ShouldHaveValidationErrorFor(c => c.Name, null as string); 
			_validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);

            _validator.ShouldNotHaveValidationErrorFor(c => c.Name, "A");
        }
		[Test]
		public void IbanCode()
        {
            _validator.ShouldHaveValidationErrorFor(c => c.IbanCode, string.Empty);
            _validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "ABC");
            _validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "88T1927501600CC0010110180");

            _validator.ShouldNotHaveValidationErrorFor(c => c.IbanCode, "IT88T1927501600CC0010110180");
        }

		[Test]
		public void SwitCode() {

            _validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, string.Empty);
            _validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "A");
            _validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "12345678901");

            _validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, null as string); 
            _validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ABCOITMM"); 
            _validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ICRAITRRL90"); 
            _validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "CRGEITGG183"); 
        }

    }
}
