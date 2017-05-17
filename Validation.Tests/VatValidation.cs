using NUnit.Framework;
using Amica.Validation;
using Amica.Models.ItalianPA;
using FluentValidation.TestHelper;

namespace Amica.Validation.Tests
{
    [TestFixture]
    public class VatValidation
    {
        private VatValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new VatValidator();
        }

		[Test]
		public void CodeIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Code, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Code, value:null);

            validator.ShouldNotHaveValidationErrorFor(c => c.Code, "code");
        }
		[Test]
		public void NameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Name, value:null);

            validator.ShouldNotHaveValidationErrorFor(c => c.Name, "name");
        }
		[Test]
		public void PublicAdministrationNatureMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA ());
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "hello" });
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "MP01" });
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "MP01", Description = "fail" });

            validator.ShouldNotHaveValidationErrorFor(c => c.NaturaPA, value:null);
            foreach (var n in PAHelpers.NaturaPA)
                validator.ShouldNotHaveValidationErrorFor(c => c.NaturaPA, n.Value);
        }


    }
}
