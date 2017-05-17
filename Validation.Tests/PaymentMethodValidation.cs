using NUnit.Framework;
using Amica.Validation;
using Amica.Models.ItalianPA;
using FluentValidation.TestHelper;

namespace Amica.Validation.Tests
{
    [TestFixture]
    public class PaymentMethodValidation
    {
        private PaymentMethodValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new PaymentMethodValidator();
        }

		[Test]
		public void NameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(o => o.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(o => o.Name,value:null);

            validator.ShouldNotHaveValidationErrorFor(o => o.Name, "name");
        }

		[Test]
		public void ModalitaPagamentoPAMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(o => o.ModalitaPagamentoPA, new ModalitaPagamentoPA { Code = "hello" });

            validator.ShouldNotHaveValidationErrorFor(o => o.ModalitaPagamentoPA, value:null);
            foreach (var n in PAHelpers.ModalitaPagamentoPA)
                validator.ShouldNotHaveValidationErrorFor(o => o.ModalitaPagamentoPA, n.Value);
        }


    }
}
