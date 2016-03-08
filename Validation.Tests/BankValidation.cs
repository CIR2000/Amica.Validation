using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class BankValidation
    {
        private BankValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new BankValidator();
        }

		[Test]
		public void Name() {
            var length = 100;
            validator.ShouldHaveValidationErrorFor(c => c.Name, new string('A', length+1));
			validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);

			validator.ShouldNotHaveValidationErrorFor(c => c.Name, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Name, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Name, new string('A', length));
        }

		[Test]
		public void IbanCode()
        {
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "ABC");
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "88T1927501600CC0010110180");

            validator.ShouldNotHaveValidationErrorFor(c => c.IbanCode, "IT88T1927501600CC0010110180");
        }

		[Test]
		public void SwitCode() {

            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "A");
            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "12345678901");

            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ABCOITMM"); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ICRAITRRL90"); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "CRGEITGG183"); 
        }

    }
}
