using NUnit.Framework;
using Amica.Validation;
using Amica.Models.ItalianPA;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class PaymentMethodValidation : BaseTestClass<PaymentMethod, PaymentMethodValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(o => o.Name);
        }
		[Test]
		public void ModalitaPagamentoPAIsOptional()
        {
            AssertOptional(o => o.ModalitaPagamentoPA);
        }

		[Test]
		public void ModalitaPagamentoPAMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(
                o => o.ModalitaPagamentoPA, new ModalitaPagamentoPA { Code = "hello" });

            foreach (var n in PAHelpers.ModalitaPagamentoPA)
                validator.ShouldNotHaveValidationErrorFor(o => o.ModalitaPagamentoPA, n.Value);
        }


    }
}
