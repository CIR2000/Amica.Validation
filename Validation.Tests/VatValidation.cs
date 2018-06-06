using NUnit.Framework;
using Amica.Validation;
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
            validator.ShouldHaveValidationErrorFor(c => c.VatExemption, new VatExemption ());
            validator.ShouldHaveValidationErrorFor(c => c.VatExemption, new VatExemption { Code = "hello" });
            validator.ShouldHaveValidationErrorFor(c => c.VatExemption, new VatExemption { Code = "MP01" });
            validator.ShouldHaveValidationErrorFor(c => c.VatExemption, new VatExemption { Code = "MP01", Description = "fail" });

            AssertOptional(c => c.VatExemption);
            foreach (var n in ItalianPAHelpers.VatExemption)
                validator.ShouldNotHaveValidationErrorFor(c => c.VatExemption, n.Value);
        }


    }
}
