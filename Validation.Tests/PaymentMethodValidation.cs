using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class PaymentMethodValidation : BaseTestClass<Amica.Models.PaymentMethod, PaymentMethodValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(o => o.Name);
        }
		[Test]
		public void PublicAdministrationCodeIsOptional()
        {
            AssertOptional(o => o.PublicAdministrationCode);
        }

		[Test]
		public void PublicAdministrationCodeMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor( o => o.PublicAdministrationCode, "hello");

            foreach (var n in PaymentHelpers.PaymentMethods)
                validator.ShouldNotHaveValidationErrorFor(o => o.PublicAdministrationCode, n.PublicAdministrationCode);
        }


    }
}
