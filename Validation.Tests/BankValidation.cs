using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class BankValidation : BaseTestClass<BankAsProperty, BankValidator>
    {
		[Test]
		public void NameIsRequired()
        { 
            AssertRequired(b=>b.Name);
        }
		[Test]
		public void IbanCodeMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "ABC");
            validator.ShouldHaveValidationErrorFor(c => c.IbanCode, "88T1927501600CC0010110180");

            validator.ShouldNotHaveValidationErrorFor(c => c.IbanCode, "IT88T1927501600CC0010110180");
            validator.ShouldNotHaveValidationErrorFor(c => c.IbanCode, value:null);
        }

		[Test]
		public void SwitCodeMustBeValid() {

            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "A");
            validator.ShouldHaveValidationErrorFor(c => c.BicSwiftCode, "12345678901");

            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, value:null); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ABCOITMM"); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "ICRAITRRL90"); 
            validator.ShouldNotHaveValidationErrorFor(c => c.BicSwiftCode, "CRGEITGG183"); 
        }

    }
}
