using NUnit.Framework;
using Amica.vNext.Models;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class PaymentValidation
    {
        private PaymentValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new PaymentValidator();
        }

		[Test]
		public void Name()
        {
            validator.ShouldHaveValidationErrorFor(p => p.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(p => p.Name, null as string);

            validator.ShouldNotHaveValidationErrorFor(p => p.Name, "payment1");
        }
		[Test]
		public void FirstPaymentOption()
        {
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentOption, null as FirstPaymentOption);
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentOption, new FirstPaymentOption { Code = 999 });

            validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentOption, PaymentOptions.FirstPaymentOptions[1]);
        }
		[Test]
		public void FirstPaymentDate()
        {
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentDate, null as FirstPaymentDate);
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentDate, new FirstPaymentDate { Code = 999 });

            validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, PaymentOptions.FirstPaymentDates[1]);
        }
		[Test]
		public void Fee()
        {
            validator.ShouldNotHaveValidationErrorFor(p => p.Fee, null as Fee);
            validator.ShouldNotHaveValidationErrorFor(p => p.Fee, new Fee());
        }
		[Test]
		public void Bank()
        {
            validator.ShouldNotHaveValidationErrorFor(p => p.Bank, null as Bank);
            validator.ShouldNotHaveValidationErrorFor(p => p.Bank, new Bank());
        }
		[Test]
		public void PaymentMethod()
        {
            validator.ShouldNotHaveValidationErrorFor(p => p.PaymentMethod, null as PaymentMethod);
            validator.ShouldNotHaveValidationErrorFor(p => p.PaymentMethod, new PaymentMethod());
        }
    }
}
