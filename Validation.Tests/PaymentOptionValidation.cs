using NUnit.Framework;
using Amica.vNext.Validation;
using Amica.vNext.Models.ItalianPA;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class PaymentOptionValidation
    {
        private PaymentOptionValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new PaymentOptionValidator();
        }

		[Test]
		public void Name()
        {
            validator.ShouldHaveValidationErrorFor(o => o.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(o => o.Name, null as string);

            validator.ShouldNotHaveValidationErrorFor(o => o.Name, "name");
        }

		[Test]
		public void ModalitaPagamentoPA()
        {
            validator.ShouldHaveValidationErrorFor(o => o.ModalitaPagamentoPA, new ModalitaPagamentoPA { Code = "hello" });

            validator.ShouldNotHaveValidationErrorFor(o => o.ModalitaPagamentoPA, null as ModalitaPagamentoPA);
            foreach (var n in PACollections.ModalitaPagamentoPA)
                validator.ShouldNotHaveValidationErrorFor(o => o.ModalitaPagamentoPA, (ModalitaPagamentoPA)n.Value);
        }


    }
}
