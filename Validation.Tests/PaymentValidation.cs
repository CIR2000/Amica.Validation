using NUnit.Framework;
using Amica.Models;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Amica.Validation.Tests
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

            validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentOption, PaymentHelpers.FirstPaymentOptions[PaymentOption.Normal]);
        }
		[Test]
		public void FirstPaymentDate()
        {
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentDate, null as FirstPaymentDate);

            validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, PaymentHelpers.FirstPaymentDates[PaymentDate.DocumentDate]);
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
