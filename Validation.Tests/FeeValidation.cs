using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class FeeValidation : BaseTestClass<Fee, FeeValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(c => c.Vat, typeof(VatValidator));
        }
    }
}
