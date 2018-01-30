using NUnit.Framework;
using Amica.Validation;
using Amica.Models.ItalianPA;
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
		public void ModalitaPagamentoPAIsOptional()
        {
            AssertOptional(o => o.PublicAdministrationPaymentMethod);
        }

		[Test]
		public void ModalitaPagamentoPAMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(
                o => o.PublicAdministrationPaymentMethod, new Amica.Models.ItalianPA.PaymentMethod { Code = "hello" });

            foreach (var n in ItalianPAHelpers.PaymentMethod)
                validator.ShouldNotHaveValidationErrorFor(o => o.PublicAdministrationPaymentMethod, n.Value);
        }


    }
}
