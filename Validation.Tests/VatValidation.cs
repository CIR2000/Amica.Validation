using NUnit.Framework;
using Amica.Validation;
using Amica.Models.ItalianPA;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class VatValidation : BaseTestClass<Vat, VatValidator>
    {
		[Test]
		public void CodeIsRequired()
        {
            AssertRequired(c => c.Code);
        }
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void PublicAdministrationNatureMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA ());
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "hello" });
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "MP01" });
            validator.ShouldHaveValidationErrorFor(c => c.NaturaPA, new NaturaPA { Code = "MP01", Description = "fail" });

            AssertOptional(c => c.NaturaPA);
            foreach (var n in PAHelpers.NaturaPA)
                validator.ShouldNotHaveValidationErrorFor(c => c.NaturaPA, n.Value);
        }


    }
}
